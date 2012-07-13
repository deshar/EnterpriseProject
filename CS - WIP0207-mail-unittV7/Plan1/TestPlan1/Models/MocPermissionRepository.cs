using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Plan1.Models;

namespace TestPlan1.Models
{
    class InMemoryPermissionRepository : Plan1.Models.IPermissionRepository
    {
        private List<Permission> _db = new List<Permission>();

        public Exception ExceptionToThrow { get; set; }
        //public List<Permission> Items { get; set; }

        public void SaveChanges(Permission PermissionToUpdate)
        {

            foreach (Permission Permission in _db)
            {
                if (Permission.Id == PermissionToUpdate.Id)
                {
                    _db.Remove(Permission);
                    _db.Add(PermissionToUpdate);
                    break;
                }
            }
        }

        public void Add(Permission PermissionToAdd)
        {
            _db.Add(PermissionToAdd);
        }

        public Permission GetPermissionByID(int id)
        {
            return _db.FirstOrDefault(d => d.Id == id);
        }

        public void CreateNewPermission(Permission PermissionToCreate)
        {
            if (ExceptionToThrow != null)
                throw ExceptionToThrow;

            _db.Add(PermissionToCreate);
            // return PermissionToCreate;
        }

        public int SaveChanges()
        {
            return 1;
        }

        public IEnumerable<Permission> GetAllPermissions()
        {
            return _db.ToList();
        }


        public void DeletePermission(int id)
        {
            _db.Remove(GetPermissionByID(id));
        }

    }
} 

