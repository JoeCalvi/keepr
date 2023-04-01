namespace keepr.Services
{
    public class KeepsService
    {
        private readonly KeepsRepository _repo;

        public KeepsService(KeepsRepository repo)
        {
            _repo = repo;
        }

        internal Keep CreateKeep(Keep keepData)
        {
            Keep keep = _repo.CreateKeep(keepData);
            return keep;
        }

        internal string DeleteKeep(int keepId, string userId)
        {
            Keep keep = this.GetKeepById(keepId);
            if(keep.CreatorId != userId) throw new Exception("This keep does not belong to you.");
            _repo.DeleteKeep(keepId);
            return "Keep deleted.";
        }

        internal Keep EditKeep(Keep keepData, string userId)
        {
            Keep originalKeep = this.GetKeepById(keepData.Id);
            if(originalKeep.CreatorId != userId) throw new Exception("This keep does not belong to you.");
            originalKeep.Name = keepData.Name != null ? keepData.Name : originalKeep.Name;
            originalKeep.Description = keepData.Description != null ? keepData.Description : originalKeep.Description;
            int rowsAffected = _repo.EditKeep(originalKeep);
            if(rowsAffected == 0) throw new Exception($"Could not alter {originalKeep.Name}.");
            if(rowsAffected > 1) throw new Exception("Multiple keeps were edited for some reason. Oops!");
            return originalKeep;
        }

        internal List<Keep> GetAllKeeps()
        {
            List<Keep> keeps = _repo.GetAllKeeps();
            return keeps;
        }

        internal List<Keep> GetKeepsByVaultId(int vaultId)
        {
            List<Keep> keeps = _repo.GetKeepsByVaultId(vaultId);
            return keeps;
        }

        internal Keep GetKeepById(int keepId)
        {
            Keep keep = _repo.GetKeepById(keepId);
            if(keep == null) throw new Exception("Keep not found.");
            keep.Views++;
            return keep;
        }

        internal List<Keep> GetKeepsByProfileId(string profileId)
        {
            List<Keep> keeps = _repo.GetKeepsByProfileId(profileId);
            return keeps;
        }
    }
}