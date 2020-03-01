using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministrationSystem
{
    public class GroupHandler
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

        public bool EditGroup(Group group)
        {
            using (AdminContext adminContext = new AdminContext())
            {
                Group group1 = adminContext.Groups.FirstOrDefault(g => g.Id == group.Id);
                group1.Name = group.Name;
                if (CheckExistingGroup(group.Name, adminContext))
                {
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
            if (isChecked == 0) return true;
            return false;
        }

        

        public List<Group> GetGroups()
        {
            using (AdminContext adminContext = new AdminContext())
            {
                return adminContext.Groups.ToList();
            }
        }
    }
}
