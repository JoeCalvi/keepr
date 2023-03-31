namespace keepr.Repositories
{
    public class VaultkeepsRepository
    {
        private readonly IDbConnection _db;

        public VaultkeepsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal VaultKeep CreateVaultKeep(VaultKeep vaultKeepData)
        {
            string sql = @"
            INSERT INTO vaultkeeps
            (creatorId, vaultId, keepId)
            VALUES
            (@creatorId, @vaultId, @keepId);
            SELECT LAST_INSERT_ID();
            ";

            int id = _db.ExecuteScalar<int>(sql, vaultKeepData);
            vaultKeepData.Id = id;
            return vaultKeepData;
        }

        internal void DeleteVaultKeep(int vaultKeepId)
        {
            string sql = @"
            DELETE FROM vaultkeeps
            WHERE id = @vaultKeepId;
            ";

            _db.Execute(sql, new { vaultKeepId });
        }

        internal VaultKeep GetVaultKeepById(int vaultKeepId)
        {
            string sql = @"
            SELECT
            *
            FROM vaultkeeps
            WHERE id = @vaultKeepId
            ";

            VaultKeep vaultKeep = _db.Query<VaultKeep>(sql, new { vaultKeepId }).FirstOrDefault();
            return vaultKeep;
        }
    }
}