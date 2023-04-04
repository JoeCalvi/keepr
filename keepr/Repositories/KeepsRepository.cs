namespace keepr.Repositories
{
    public class KeepsRepository
    {
        private readonly IDbConnection _db;

        public KeepsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal Keep CreateKeep(Keep keepData)
        {
            string sql = @"
            INSERT INTO keeps
            (creatorId, name, description, img, views, kept, vaultKeepId)
            VALUES
            (@creatorId, @name, @description, @img, @views, @kept, @vaultKeepId);
            SELECT LAST_INSERT_ID();
            ";

            int id = _db.ExecuteScalar<int>(sql, keepData);
            keepData.Id = id;
            return keepData;
        }

        internal void DeleteKeep(int keepId)
        {
            string sql = @"
            DELETE FROM keeps
            WHERE id = @keepId;
            ";

            _db.Execute(sql, new { keepId });
        }

        internal int EditKeep(Keep updatedKeep)
        {
            string sql = @"
            UPDATE keeps
            SET
            name = @name,
            description = @description
            WHERE id = @id;
            ";

            int rows = _db.Execute(sql, updatedKeep);
            return rows;
        }

        internal List<Keep> GetAllKeeps()
        {
            string sql = @"
            SELECT
            keep.*,
            acct.*
            FROM keeps keep
            JOIN accounts acct ON keep.creatorId = acct.id;
            ";

            List<Keep> keeps = _db.Query<Keep, Profile, Keep>(sql, (keep, creator) => {
                keep.Creator = creator;
                return keep;
            }).ToList();
            return keeps;
        }

        internal List<Keep> GetKeepsByVaultId(int vaultId)
        {
            string sql = @"
            SELECT
            keep.*,
            vk.*,
            acct.*
            FROM keeps keep
            JOIN vaultkeeps vk ON keep.id = vk.keepId
            JOIN accounts acct ON keep.creatorId = acct.id
            WHERE vk.vaultId = @vaultId;
            ";

            List<Keep> keeps = _db.Query<Keep, VaultKeep, Profile, Keep>(sql, (keep, vaultkeep, creator) => {
                keep.CreatorId = creator.Id;
                keep.Creator = creator;
                keep.Id = vaultkeep.KeepId;
                keep.VaultKeepId = vaultkeep.Id;
                return keep;
            }, new { vaultId }).ToList();
            return keeps;
        }

        internal Keep GetKeepById(int keepId)
        {
            string sql = @"
            UPDATE keeps keep
            SET keep.views = keep.views + 1
            WHERE keep.id = @keepId;

            SELECT 
            keep.*,
            acct.*
            FROM keeps keep
            JOIN accounts acct ON keep.creatorId = acct.id
            WHERE keep.id = @keepId;

            ";

            Keep keep = _db.Query<Keep, Profile, Keep>(sql, (keep, creator) => {
                keep.Creator = creator;
                keep.CreatorId = creator.Id;
                return keep;
            }, new { keepId }).FirstOrDefault();
            return keep;
        }

        internal List<Keep> GetKeepsByProfileId(object profileId)
        {
            string sql = @"
            SELECT
            keep.*,
            acct.*
            FROM keeps keep
            JOIN accounts acct ON keep.creatorId = acct.id
            WHERE keep.creatorId = @profileId;
            ";

            List<Keep> keeps = _db.Query<Keep, Profile, Keep>(sql, (keep, profile) => {
                keep.Creator = profile;
                keep.CreatorId = profile.Id;
                return keep;
            }, new { profileId }).ToList();
            return keeps;
        }
    }
}