using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace AdministrationSystem
{
    public class AdminContext : DbContext
    {
        public AdminContext()
            : base("DbConnection")
        { }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<StudentSubscription> StudentSubscriptions { get; set; }

    }
}
