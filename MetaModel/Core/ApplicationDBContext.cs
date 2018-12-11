using MetaModel.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaModel.Core
{
    class ApplicationDBContext: DbContext
    {
        public virtual DbSet<Entities.Value> Values { get; set; }

        public virtual DbSet<Entities.Attribute> Attributes { get; set; }

        public virtual DbSet<Entities.Type> Types { get; set; }

        public virtual DbSet<Entities.Object> Objects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=metamodel;Username=metamodel;Password=metamodel");
        }
    }
}
