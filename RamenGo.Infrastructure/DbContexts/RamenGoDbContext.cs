using Microsoft.EntityFrameworkCore;
using RamenGo.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RamenGo.Infrastructure.DbContexts
{
    public class RamenGoDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<Protein> Proteins { get; set; }
        public DbSet<Broth> Broths { get; set; }

        public RamenGoDbContext(DbContextOptions<RamenGoDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>(e =>
            {
                e.HasOne(o => o.Meal)
                .WithMany(m => m.Orders)
                .HasForeignKey(o => o.MealId);
                e.HasKey(o => o.Id);
            });

            modelBuilder.Entity<Meal>(e =>
            {
                e.HasOne(m => m.Broth)
                .WithMany(b => b.Meals)
                .HasForeignKey(m => m.BrothId);

                e.HasOne(m => m.Protein)
                .WithMany(p => p.Meals)
                .HasForeignKey(m => m.ProteinId);

                e.HasKey(m => m.Id);
            });

            modelBuilder.Entity<Protein>()
                .HasKey(p =>  p.Id);

            modelBuilder.Entity<Broth>()
                .HasKey(b => b.Id);
        }

    }
}
