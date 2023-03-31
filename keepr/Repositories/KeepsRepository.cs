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
            (creatorId, name, description, img, views, kept)
            VALUES
            (@creatorId, @name, @description, @img, @views, @kept);
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

        internal Keep GetKeepById(int keepId)
        {
            string sql = @"
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
    }
}