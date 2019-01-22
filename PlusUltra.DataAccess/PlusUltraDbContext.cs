using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlusUltraDB.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace PlusUltra.DataAccess
{
    public class PlusUltraDbContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Organization> Organizations { get; set; }

        public PlusUltraDbContext()
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) //method that prevents table names to be pluralized
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }


}
