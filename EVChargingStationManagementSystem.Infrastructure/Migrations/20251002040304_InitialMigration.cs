using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EVChargingStationManagementSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "charging_connector_types",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    standard = table.Column<int>(type: "int", nullable: false),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_charging_connector_types", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "charging_stations",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    longtitude = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    latitude = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: false),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_charging_stations", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phone_number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "vehicle_manufacturers",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vehicle_manufacturers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "vehicle_types",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vehicle_types", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "charging_points",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    port_number = table.Column<int>(type: "int", nullable: false),
                    power_output = table.Column<int>(type: "int", nullable: false),
                    pricing_type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pricing_rate = table.Column<int>(type: "int", nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: false),
                    charging_connector_type_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    charging_station_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_charging_points", x => x.id);
                    table.ForeignKey(
                        name: "fk_charging_points_charging_connector_types_charging_connector_type_id",
                        column: x => x.charging_connector_type_id,
                        principalTable: "charging_connector_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_charging_points_charging_stations_charging_station_id",
                        column: x => x.charging_station_id,
                        principalTable: "charging_stations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vehicles",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    license_plate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    year_of_manufacture = table.Column<int>(type: "int", nullable: false),
                    battery_capacity = table.Column<int>(type: "int", nullable: false),
                    battery_percentage = table.Column<int>(type: "int", nullable: false),
                    charging_rate = table.Column<int>(type: "int", nullable: false),
                    last_charged_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    vehicle_type_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    vehicle_manufacturer_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    charging_connector_type_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vehicles", x => x.id);
                    table.ForeignKey(
                        name: "fk_vehicles_charging_connector_types_charging_connector_type_id",
                        column: x => x.charging_connector_type_id,
                        principalTable: "charging_connector_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_vehicles_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_vehicles_vehicle_manufacturers_vehicle_manufacturer_id",
                        column: x => x.vehicle_manufacturer_id,
                        principalTable: "vehicle_manufacturers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_vehicles_vehicle_types_vehicle_type_id",
                        column: x => x.vehicle_type_id,
                        principalTable: "vehicle_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "charging_sessions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    vehicle_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    charging_point_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    starting_timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ending_timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    energy_consumed = table.Column<int>(type: "int", nullable: false),
                    charging_cost = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_charging_sessions", x => x.id);
                    table.ForeignKey(
                        name: "fk_charging_sessions_charging_points_charging_point_id",
                        column: x => x.charging_point_id,
                        principalTable: "charging_points",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_charging_sessions_vehicles_vehicle_id",
                        column: x => x.vehicle_id,
                        principalTable: "vehicles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "charging_connector_types",
                columns: new[] { "id", "is_deleted", "name", "standard" },
                values: new object[,]
                {
                    { new Guid("12f8c15e-b19b-4272-b240-19ac766e6bea"), false, "GB/T DC", 1 },
                    { new Guid("44110d58-4e2c-4c53-965a-1e45e7953304"), false, "CCS2", 1 },
                    { new Guid("769deda0-e45b-4532-ac2a-0f3253e84e88"), false, "Type 2 (Mennekes)", 0 },
                    { new Guid("78f1e5f9-82f0-4466-b844-c26cb024433c"), false, "GB/T AC", 0 },
                    { new Guid("7fb07369-1c30-4af5-b631-ef4e7f071705"), false, "Type 1 (SAE J1772)", 0 },
                    { new Guid("9f0249ad-a5d4-48d8-8718-624a361ddb5f"), false, "CCS1", 1 },
                    { new Guid("e0b122a1-022f-4988-b089-e59636b61a31"), false, "CHAdeMO", 1 }
                });

            migrationBuilder.InsertData(
                table: "vehicle_manufacturers",
                columns: new[] { "id", "is_deleted", "name" },
                values: new object[,]
                {
                    { new Guid("131372a7-6dd7-454a-9a62-ce7ce60ecb01"), false, "Tesla" },
                    { new Guid("77f872cc-fea2-4b70-a468-ee400ad762b6"), false, "Kia" },
                    { new Guid("79d6cfdc-2054-4d4c-a2c5-b09747c42cf3"), false, "BYD" },
                    { new Guid("8002aad2-b699-4279-a325-50a8d5e4ba4b"), false, "VinFast" },
                    { new Guid("d3463c43-7537-473f-8907-e6b322f395df"), false, "Hyundai" }
                });

            migrationBuilder.InsertData(
                table: "vehicle_types",
                columns: new[] { "id", "is_deleted", "name" },
                values: new object[,]
                {
                    { new Guid("0cfa2088-7d48-4507-b2c3-20008ff16c0f"), false, "Sedan" },
                    { new Guid("5e23fc0f-6c10-4ed9-9d7a-027a8482deec"), false, "SUV" },
                    { new Guid("76a6deb3-9bed-4aac-8c7f-4d8b601ed92c"), false, "Hatchback" },
                    { new Guid("7a43952a-8cac-4007-a29b-241258e75fdb"), false, "Coupe" },
                    { new Guid("87953815-d78b-450e-a822-1b5e06f6c63e"), false, "Crossover" }
                });

            migrationBuilder.CreateIndex(
                name: "ix_charging_points_charging_connector_type_id",
                table: "charging_points",
                column: "charging_connector_type_id");

            migrationBuilder.CreateIndex(
                name: "ix_charging_points_charging_station_id",
                table: "charging_points",
                column: "charging_station_id");

            migrationBuilder.CreateIndex(
                name: "ix_charging_sessions_charging_point_id",
                table: "charging_sessions",
                column: "charging_point_id");

            migrationBuilder.CreateIndex(
                name: "ix_charging_sessions_vehicle_id",
                table: "charging_sessions",
                column: "vehicle_id");

            migrationBuilder.CreateIndex(
                name: "ix_vehicles_charging_connector_type_id",
                table: "vehicles",
                column: "charging_connector_type_id");

            migrationBuilder.CreateIndex(
                name: "ix_vehicles_user_id",
                table: "vehicles",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_vehicles_vehicle_manufacturer_id",
                table: "vehicles",
                column: "vehicle_manufacturer_id");

            migrationBuilder.CreateIndex(
                name: "ix_vehicles_vehicle_type_id",
                table: "vehicles",
                column: "vehicle_type_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "charging_sessions");

            migrationBuilder.DropTable(
                name: "charging_points");

            migrationBuilder.DropTable(
                name: "vehicles");

            migrationBuilder.DropTable(
                name: "charging_stations");

            migrationBuilder.DropTable(
                name: "charging_connector_types");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "vehicle_manufacturers");

            migrationBuilder.DropTable(
                name: "vehicle_types");
        }
    }
}
