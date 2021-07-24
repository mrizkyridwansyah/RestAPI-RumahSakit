using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Service.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context
{
    public class LibDbContext : DbContext
    {
        public LibDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Dokter> Dokter { get; set; }
        public DbSet<Pasien> Pasien { get; set; }
        public DbSet<Registrasi> Registrasi { get; set; }
        public DbSet<Diagnosa> Diagnosa { get; set; }
        public DbSet<Tindakan> Tindakan { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Pasien>()
                .HasIndex(u => u.NIK)
                .IsUnique();

            builder.Entity<Registrasi>()
                .HasIndex(u => u.NoRegistrasi)
                .IsUnique();
        }
    }
}
