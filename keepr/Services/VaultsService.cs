namespace keepr.Services
{
    public class VaultsService
    {
        private readonly VaultsRepository _repo;

        public VaultsService(VaultsRepository repo)
        {
            _repo = repo;
        }

        internal Vault CreateVault(Vault vaultData)
        {
            Vault vault = _repo.CreateVault(vaultData);
            return vault;
        }

        internal string DeleteVault(int vaultId, string userId)
        {
            Vault vault = this.GetVaultById(vaultId);
            if(vault.CreatorId != userId) throw new Exception("This vault does not belong to you.");
            _repo.DeleteVault(vaultId);
            return "Vault deleted.";
        }

        internal Vault EditVault(Vault vaultData, string userId)
        {
            Vault originalVault = this.GetVaultById(vaultData.Id);
            if(originalVault.CreatorId != userId) throw new Exception("You do not own this vault.");
            originalVault.Name = vaultData.Name != null ? vaultData.Name : originalVault.Name;
            originalVault.IsPrivate = vaultData.IsPrivate != null ? vaultData.IsPrivate : originalVault.IsPrivate;
            int rowsAffected = _repo.EditVault(originalVault);
            if(rowsAffected == 0) throw new Exception($"Could not edit {originalVault.Name}.");
            if(rowsAffected > 1) throw new Exception("More than one vault was changed for some reason. Oops!");
            return originalVault;
        }

        internal List<Vault> GetMyVaults(string userId)
        {
            List<Vault> vaults = _repo.GetMyVaults(userId);
            return vaults;
        }

        internal Vault GetVaultById(int vaultId)
        {
            Vault vault = _repo.GetVaultById(vaultId);
            if(vault == null) throw new Exception("Vault not found.");
            return vault;
        }

        internal List<Vault> GetVaultsByProfileId(string profileId)
        {
            List<Vault> vaults = _repo.GetVaultsByProfileId(profileId);
            return vaults;
        }
    }
}