using Microsoft.EntityFrameworkCore;
using SimpleOrderApp.Domain.Entities;
using SimpleOrderApp.Domain.Entities.Referentials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleOrderApp.Infrastructure.Persistence.Configurations.Seeding
{
    public static class ApplicationDbContextSeed
    {
        public static void SeedStaticData(ModelBuilder modelBuilder)
        {
            SeedRefVehicleType(modelBuilder);
            SeedOrderType(modelBuilder);
            SeedVehicles(modelBuilder);
        }

        private static void SeedRefVehicleType(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RefVehicleType>().HasData
            (
                new RefVehicleType { Id = 1, Name = "Truck" },
                new RefVehicleType { Id = 2, Name = "Minivan" },
                new RefVehicleType { Id = 3, Name = "Sedan" }
            );
        }

        private static void SeedOrderType(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RefOrderType>().HasData
            (
                new RefOrderType { Id = 1, Name = "Vehicles" }
            );
        }

        private static void SeedVehicles(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vehicle>().HasData
            (
                new Vehicle { Make = "Audi", Model = "A4", PricePerDay = 30, TypeId = 3 },
                new Vehicle { Make = "BMW", Model = "3", PricePerDay = 30, TypeId = 3 },
                new Vehicle { Make = "Mercedes", Model = "C", PricePerDay = 30, TypeId = 3 },
                new Vehicle { Make = "Toyota", Model = "Corolla", PricePerDay = 20, TypeId = 3 },
                new Vehicle { Make = "Volkswagen", Model = "Golf", PricePerDay = 20, TypeId = 3 },
                new Vehicle { Make = "Ford", Model = "Transit", PricePerDay = 35, TypeId = 2 },
                new Vehicle { Make = "Volswagen", Model = "Transporter", PricePerDay = 35, TypeId = 2 },
                new Vehicle { Make = "Toyota", Model = "Hilux", PricePerDay = 35, TypeId = 1 },
                new Vehicle { Make = "Volswagen", Model = "Amarok", PricePerDay = 35, TypeId = 1 }
            );
        }
    }
}
