using Microsoft.EntityFrameworkCore;
using PruebaCUB_API.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace PruebaCUB_API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Usuario>().HasIndex(c => c.Id).IsUnique();
        }
    }
}
