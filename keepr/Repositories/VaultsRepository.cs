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
    }
}