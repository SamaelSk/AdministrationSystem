using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministrationSystem
{
    public class GroupCreator
    {
        public bool AddGroup(string name)
        {
            Group group = new Group
            {
                Name = name
            };

            using (AdminContext adminContext = new AdminContext())
            {
                if (CheckExistingGroup(name, adminContext))
                {
                    adminContext.Groups.Add(group);
                    adminContext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        private bool CheckExistingGroup(string name, AdminContext adminContext)
        {
            var isChecked = adminContext.Groups.Count(group => group.Name.Equals(name));
            if (isChecked > 0) return true;
            return false;
        }
    }
}
