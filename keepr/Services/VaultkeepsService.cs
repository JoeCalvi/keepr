namespace keepr.Services
{
    public class VaultkeepsService
    {
        private readonly VaultkeepsRepository _repo;
        private readonly KeepsRepository _keepsRepo;

        public VaultkeepsService(VaultkeepsRepository repo, KeepsRepository keepRepo, KeepsRepository keepsRepo)
        {
            _repo = repo;
            _keepsRepo = keepsRepo;
        }

        internal VaultKeep CreateVaultKeep(VaultKeep vaultKeepData)
        {
            VaultKeep vaultKeep = _repo.CreateVaultKeep(vaultKeepData);
            return vaultKeep;
        }

        internal string DeleteVaultKeep(int vaultKeepId, string userId)
        {
            VaultKeep vaultKeep = this.GetVaultKeepById(vaultKeepId);
            if(vaultKeep.CreatorId != userId) throw new Exception("You are not the owner of this relationship.");
            Keep keep = _keepsRepo.GetKeepById(vaultKeep.KeepId);
            _repo.DeleteVaultKeep(vaultKeepId, keep.Id);
            return "VaultKeep deleted.";
        }

        internal VaultKeep GetVaultKeepById(int vaultKeepId)
        {
            VaultKeep vaultKeep = _repo.GetVaultKeepById(vaultKeepId);
            return vaultKeep;
        }
    }
}