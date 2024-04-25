using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Service.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Client");

            migrationBuilder.EnsureSchema(
                name: "DataWarehouse");

            migrationBuilder.EnsureSchema(
                name: "Order");

            migrationBuilder.EnsureSchema(
                name: "Rider");

            migrationBuilder.EnsureSchema(
                name: "User");

            migrationBuilder.EnsureSchema(
                name: "Trip");

            migrationBuilder.CreateTable(
                name: "Company",
                schema: "Client",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ReferanceID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_Company", x => x.ID);
                    table.UniqueConstraint("AK_Company_ReferanceID", x => x.ReferanceID);
                });

            migrationBuilder.CreateTable(
                name: "Store",
                schema: "Client",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_Store", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Team",
                schema: "Client",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_Team", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "User",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SaltPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    LastLogin = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    table.PrimaryKey("PK_User", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CompanyDay",
                schema: "DataWarehouse",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Date = table.Column<DateTime>(type: "Date", nullable: false),
                    CompanyReferanceNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalOrdersCount = table.Column<int>(type: "int", nullable: false),
                    ExcllentOrdersCount = table.Column<int>(type: "int", nullable: false),
                    GoodOrdersCount = table.Column<int>(type: "int", nullable: false),
                    LateOrdersCount = table.Column<int>(type: "int", nullable: false),
                    AbuseOrdersCount = table.Column<int>(type: "int", nullable: false),
                    FastOrdersCount = table.Column<int>(type: "int", nullable: false),
                    CanceledOrdersCount = table.Column<int>(type: "int", nullable: false),
                    OrdersDistance = table.Column<int>(type: "int", nullable: false),
                    OrdersDuration = table.Column<int>(type: "int", nullable: false),
                    OrdersPendingDuration = table.Column<int>(type: "int", nullable: false),
                    OrdersPreparingDuration = table.Column<int>(type: "int", nullable: false),
                    OrdersIntegrationDuration = table.Column<int>(type: "int", nullable: false),
                    OrdersDeliveryDuration = table.Column<int>(type: "int", nullable: false),
                    WaitingDuration = table.Column<int>(type: "int", nullable: false),
                    ArriveToPickupDuration = table.Column<int>(type: "int", nullable: false),
                    OrdersCycleDuration = table.Column<int>(type: "int", nullable: false),
                    TotalTrips = table.Column<int>(type: "int", nullable: false),
                    ExcellentTrips = table.Column<int>(type: "int", nullable: false),
                    GoodTrips = table.Column<int>(type: "int", nullable: false),
                    LateTrips = table.Column<int>(type: "int", nullable: false),
                    AbuseTrips = table.Column<int>(type: "int", nullable: false),
                    TripsDuration = table.Column<int>(type: "int", nullable: false),
                    TripsDistance = table.Column<int>(type: "int", nullable: false),
                    TripsRate = table.Column<int>(type: "int", nullable: false),
                    CompanyID1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
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
                    table.PrimaryKey("PK_CompanyDay", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CompanyDay_Company_CompanyID1",
                        column: x => x.CompanyID1,
                        principalSchema: "Client",
                        principalTable: "Company",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Order",
                schema: "Order",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ShiftDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OrderNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Distance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Rate = table.Column<int>(type: "int", nullable: false),
                    DeliveryTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReadyTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AddedToTripTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InProgressTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TripCloseTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentMethodID = table.Column<int>(type: "int", nullable: true),
                    IsFastOrder = table.Column<bool>(type: "bit", nullable: false),
                    IsPaused = table.Column<bool>(type: "bit", nullable: false),
                    IsAutoDispatched = table.Column<bool>(type: "bit", nullable: false),
                    IsTransite = table.Column<bool>(type: "bit", nullable: false),
                    IsRefund = table.Column<bool>(type: "bit", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BalanceDue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RiderID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TripRate = table.Column<int>(type: "int", nullable: true),
                    OnMyWayTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ArriveToCustomerTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OnMyWayToPickupTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MoneyCollected = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PickingUpTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeliverManually = table.Column<bool>(type: "bit", nullable: true),
                    CancelTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReferenceNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StoreID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeamID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StoreName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeamName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryZoneName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrandName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlannedPickupTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AbuseType = table.Column<int>(type: "int", nullable: false),
                    ArriveToPickupTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TripID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TripReferenceNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerMobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_Order", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Order_Company_CompanyID",
                        column: x => x.CompanyID,
                        principalSchema: "Client",
                        principalTable: "Company",
                        principalColumn: "ReferanceID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StoreDay",
                schema: "DataWarehouse",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Date = table.Column<DateTime>(type: "Date", nullable: false),
                    StoreID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TotalOrdersCount = table.Column<int>(type: "int", nullable: false),
                    ExcllentOrdersCount = table.Column<int>(type: "int", nullable: false),
                    GoodOrdersCount = table.Column<int>(type: "int", nullable: false),
                    LateOrdersCount = table.Column<int>(type: "int", nullable: false),
                    AbuseOrdersCount = table.Column<int>(type: "int", nullable: false),
                    FastOrdersCount = table.Column<int>(type: "int", nullable: false),
                    CanceledOrdersCount = table.Column<int>(type: "int", nullable: false),
                    OrdersDistance = table.Column<int>(type: "int", nullable: false),
                    OrdersDuration = table.Column<int>(type: "int", nullable: false),
                    OrdersPendingDuration = table.Column<int>(type: "int", nullable: false),
                    OrdersPreparingDuration = table.Column<int>(type: "int", nullable: false),
                    OrdersIntegrationDuration = table.Column<int>(type: "int", nullable: false),
                    OrdersDeliveryDuration = table.Column<int>(type: "int", nullable: false),
                    WaitingDuration = table.Column<int>(type: "int", nullable: false),
                    ArriveToPickupDuration = table.Column<int>(type: "int", nullable: false),
                    OrdersCycleDuration = table.Column<int>(type: "int", nullable: false),
                    TotalTrips = table.Column<int>(type: "int", nullable: false),
                    ExcellentTrips = table.Column<int>(type: "int", nullable: false),
                    GoodTrips = table.Column<int>(type: "int", nullable: false),
                    LateTrips = table.Column<int>(type: "int", nullable: false),
                    AbuseTrips = table.Column<int>(type: "int", nullable: false),
                    TripsDuration = table.Column<int>(type: "int", nullable: false),
                    TripsDistance = table.Column<int>(type: "int", nullable: false),
                    TripsRate = table.Column<int>(type: "int", nullable: false),
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
                    Code = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    TeamID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CompanyID = table.Column<int>(type: "int", nullable: false)
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
                    Date = table.Column<DateTime>(type: "Date", nullable: false),
                    TeamID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TotalOrdersCount = table.Column<int>(type: "int", nullable: false),
                    ExcllentOrdersCount = table.Column<int>(type: "int", nullable: false),
                    GoodOrdersCount = table.Column<int>(type: "int", nullable: false),
                    LateOrdersCount = table.Column<int>(type: "int", nullable: false),
                    AbuseOrdersCount = table.Column<int>(type: "int", nullable: false),
                    FastOrdersCount = table.Column<int>(type: "int", nullable: false),
                    CanceledOrdersCount = table.Column<int>(type: "int", nullable: false),
                    OrdersDistance = table.Column<int>(type: "int", nullable: false),
                    AutoDispatchedOrdersCount = table.Column<int>(type: "int", nullable: false),
                    OrdersDuration = table.Column<int>(type: "int", nullable: false),
                    OrdersPendingDuration = table.Column<int>(type: "int", nullable: false),
                    OrdersPreparingDuration = table.Column<int>(type: "int", nullable: false),
                    OrdersIntegrationDuration = table.Column<int>(type: "int", nullable: false),
                    OrdersDeliveryDuration = table.Column<int>(type: "int", nullable: false),
                    WaitingDuration = table.Column<int>(type: "int", nullable: false),
                    ArriveToPickupDuration = table.Column<int>(type: "int", nullable: false),
                    OrdersCycleDuration = table.Column<int>(type: "int", nullable: false),
                    TotalTrips = table.Column<int>(type: "int", nullable: false),
                    ExcellentTrips = table.Column<int>(type: "int", nullable: false),
                    GoodTrips = table.Column<int>(type: "int", nullable: false),
                    LateTrips = table.Column<int>(type: "int", nullable: false),
                    AbuseTrips = table.Column<int>(type: "int", nullable: false),
                    TripsDuration = table.Column<int>(type: "int", nullable: false),
                    TripsDistance = table.Column<int>(type: "int", nullable: false),
                    TripsRate = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_TeamDay", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TeamDay_Team_TeamID",
                        column: x => x.TeamID,
                        principalSchema: "Client",
                        principalTable: "Team",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Token",
                schema: "User",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserAgent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LoggedOutDate = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    table.PrimaryKey("PK_Token", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Token_User_UserID",
                        column: x => x.UserID,
                        principalSchema: "User",
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserAction",
                schema: "User",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Payload = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_UserAction", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserAction_User_UserID",
                        column: x => x.UserID,
                        principalSchema: "User",
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderLog",
                schema: "Order",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OrderID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_OrderLog", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OrderLog_Order_OrderID",
                        column: x => x.OrderID,
                        principalSchema: "Order",
                        principalTable: "Order",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "RiderLog",
                schema: "Rider",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RiderID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RiderID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
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
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                name: "IX_CompanyDay_CompanyID1",
                schema: "DataWarehouse",
                table: "CompanyDay",
                column: "CompanyID1");

            migrationBuilder.CreateIndex(
                name: "IX_Order_CompanyID",
                schema: "Order",
                table: "Order",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLog_OrderID",
                schema: "Order",
                table: "OrderLog",
                column: "OrderID");

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
                name: "IX_Token_UserID",
                schema: "User",
                table: "Token",
                column: "UserID");

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

            migrationBuilder.CreateIndex(
                name: "IX_UserAction_UserID",
                schema: "User",
                table: "UserAction",
                column: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyDay",
                schema: "DataWarehouse");

            migrationBuilder.DropTable(
                name: "OrderLog",
                schema: "Order");

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
                name: "Token",
                schema: "User");

            migrationBuilder.DropTable(
                name: "TripLog",
                schema: "Trip");

            migrationBuilder.DropTable(
                name: "UserAction",
                schema: "User");

            migrationBuilder.DropTable(
                name: "Order",
                schema: "Order");

            migrationBuilder.DropTable(
                name: "Store",
                schema: "Client");

            migrationBuilder.DropTable(
                name: "Trip",
                schema: "Trip");

            migrationBuilder.DropTable(
                name: "User",
                schema: "User");

            migrationBuilder.DropTable(
                name: "Company",
                schema: "Client");

            migrationBuilder.DropTable(
                name: "Rider",
                schema: "Rider");

            migrationBuilder.DropTable(
                name: "Team",
                schema: "Client");
        }
    }
}
