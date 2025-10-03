using EVChargingStationManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVChargingStationManagementSystem.Infrastructure
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) { }

        public DbSet<ChargingConnectorType> ChargingConnectorTypes { get; set; }
        public DbSet<ChargingPoint> ChargingPoints { get; set; }
        public DbSet<ChargingSession> ChargingSessions { get; set; }
        public DbSet<ChargingStation> ChargingStations { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleManufacturer> VehicleManufacturers { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            modelBuilder.Entity<ChargingSession>()
                .HasOne(cs => cs.Vehicle)
                .WithMany(v => v.ChargingSessions)
                .HasForeignKey(cs => cs.VehicleId)
                .OnDelete(DeleteBehavior.Restrict); // Không cascade từ Vehicle

            modelBuilder.Entity<ChargingSession>()
                .HasOne(cs => cs.ChargingPoint)
                .WithMany(cp => cp.ChargingSessions)
                .HasForeignKey(cs => cs.ChargingPointId)
                .OnDelete(DeleteBehavior.Cascade); // Cho cascade từ ChargingPoint

            modelBuilder.Entity<VehicleType>().HasData(
                new VehicleType
                {
                    Id = Guid.Parse("0cfa2088-7d48-4507-b2c3-20008ff16c0f"),
                    Name = "Sedan"
                },
                new VehicleType
                {
                    Id = Guid.Parse("7a43952a-8cac-4007-a29b-241258e75fdb"),
                    Name = "Coupe"
                },
                new VehicleType
                {
                    Id = Guid.Parse("5e23fc0f-6c10-4ed9-9d7a-027a8482deec"),
                    Name = "SUV"
                },
                new VehicleType
                {
                    Id = Guid.Parse("76a6deb3-9bed-4aac-8c7f-4d8b601ed92c"),
                    Name = "Hatchback"
                },
                new VehicleType
                {
                    Id = Guid.Parse("87953815-d78b-450e-a822-1b5e06f6c63e"),
                    Name = "Crossover"
                }
            );

            modelBuilder.Entity<VehicleManufacturer>().HasData(
                new VehicleManufacturer
                {
                    Id = Guid.Parse("131372a7-6dd7-454a-9a62-ce7ce60ecb01"),
                    Name = "Tesla"
                },
                new VehicleManufacturer
                {
                    Id = Guid.Parse("79d6cfdc-2054-4d4c-a2c5-b09747c42cf3"),
                    Name = "BYD"
                },
                new VehicleManufacturer
                {
                    Id = Guid.Parse("8002aad2-b699-4279-a325-50a8d5e4ba4b"),
                    Name = "VinFast"
                },
                new VehicleManufacturer
                {
                    Id = Guid.Parse("d3463c43-7537-473f-8907-e6b322f395df"),
                    Name = "Hyundai"
                },
                new VehicleManufacturer
                {
                    Id = Guid.Parse("77f872cc-fea2-4b70-a468-ee400ad762b6"),
                    Name = "Kia"
                }
            );

            modelBuilder.Entity<ChargingConnectorType>().HasData(
                new ChargingConnectorType
                {
                    Id = Guid.Parse("7fb07369-1c30-4af5-b631-ef4e7f071705"),
                    Name = "Type 1 (SAE J1772)",
                    Standard = ChargingStandard.AC
                },
                new ChargingConnectorType
                {
                    Id = Guid.Parse("769deda0-e45b-4532-ac2a-0f3253e84e88"),
                    Name = "Type 2 (Mennekes)",
                    Standard = ChargingStandard.AC
                },
                new ChargingConnectorType
                {
                    Id = Guid.Parse("78f1e5f9-82f0-4466-b844-c26cb024433c"),
                    Name = "GB/T AC",
                    Standard = ChargingStandard.AC
                },
                new ChargingConnectorType
                {
                    Id = Guid.Parse("12f8c15e-b19b-4272-b240-19ac766e6bea"),
                    Name = "GB/T DC",
                    Standard = ChargingStandard.DC
                },
                new ChargingConnectorType
                {
                    Id = Guid.Parse("e0b122a1-022f-4988-b089-e59636b61a31"),
                    Name = "CHAdeMO",
                    Standard = ChargingStandard.DC
                },
                new ChargingConnectorType
                {
                    Id = Guid.Parse("9f0249ad-a5d4-48d8-8718-624a361ddb5f"),
                    Name = "CCS1",
                    Standard = ChargingStandard.DC
                },
                new ChargingConnectorType
                {
                    Id = Guid.Parse("44110d58-4e2c-4c53-965a-1e45e7953304"),
                    Name = "CCS2",
                    Standard = ChargingStandard.DC
                }
            );

            foreach (var entity in modelBuilder.Model.GetEntityTypes()) 
            {
                var tableName = entity.GetTableName() ?? entity.ClrType.Name;
                entity.SetTableName(ToSnakeCase(tableName));

                foreach (var property in entity.GetProperties())
                {
                    property.SetColumnName(ToSnakeCase(property.Name));
                }

                foreach (var key in entity.GetKeys())
                {
                    var keyName = key.GetName();
                    if (!string.IsNullOrEmpty(keyName))
                    {
                        key.SetName(ToSnakeCase(keyName));
                    }
                }

                foreach (var foreignKey in entity.GetForeignKeys())
                {
                    var fkName = foreignKey.GetConstraintName();
                    if (!string.IsNullOrEmpty(fkName))
                    {
                        foreignKey.SetConstraintName(ToSnakeCase(fkName));
                    }
                }

                foreach (var index in entity.GetIndexes())
                {
                    var indexName = index.GetDatabaseName();
                    if (!string.IsNullOrEmpty(indexName))
                    {
                        index.SetDatabaseName(ToSnakeCase(indexName));
                    }
                }
            }
        }


        /// <summary>
        /// Convert a PascalCase/CamelCase string to snake_case.
        /// Handles acronyms reasonably (e.g., "HTMLParser" -> "html_parser").
        /// </summary>
        private static string ToSnakeCase(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            var sb = new StringBuilder();
            var previousCategory = default(UnicodeCategory?);

            for (int i = 0; i < input.Length; i++)
            {
                var c = input[i];
                if (char.IsWhiteSpace(c))
                {
                    if (sb.Length > 0 && sb[^1] != '_') sb.Append('_');
                    previousCategory = null;
                    continue;
                }

                var currentCategory = char.GetUnicodeCategory(c);

                // If uppercase and not the first char, and previous is lower or previous is space,
                // insert underscore. Also handle transitions like "XMLHttp" => "xml_http"
                if (char.IsUpper(c))
                {
                    if (i > 0 && previousCategory != UnicodeCategory.SpaceSeparator &&
                        previousCategory != null &&
                        (previousCategory == UnicodeCategory.LowercaseLetter ||
                         previousCategory == UnicodeCategory.DecimalDigitNumber))
                    {
                        sb.Append('_');
                    }
                    else if (i > 0 && previousCategory == UnicodeCategory.UppercaseLetter)
                    {
                        // If next is lowercase, this is end of acronym: "HTMLParser" -> "html_parser"
                        if (i + 1 < input.Length && char.IsLower(input[i + 1]))
                            sb.Append('_');
                    }

                    sb.Append(char.ToLowerInvariant(c));
                }
                else
                {
                    // normal lowercase or digit or others
                    if (c == '-')
                    {
                        sb.Append('_');
                    }
                    else
                    {
                        sb.Append(c);
                    }
                }

                previousCategory = currentCategory;
            }

            // remove leading/trailing underscores (just in case)
            var result = sb.ToString().Trim('_');

            return result;
        }
    }
}
