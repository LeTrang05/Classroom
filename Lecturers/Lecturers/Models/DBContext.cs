
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity;
using Lecturers.classModel;

namespace Lecturers.Models
{
    public class DBContext : DbContext
    {


        public DBContext() : base("DBContext")
        {
        }

        public DbSet<User> Users { get; set; }  
        
        public DbSet<Class> Classed { get; set; }
        public DbSet<student> Students { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();

        }

        
    }   
}