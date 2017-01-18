using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcDemo.Demo3.Models
{
    public class StudentContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        public StudentContext()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<StudentContext>());
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<StudentContext>());
            Database.SetInitializer(new DropCreateDatabaseAlways<StudentContext>());
        }
    }
}