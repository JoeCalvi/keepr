namespace keepr.Services
{
    public class VaultkeepsService
    {
        private readonly VaultkeepsRepository _repo;

        public VaultkeepsService(VaultkeepsRepository repo)
        {
            _repo = repo;
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
            _repo.DeleteVaultKeep(vaultKeepId);
            return "VaultKeep deleted.";
        }

        internal VaultKeep GetVaultKeepById(int vaultKeepId)
        {
            VaultKeep vaultKeep = _repo.GetVaultKeepById(vaultKeepId);
            return vaultKeep;
        }
    }
}