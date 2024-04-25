using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Service.Migrations
{
    /// <inheritdoc />
    public partial class addprofile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Company_CompanyID",
                schema: "Order",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAction_User_UserID",
                schema: "User",
                table: "UserAction");

            migrationBuilder.DropTable(
                name: "CompanyDay",
                schema: "DataWarehouse");

            migrationBuilder.DropTable(
                name: "RiderLog",
                schema: "Rider");

            migrationBuilder.DropTable(
                name: "StoreDay",
                schema: "DataWarehouse");

            migrationBuilder.DropTable(
                name: "TeamDay",
                schema: "DataWarehouse");

            migrationBuilder.DropTable(
                name: "TripLog",
                schema: "Trip");

            migrationBuilder.DropTable(
                name: "Company",
                schema: "Client");

            migrationBuilder.DropTable(
                name: "Store",
                schema: "Client");

            migrationBuilder.DropTable(
                name: "Trip",
                schema: "Trip");

            migrationBuilder.DropTable(
                name: "Rider",
                schema: "Rider");

            migrationBuilder.DropTable(
                name: "Team",
                schema: "Client");

            migrationBuilder.DropIndex(
                name: "IX_Order_CompanyID",
                schema: "Order",
                table: "Order");

            migrationBuilder.EnsureSchema(
                name: "Profile");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                schema: "User",
                table: "UserAction",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateTable(
                name: "Profile",
                schema: "Profile",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CompanyID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profile", x => x.ID);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_UserAction_User_UserID",
                schema: "User",
                table: "UserAction",
                column: "UserID",
                principalSchema: "User",
                principalTable: "User",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAction_User_UserID",
                schema: "User",
                table: "UserAction");

            migrationBuilder.DropTable(
                name: "Profile",
                schema: "Profile");

            migrationBuilder.EnsureSchema(
                name: "Client");

            migrationBuilder.EnsureSchema(
                name: "DataWarehouse");

            migrationBuilder.EnsureSchema(
                name: "Rider");

            migrationBuilder.EnsureSchema(
                name: "Trip");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                schema: "User",
                table: "UserAction",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Company",
                schema: "Client",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CompanyID = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReferanceID = table.Column<int>(type: "int", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.ID);
                    table.UniqueConstraint("AK_Company_ReferanceID", x => x.ReferanceID);
                });

            migrationBuilder.CreateTable(
                name: "Store",
                schema: "Client",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyID = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Store", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Team",
                schema: "Client",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyID = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CompanyDay",
                schema: "DataWarehouse",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CompanyID1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    AbuseOrdersCount = table.Column<int>(type: "int", nullable: false),
                    AbuseTrips = table.Column<int>(type: "int", nullable: false),
                    ArriveToPickupDuration = table.Column<int>(type: "int", nullable: false),
                    CanceledOrdersCount = table.Column<int>(type: "int", nullable: false),
                    CompanyID = table.Column<int>(type: "int", nullable: false),
                    CompanyReferanceNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Date = table.Column<DateTime>(type: "Date", nullable: false),
                    ExcellentTrips = table.Column<int>(type: "int", nullable: false),
                    ExcllentOrdersCount = table.Column<int>(type: "int", nullable: false),
                    FastOrdersCount = table.Column<int>(type: "int", nullable: false),
                    GoodOrdersCount = table.Column<int>(type: "int", nullable: false),
                    GoodTrips = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LateOrdersCount = table.Column<int>(type: "int", nullable: false),
                    LateTrips = table.Column<int>(type: "int", nullable: false),
                    OrdersCycleDuration = table.Column<int>(type: "int", nullable: false),
                    OrdersDeliveryDuration = table.Column<int>(type: "int", nullable: false),
                    OrdersDistance = table.Column<int>(type: "int", nullable: false),
                    OrdersDuration = table.Column<int>(type: "int", nullable: false),
                    OrdersIntegrationDuration = table.Column<int>(type: "int", nullable: false),
                    OrdersPendingDuration = table.Column<int>(type: "int", nullable: false),
                    OrdersPreparingDuration = table.Column<int>(type: "int", nullable: false),
                    TotalOrdersCount = table.Column<int>(type: "int", nullable: false),
                    TotalTrips = table.Column<int>(type: "int", nullable: false),
                    TripsDistance = table.Column<int>(type: "int", nullable: false),
                    TripsDuration = table.Column<int>(type: "int", nullable: false),
                    TripsRate = table.Column<int>(type: "int", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WaitingDuration = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyDay", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CompanyDay_Company_CompanyID1",
                        column: x => x.CompanyID1,
                        principalSchema: "Client",
                        principalTable: "Company",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "StoreDay",
                schema: "DataWarehouse",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AbuseOrdersCount = table.Column<int>(type: "int", nullable: false),
                    AbuseTrips = table.Column<int>(type: "int", nullable: false),
                    ArriveToPickupDuration = table.Column<int>(type: "int", nullable: false),
                    CanceledOrdersCount = table.Column<int>(type: "int", nullable: false),
                    CompanyID = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Date = table.Column<DateTime>(type: "Date", nullable: false),
                    ExcellentTrips = table.Column<int>(type: "int", nullable: false),
                    ExcllentOrdersCount = table.Column<int>(type: "int", nullable: false),
                    FastOrdersCount = table.Column<int>(type: "int", nullable: false),
                    GoodOrdersCount = table.Column<int>(type: "int", nullable: false),
                    GoodTrips = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LateOrdersCount = table.Column<int>(type: "int", nullable: false),
                    LateTrips = table.Column<int>(type: "int", nullable: false),
                    OrdersCycleDuration = table.Column<int>(type: "int", nullable: false),
                    OrdersDeliveryDuration = table.Column<int>(type: "int", nullable: false),
                    OrdersDistance = table.Column<int>(type: "int", nullable: false),
                    OrdersDuration = table.Column<int>(type: "int", nullable: false),
                    OrdersIntegrationDuration = table.Column<int>(type: "int", nullable: false),
                    OrdersPendingDuration = table.Column<int>(type: "int", nullable: false),
                    OrdersPreparingDuration = table.Column<int>(type: "int", nullable: false),
                    StoreID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TotalOrdersCount = table.Column<int>(type: "int", nullable: false),
                    TotalTrips = table.Column<int>(type: "int", nullable: false),
                    TripsDistance = table.Column<int>(type: "int", nullable: false),
                    TripsDuration = table.Column<int>(type: "int", nullable: false),
                    TripsRate = table.Column<int>(type: "int", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WaitingDuration = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreDay", x => x.ID);
                    table.ForeignKey(
                        name: "FK_StoreDay_Store_StoreID",
                        column: x => x.StoreID,
                        principalSchema: "Client",
                        principalTable: "Store",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Rider",
                schema: "Rider",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TeamID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CompanyID = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rider", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Rider_Team_TeamID",
                        column: x => x.TeamID,
                        principalSchema: "Client",
                        principalTable: "Team",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TeamDay",
                schema: "DataWarehouse",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AbuseOrdersCount = table.Column<int>(type: "int", nullable: false),
                    AbuseTrips = table.Column<int>(type: "int", nullable: false),
                    ArriveToPickupDuration = table.Column<int>(type: "int", nullable: false),
                    AutoDispatchedOrdersCount = table.Column<int>(type: "int", nullable: false),
                    CanceledOrdersCount = table.Column<int>(type: "int", nullable: false),
                    CompanyID = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Date = table.Column<DateTime>(type: "Date", nullable: false),
                    ExcellentTrips = table.Column<int>(type: "int", nullable: false),
                    ExcllentOrdersCount = table.Column<int>(type: "int", nullable: false),
                    FastOrdersCount = table.Column<int>(type: "int", nullable: false),
                    GoodOrdersCount = table.Column<int>(type: "int", nullable: false),
                    GoodTrips = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LateOrdersCount = table.Column<int>(type: "int", nullable: false),
                    LateTrips = table.Column<int>(type: "int", nullable: false),
                    OrdersCycleDuration = table.Column<int>(type: "int", nullable: false),
                    OrdersDeliveryDuration = table.Column<int>(type: "int", nullable: false),
                    OrdersDistance = table.Column<int>(type: "int", nullable: false),
                    OrdersDuration = table.Column<int>(type: "int", nullable: false),
                    OrdersIntegrationDuration = table.Column<int>(type: "int", nullable: false),
                    OrdersPendingDuration = table.Column<int>(type: "int", nullable: false),
                    OrdersPreparingDuration = table.Column<int>(type: "int", nullable: false),
                    TeamID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TotalOrdersCount = table.Column<int>(type: "int", nullable: false),
                    TotalTrips = table.Column<int>(type: "int", nullable: false),
                    TripsDistance = table.Column<int>(type: "int", nullable: false),
                    TripsDuration = table.Column<int>(type: "int", nullable: false),
                    TripsRate = table.Column<int>(type: "int", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WaitingDuration = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamDay", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TeamDay_Team_TeamID",
                        column: x => x.TeamID,
                        principalSchema: "Client",
                        principalTable: "Team",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "RiderLog",
                schema: "Rider",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RiderID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CompanyID = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RiderLog", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RiderLog_Rider_RiderID",
                        column: x => x.RiderID,
                        principalSchema: "Rider",
                        principalTable: "Rider",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Trip",
                schema: "Trip",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RiderID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyID = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trip", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Trip_Rider_RiderID",
                        column: x => x.RiderID,
                        principalSchema: "Rider",
                        principalTable: "Rider",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TripLog",
                schema: "Trip",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TripID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CompanyID = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripLog", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TripLog_Trip_TripID",
                        column: x => x.TripID,
                        principalSchema: "Trip",
                        principalTable: "Trip",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_CompanyID",
                schema: "Order",
                table: "Order",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyDay_CompanyID1",
                schema: "DataWarehouse",
                table: "CompanyDay",
                column: "CompanyID1");

            migrationBuilder.CreateIndex(
                name: "IX_Rider_TeamID",
                schema: "Rider",
                table: "Rider",
                column: "TeamID");

            migrationBuilder.CreateIndex(
                name: "IX_RiderLog_RiderID",
                schema: "Rider",
                table: "RiderLog",
                column: "RiderID");

            migrationBuilder.CreateIndex(
                name: "IX_StoreDay_StoreID",
                schema: "DataWarehouse",
                table: "StoreDay",
                column: "StoreID");

            migrationBuilder.CreateIndex(
                name: "IX_TeamDay_TeamID",
                schema: "DataWarehouse",
                table: "TeamDay",
                column: "TeamID");

            migrationBuilder.CreateIndex(
                name: "IX_Trip_RiderID",
                schema: "Trip",
                table: "Trip",
                column: "RiderID");

            migrationBuilder.CreateIndex(
                name: "IX_TripLog_TripID",
                schema: "Trip",
                table: "TripLog",
                column: "TripID");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Company_CompanyID",
                schema: "Order",
                table: "Order",
                column: "CompanyID",
                principalSchema: "Client",
                principalTable: "Company",
                principalColumn: "ReferanceID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAction_User_UserID",
                schema: "User",
                table: "UserAction",
                column: "UserID",
                principalSchema: "User",
                principalTable: "User",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
