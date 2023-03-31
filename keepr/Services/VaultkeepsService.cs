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
    }
}