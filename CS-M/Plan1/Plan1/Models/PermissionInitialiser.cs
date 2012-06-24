using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Plan1.Models
{
    public class PermissionInitialiser : DropCreateDatabaseIfModelChanges<PermissionDBContext>
    {
        protected override void Seed(PermissionDBContext context)
        {
            var permissions = new List<Permission>
            {
                new Permission
                {
                    permType = 010,
                    postalAddr = "Donnybrook",
                    appName = "Murphy",
                    appDate = "12-03-2010", 
                    archName = "Lyons",
                    devDesc = "retention",
                    ownerName = "Murphy",
                    retBldAddr = "Donnybrook",
                    addrDrawer = "Merrion Square"
                },

                new Permission
                {
                    permType = 020,
                    postalAddr = "Donnybrook",
                    appName = "Jones",
                    appDate = "03-06-1995",
                    archName = "Lyons",
                    devDesc = "demolition",
                    ownerName = "Murphy",
                    retBldAddr = "Donnybrook",
                    addrDrawer = "Merrion Square"
                },

                new Permission
                {
                    permType = 030,
                    postalAddr = "Tallaght",
                    appName = "OBrien",
                    appDate = "09-10-2011",
                    archName = "Lyons",
                    devDesc = "new build",
                    ownerName = "Murphy",
                    retBldAddr = "Old Bawn",
                    addrDrawer = "Merrion Square"
                },
                new Permission
                {
                    permType = 020,
                    postalAddr = "Malahide",
                    appName = "Reddy",
                    appDate = "27-09-1998",
                    archName = "Lyons",
                    devDesc = "new build",
                    ownerName = "Reddy",
                    retBldAddr = "Yellow Walls",
                    addrDrawer = "Merrion Square"
                },
            };

            permissions.ForEach(d => context.Permissions.Add(d));
        }
    }
}