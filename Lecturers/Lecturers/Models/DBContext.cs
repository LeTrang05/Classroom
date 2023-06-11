
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
        public DbSet<ContentClass> ContentClasses { get; set; }
        public DbSet<ClassANDStudent> ClassANDStudents { get; set; }
        public DbSet<ImportListPoint> ImportListPoint { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();

        }

        public System.Data.Entity.DbSet<Lecturers.Models.Comment> Comment { get; set; }

        
    }   
}