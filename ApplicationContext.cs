using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness
{
    class DataBasePushUpsContext : DbContext
    {
        public DbSet<DataBasePushUp> DataBasePushUps => Set<DataBasePushUp>();
        public DataBasePushUpsContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=DataBasePushUp.db");
        }
    }
    class DataBasePullUpsContext : DbContext
    {
        public DbSet<DataBasePullUp> DataBasePullUps => Set<DataBasePullUp>();

        public DataBasePullUpsContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=DataBasePullUp.db");
        }
    }
    class DataBaseSitUpsContext : DbContext
    {
        public DbSet<DataBaseSitUp> DataBaseSitUps => Set<DataBaseSitUp>();
        public DataBaseSitUpsContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=DataBaseSitUp.db");
        }
    }

}
