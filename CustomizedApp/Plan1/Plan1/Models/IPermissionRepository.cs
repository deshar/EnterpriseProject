using System;
using System.Collections.Generic;

namespace Plan1.Models
{
    public interface IPermissionRepository
    {
        void CreateNewPermission(Permission PermissionToCreate);
        void DeletePermission(int id);
        Permission GetPermissionByID(int id);
        IEnumerable<Permission> GetAllPermissions();
        int SaveChanges();

    }
}
