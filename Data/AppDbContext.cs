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
                BusinessUnit = "Cisdevo",
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
                BusinessUnit = "Logistics and Warehouse",
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
                BusinessUnit = "FAIP Admin",
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
                BusinessUnit = "Subzero",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("@Temp123"),
                DateCreated = DateTime.Now
            };
            modelBuilder.Entity<BusinessUnit>().HasData(
                new BusinessUnit { Id = 1, BusinessunitName = "Executive", BusinessunitDescription = "Executive Office Ana's Breeders Farm Central Office", BusinessLocation = "To be added" },
                new BusinessUnit { Id = 2, BusinessunitName = "FEM", BusinessunitDescription = "To be added", BusinessLocation = "To be added" },
                new BusinessUnit { Id = 3, BusinessunitName = "PO - Cenlo", BusinessunitDescription = "To be added", BusinessLocation = "To be added" },
                new BusinessUnit { Id = 4, BusinessunitName = "PO - Broiler", BusinessunitDescription = "To be added", BusinessLocation = "To be added" },
                new BusinessUnit { Id = 5, BusinessunitName = "PO - Breeder", BusinessunitDescription = "To be added", BusinessLocation = "To be added" },
                new BusinessUnit { Id = 6, BusinessunitName = "PO - Hatchery", BusinessunitDescription = "To be added", BusinessLocation = "To be added" },
                new BusinessUnit { Id = 7, BusinessunitName = "CAO", BusinessunitDescription = "To be added", BusinessLocation = "To be added" },
                new BusinessUnit { Id = 8, BusinessunitName = "Cisdevo", BusinessunitDescription = "To be added", BusinessLocation = "To be added" },
                new BusinessUnit { Id = 9, BusinessunitName = "Subzero", BusinessunitDescription = "To be added", BusinessLocation = "To be added" },
                new BusinessUnit { Id = 10, BusinessunitName = "Sales - ABFI", BusinessunitDescription = "To be added", BusinessLocation = "To be added" },
                new BusinessUnit { Id = 11, BusinessunitName = "PED - Planning", BusinessunitDescription = "To be added", BusinessLocation = "To be added" },
                new BusinessUnit { Id = 12, BusinessunitName = "PED - Project", BusinessunitDescription = "To be added", BusinessLocation = "To be added" },
                new BusinessUnit { Id = 13, BusinessunitName = "SFC", BusinessunitDescription = "To be added", BusinessLocation = "To be added" },
                new BusinessUnit { Id = 14, BusinessunitName = "Sales - QP/SCC", BusinessunitDescription = "To be added", BusinessLocation = "To be added" },
                new BusinessUnit { Id = 15, BusinessunitName = "JPPI", BusinessunitDescription = "To be added", BusinessLocation = "To be added" },
                new BusinessUnit { Id = 16, BusinessunitName = "Research and Development", BusinessunitDescription = "To be added", BusinessLocation = "To be added" },
                new BusinessUnit { Id = 17, BusinessunitName = "GSII - Blown Film", BusinessunitDescription = "To be added", BusinessLocation = "To be added" },
                new BusinessUnit { Id = 18, BusinessunitName = "GSII - Recycling", BusinessunitDescription = "To be added", BusinessLocation = "To be added" },
                new BusinessUnit { Id = 19, BusinessunitName = "GSII - CHB/Ula", BusinessunitDescription = "To be added", BusinessLocation = "To be added" },
                new BusinessUnit { Id = 20, BusinessunitName = "HR FAIP", BusinessunitDescription = "To be added", BusinessLocation = "To be added" },
                new BusinessUnit { Id = 21, BusinessunitName = "FAIP Admin", BusinessunitDescription = "To be added", BusinessLocation = "To be added" },
                new BusinessUnit { Id = 22, BusinessunitName = "Dressing Plant", BusinessunitDescription = "To be added", BusinessLocation = "To be added" },
                new BusinessUnit { Id = 23, BusinessunitName = "QA Department", BusinessunitDescription = "To be added", BusinessLocation = "To be added" },
                new BusinessUnit { Id = 24, BusinessunitName = "Procurement", BusinessunitDescription = "To be added", BusinessLocation = "To be added" },
                new BusinessUnit { Id = 25, BusinessunitName = "Logistics and Warehouse", BusinessunitDescription = "To be added", BusinessLocation = "To be added" },
                new BusinessUnit { Id = 26, BusinessunitName = "Motor Pool", BusinessunitDescription = "To be added", BusinessLocation = "To be added" },
                new BusinessUnit { Id = 27, BusinessunitName = "SCC", BusinessunitDescription = "To be added", BusinessLocation = "To be added" });
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "FAIPadmin", Description = "Admin role for FAIP" },
                new Role { Id = 2, Name = "FAIPwarehouse", Description = "Warehouse role for FAIP" },
                new Role { Id = 3, Name = "BusinessUnit", Description = "Business Unit role" },
                new Role { Id = 4, Name = "Admin", Description = "Super Admin Role" });

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