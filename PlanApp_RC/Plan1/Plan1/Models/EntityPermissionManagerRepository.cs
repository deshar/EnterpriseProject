using System.Collections.Generic;
using System.Linq;

namespace Plan1.Models
{
    public class EF_PermissionRepository : Plan1.Models.IPermissionRepository
    {

        private PermissionDBContext _db = new PermissionDBContext();

        public Permission GetPermissionByID(int id)
        {
            return _db.Permissions.FirstOrDefault(d => d.Id == id);
        }

        public IEnumerable<Permission> GetAllPermissions()
        {
            return _db.Permissions.ToList();
        }

        public void CreateNewPermission(Permission PermissionToCreate)
        {
            _db.Permissions.Add(PermissionToCreate);
            _db.SaveChanges();
            //   return PermissionToCreate;
        }

        public int SaveChanges()
        {
            return _db.SaveChanges();
        }

        public void DeletePermission(int id)
        {
            var conToDel = GetPermissionByID(id);
            _db.Permissions.Remove(conToDel);
            _db.SaveChanges();
        }

    }
}
