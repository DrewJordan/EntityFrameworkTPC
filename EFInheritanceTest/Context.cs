using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFInheritanceTest
{
    public class Context : DbContext
    {
        public DbSet<DataFileParent> DataFileParents { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DataFileEditor>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("DataFileEditor");
            });

            modelBuilder.Entity<DataFileStore>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("DataFileStore");
            });
            
        }
    }

    
}
