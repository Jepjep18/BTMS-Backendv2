using Microsoft.EntityFrameworkCore;
using api.Models;
using Microsoft.AspNetCore.Identity;
using System;

namespace api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

           
            var adminUser = new User
            {
                Id = 1,
                FirstName = "Admin",
                MiddleName = "Admin",  
                LastName = "User",
                Role = "Admin",
                Username = "000-001",
                BusinessUnit = "ABFI Central",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("Admin@123"),
                DateCreated = DateTime.Now
            };

            var faipWarehouse = new User
            {
                Id = 2,
                FirstName = "Warehouse",
                MiddleName = "Test",
                LastName = "User",
                Role = "FAIPwarehouse",
                Username = "000-002",
                BusinessUnit = "FAIP",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("@Temp123"),
                DateCreated = DateTime.Now
            };

            var faipAdmin = new User
            {
                Id = 3,
                FirstName = "FAIP",
                MiddleName = "Admin",
                LastName = "User",
                Role = "FAIPadmin",
                Username = "000-003",
                BusinessUnit = "FAIP",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("@Temp123"),
                DateCreated = DateTime.Now
            };

            var businessUnit = new User
            {
                Id = 4,
                FirstName = "Business",
                MiddleName = "Unit",
                LastName = "User",
                Role = "BusinessUnit",
                Username = "000-004",
                BusinessUnit = "SubZero",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("@Temp123"),
                DateCreated = DateTime.Now
            };
            modelBuilder.Entity<BusinessUnit>().HasData(
                new BusinessUnit {Id = 1, BusinessunitName = "ABFI Central", BusinessunitDescription = "Ana's Breeders Farm Central Office", BusinessLocation = "Binugao, Toril, Davao City" },
                new BusinessUnit {Id = 2, BusinessunitName = "SFC", BusinessunitDescription = "SouthMin FeedMill Unit", BusinessLocation = "Binugao, Toril, Davao City" },
                new BusinessUnit {Id = 3, BusinessunitName = "GSII", BusinessunitDescription = "GSII Unit", BusinessLocation = "Davao City"},
                new BusinessUnit {Id = 4, BusinessunitName = "SubZero", BusinessunitDescription = "SubZero Unit", BusinessLocation = "Binugao, Toril, Davao City" },
                new BusinessUnit {Id = 5, BusinessunitName = "JPPI", BusinessunitDescription = "JPPI Unit", BusinessLocation = "Dumoy, Toril, Davao City"},
                new BusinessUnit {Id = 6, BusinessunitName = "QPMI", BusinessunitDescription = "QPMI Unit", BusinessLocation = "Lanang, Davao City"},
                new BusinessUnit {Id = 7, BusinessunitName = "FAIP", BusinessunitDescription = "FAIP Unit", BusinessLocation = "FAIP Complex, Biao, Tugbok District, Davao City" });
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "FAIPadmin", Description = "Admin role for FAIP" },
                new Role { Id = 2, Name = "FAIPwarehouse", Description = "Warehouse role for FAIP" },
                new Role { Id = 3, Name = "BusinessUnit", Description = "Business Unit role" },
                new Role { Id = 4, Name = "Admin", Description= "Super Admin Role"});

            modelBuilder.Entity<User>().HasData(adminUser, faipWarehouse, faipAdmin, businessUnit);

            // Other model relationships
            modelBuilder.Entity<BatteryReleasing>()
              .HasMany(b => b.BatteryTransfer)
              .WithOne(bt => bt.BatteryReleasing)
              .HasForeignKey(bt => bt.ReleasingId)
              .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<BatteryReceiving>()
                .HasOne(b => b.BatteryReleasing)
                .WithOne(br => br.BReceiving)
                .HasForeignKey<BatteryReleasing>(br => br.BatteryId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<BatteryReceiving>()
                .HasOne(b => b.BatteryReturn)
                .WithOne(br => br.BReceiving)
                .HasForeignKey<BatteryReturn>(br => br.BatteryId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<TireReleasing>()
                .HasMany(t => t.TireTransfer)
                .WithOne(tt => tt.TireReleasing)
                .HasForeignKey(tt => tt.ReleasingId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<TireReceiving>()
                .HasOne(t => t.TireReleasing)
                .WithOne(tr => tr.TReceiving)
                .HasForeignKey<TireReleasing>(tr => tr.TireId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<TireReceiving>()
                .HasOne(t => t.TireReturn)
                .WithOne(tr => tr.TReceiving)
                .HasForeignKey<TireReturn>(tr => tr.TireId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<TireReturn>()
                .HasOne(tr => tr.TireRecap)
                .WithOne(trc => trc.TireReturn)
                .HasForeignKey<TireRecap>(trc => trc.TireReturnId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<TireReturn>()
                .HasOne(td => td.TireDisposal)
                .WithOne(trc => trc.TireReturn)
                .HasForeignKey<TireDisposal>(trc => trc.TireReturnId)
                .OnDelete(DeleteBehavior.Cascade);


        }

        public DbSet<BatteryReceiving>? BatteryReceiving { get; set; }
        public DbSet<BatteryReleasing>? BatteryReleasing { get; set; }
        public DbSet<BatteryReturn>? BatteryReturn { get; set; }
        public DbSet<BusinessUnit>? BusinessUnit { get; set; }
        public DbSet<TireReceiving>? TireReceiving { get; set; }
        public DbSet<TireReleasing>? TireReleasing { get; set; }
        public DbSet<TireReturn>? TireReturn { get; set; }
        public DbSet<BatteryTransfer>? BatteryTransfer { get; set; }
        public DbSet<TireTransfer>? TireTransfer { get; set; }
        public DbSet<TireRecap>? TireRecap { get; set; }  
        public DbSet<TireDisposal>? TireDisposal { get; set; }

        public DbSet<User>? User { get; set; }
        public DbSet<Role>? Role { get; set; }
    }
}
