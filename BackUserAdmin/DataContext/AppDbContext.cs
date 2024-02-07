using BackUserAdmin.Models;
using Microsoft.EntityFrameworkCore;

namespace BackUserAdmin.DataContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Models.User>? Users { get; set; }
        public DbSet<Models.Departamento>? Departamentos { get; set; }
        public DbSet<Models.Cargo>? Cargos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(u => u.Departamento)
                .WithMany()
                .HasForeignKey(u => u.IdDepartamento);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Cargo)
                .WithMany()
                .HasForeignKey(u => u.IdCargo);
        }
    }
}
