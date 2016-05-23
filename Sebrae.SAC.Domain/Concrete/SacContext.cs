using SAC_.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAC_.Domain.Concrete
{
    public class SacContext : DbContext
    {
        public SacContext()
            : base("name=NovoSAC")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<SacContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}