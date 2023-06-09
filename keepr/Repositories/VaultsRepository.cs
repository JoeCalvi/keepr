namespace keepr.Repositories
{
    public class VaultsRepository
    {
        private readonly IDbConnection _db;

        public VaultsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal Vault CreateVault(Vault vaultData)
        {
            string sql = @"
            INSERT INTO vaults
            (name, creatorId, description, isPrivate, img)
            VALUES
            (@name, @creatorId, @description, @isPrivate, @img);
            SELECT LAST_INSERT_ID();
            ";

            int id = _db.ExecuteScalar<int>(sql, vaultData);
            vaultData.Id = id;
            return vaultData;
        }

        internal void DeleteVault(int vaultId)
        {
            string sql = @"
            DELETE FROM vaults
            WHERE id = @vaultId;
            ";

            _db.Execute(sql, new { vaultId });
        }

        internal int EditVault(Vault updatedVault)
        {
            string sql = @"
            UPDATE vaults
            SET
            name = @name,
            isPrivate = @isPrivate
            WHERE id = @id;
            ";

            int rows = _db.Execute(sql, updatedVault);
            return rows;
        }

        internal List<Vault> GetMyVaults(string userId)
        {
            string sql = @"
            SELECT
            vault.*,
            acct.*
            FROM vaults vault
            JOIN accounts acct ON vault.creatorId = acct.Id
            WHERE vault.creatorId = @userId;
            ";

            List<Vault> vaults = _db.Query<Vault, Account, Vault>(sql, (vault, account) => {
                vault.Creator = account;
                vault.CreatorId = account.Id;
                return vault;
            }, new { userId }).ToList();
            return vaults;
        }

        internal Vault GetVaultById(int vaultId)
        {
            string sql = @"
            SELECT
            vault.*,
            acct.*
            FROM vaults vault
            JOIN accounts acct ON vault.creatorId = acct.Id
            WHERE vault.id = @vaultId;
            ";

            Vault vault = _db.Query<Vault, Profile, Vault>(sql, (vault, creator) => {
                vault.Creator = creator;
                vault.CreatorId = creator.Id;
                vault.Id = vaultId;
                return vault;
            }, new { vaultId }).FirstOrDefault();
            return vault;
        }

        internal List<Vault> GetVaultsByProfileId(string profileId)
        {
            string sql = @"
            SELECT
            vault.*,
            acct.*
            FROM vaults vault
            JOIN accounts acct ON vault.creatorId = acct.Id
            WHERE vault.creatorId = @profileId AND vault.isPrivate = false;
            ";

            List<Vault> vaults = _db.Query<Vault, Profile, Vault>(sql, (vault, profile) => {
                vault.Creator = profile;
                vault.CreatorId = profile.Id;
                return vault;
            }, new { profileId }).ToList();
            return vaults;
        }
    }
}