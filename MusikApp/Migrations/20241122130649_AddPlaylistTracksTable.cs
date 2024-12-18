using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusikApp.Migrations
{
    /// <inheritdoc />
    public partial class AddPlaylistTracksTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "music");

            migrationBuilder.EnsureSchema(
                name: "company");

            migrationBuilder.CreateTable(
                name: "Airports",
                columns: table => new
                {
                    IATA = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ICAO = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Airportname = table.Column<string>(name: "Airport name", type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Locationserved = table.Column<string>(name: "Location served", type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Time = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    DST = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_airports", x => x.IATA);
                });

            migrationBuilder.CreateTable(
                name: "artists",
                schema: "music",
                columns: table => new
                {
                    ArtistId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_artists", x => x.ArtistId);
                });

            migrationBuilder.CreateTable(
                name: "categories",
                schema: "company",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    HexCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: true),
                    Red = table.Column<int>(type: "int", nullable: true),
                    Green = table.Column<int>(type: "int", nullable: true),
                    Blue = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_colors", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Country = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Region = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Population = table.Column<int>(type: "int", nullable: true),
                    Areasqmi = table.Column<int>(name: "Area (sq# mi#)", type: "int", nullable: true),
                    PopDensitypersqmi = table.Column<string>(name: "Pop# Density (per sq# mi#)", type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Coastlinecoastarearatio = table.Column<string>(name: "Coastline (coast/area ratio)", type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Netmigration = table.Column<string>(name: "Net migration", type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Infantmortalityper1000births = table.Column<string>(name: "Infant mortality (per 1000 births)", type: "nvarchar(20)", maxLength: 20, nullable: true),
                    GDPpercapita = table.Column<int>(name: "GDP ($ per capita)", type: "int", nullable: true),
                    Literacy = table.Column<string>(name: "Literacy (%)", type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Phonesper1000 = table.Column<string>(name: "Phones (per 1000)", type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Arable = table.Column<string>(name: "Arable (%)", type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Crops = table.Column<string>(name: "Crops (%)", type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Other = table.Column<string>(name: "Other (%)", type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Climate = table.Column<int>(type: "int", nullable: true),
                    Birthrate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Deathrate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Agriculture = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Industry = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Service = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryData", x => x.Country);
                });

            migrationBuilder.CreateTable(
                name: "customers",
                schema: "company",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ContactName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ContactTitle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Region = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Elements",
                columns: table => new
                {
                    Number = table.Column<int>(type: "int", nullable: false),
                    Symbol = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Period = table.Column<int>(type: "int", nullable: true),
                    Group = table.Column<int>(type: "int", nullable: true),
                    Mass = table.Column<double>(type: "float", nullable: true),
                    Radius = table.Column<int>(type: "int", nullable: true),
                    Valenceel = table.Column<int>(type: "int", nullable: true),
                    Stableisotopes = table.Column<int>(type: "int", nullable: true),
                    Meltingpoint = table.Column<double>(type: "float", nullable: true),
                    Boilingpoint = table.Column<double>(type: "float", nullable: true),
                    Density = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_elements", x => x.Number);
                });

            migrationBuilder.CreateTable(
                name: "employees",
                schema: "company",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TitleOfCourtesy = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    BirthDate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    HireDate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    City = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Region = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Country = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    HomePhone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Extension = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ReportsTo = table.Column<int>(type: "int", nullable: true),
                    PhotoPath = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GameOfThrones",
                columns: table => new
                {
                    Episode = table.Column<int>(type: "int", nullable: false),
                    EpisodeInSeason = table.Column<int>(type: "int", nullable: true),
                    Season = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Directedby = table.Column<string>(name: "Directed by", type: "nvarchar(max)", nullable: true),
                    Writtenby = table.Column<string>(name: "Written by", type: "nvarchar(max)", nullable: true),
                    Originalairdate = table.Column<DateTime>(name: "Original air date", type: "datetime2", nullable: true),
                    USviewersmillions = table.Column<double>(name: "U.S. viewers(millions)", type: "float", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "genres",
                schema: "music",
                columns: table => new
                {
                    GenreId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_genres", x => x.GenreId);
                });

            migrationBuilder.CreateTable(
                name: "media_types",
                schema: "music",
                columns: table => new
                {
                    MediaTypeId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_media_types", x => x.MediaTypeId);
                });

            migrationBuilder.CreateTable(
                name: "MoonMissions",
                columns: table => new
                {
                    Spacecraft = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Launchdate = table.Column<DateTime>(name: "Launch date", type: "datetime2", nullable: true),
                    Carrierrocket = table.Column<string>(name: "Carrier rocket", type: "nvarchar(max)", nullable: true),
                    Operator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Missiontype = table.Column<string>(name: "Mission type", type: "nvarchar(max)", nullable: true),
                    Outcome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "playlists",
                schema: "music",
                columns: table => new
                {
                    PlaylistId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_playlists", x => x.PlaylistId);
                });

            migrationBuilder.CreateTable(
                name: "regions",
                schema: "company",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    RegionDescription = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "suppliers",
                schema: "company",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ContactName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ContactTitle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Region = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    HomePage = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TallyTable",
                columns: table => new
                {
                    n = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TallyTable", x => x.n);
                });

            migrationBuilder.CreateTable(
                name: "Types",
                columns: table => new
                {
                    Integer = table.Column<int>(type: "int", nullable: true),
                    Float = table.Column<double>(type: "float", nullable: true),
                    String = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Bool = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "albums",
                schema: "music",
                columns: table => new
                {
                    AlbumId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(160)", maxLength: 160, nullable: false),
                    ArtistId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_albums", x => x.AlbumId);
                    table.ForeignKey(
                        name: "FK_albums_artists",
                        column: x => x.ArtistId,
                        principalSchema: "music",
                        principalTable: "artists",
                        principalColumn: "ArtistId");
                });

            migrationBuilder.CreateTable(
                name: "orders",
                schema: "company",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    OrderDate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    RequiredDate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    ShippedDate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    ShipVia = table.Column<int>(type: "int", nullable: true),
                    Freight = table.Column<double>(type: "float", nullable: true),
                    ShipName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ShipAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ShipCity = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ShipRegion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ShipPostalCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ShipCountry = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Customers",
                        column: x => x.CustomerId,
                        principalSchema: "company",
                        principalTable: "customers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_Employees",
                        column: x => x.EmployeeId,
                        principalSchema: "company",
                        principalTable: "employees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "territories",
                schema: "company",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    TerritoryDescription = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RegionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Territories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Territories_Regions",
                        column: x => x.RegionId,
                        principalSchema: "company",
                        principalTable: "regions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "products",
                schema: "company",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SupplierId = table.Column<int>(type: "int", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    QuantityPerUnit = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UnitPrice = table.Column<double>(type: "float", nullable: true),
                    UnitsInStock = table.Column<int>(type: "int", nullable: true),
                    UnitsOnOrder = table.Column<int>(type: "int", nullable: true),
                    ReorderLevel = table.Column<int>(type: "int", nullable: true),
                    Discontinued = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories",
                        column: x => x.CategoryId,
                        principalSchema: "company",
                        principalTable: "categories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Products_Suppliers",
                        column: x => x.SupplierId,
                        principalSchema: "company",
                        principalTable: "suppliers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tracks",
                schema: "music",
                columns: table => new
                {
                    TrackId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    AlbumId = table.Column<int>(type: "int", nullable: true),
                    MediaTypeId = table.Column<int>(type: "int", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: true),
                    Composer = table.Column<string>(type: "nvarchar(220)", maxLength: 220, nullable: true),
                    Milliseconds = table.Column<int>(type: "int", nullable: false),
                    Bytes = table.Column<int>(type: "int", nullable: true),
                    UnitPrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tracks", x => x.TrackId);
                    table.ForeignKey(
                        name: "FK_tracks_albums",
                        column: x => x.AlbumId,
                        principalSchema: "music",
                        principalTable: "albums",
                        principalColumn: "AlbumId");
                    table.ForeignKey(
                        name: "FK_tracks_genres",
                        column: x => x.GenreId,
                        principalSchema: "music",
                        principalTable: "genres",
                        principalColumn: "GenreId");
                    table.ForeignKey(
                        name: "FK_tracks_media_types",
                        column: x => x.MediaTypeId,
                        principalSchema: "music",
                        principalTable: "media_types",
                        principalColumn: "MediaTypeId");
                });

            migrationBuilder.CreateTable(
                name: "employee_territory",
                schema: "company",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    TerritoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeTerritory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeTerritory_Employees",
                        column: x => x.EmployeeId,
                        principalSchema: "company",
                        principalTable: "employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeTerritory_Territories",
                        column: x => x.TerritoryId,
                        principalSchema: "company",
                        principalTable: "territories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "order_details",
                schema: "company",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    UnitPrice = table.Column<double>(type: "float", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    Discount = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders",
                        column: x => x.OrderId,
                        principalSchema: "company",
                        principalTable: "orders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products",
                        column: x => x.ProductId,
                        principalSchema: "company",
                        principalTable: "products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PlaylistTracks",
                columns: table => new
                {
                    PlaylistId = table.Column<int>(type: "int", nullable: false),
                    TrackId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaylistTracks", x => new { x.PlaylistId, x.TrackId });
                    table.ForeignKey(
                        name: "FK_PlaylistTracks_playlists_PlaylistId",
                        column: x => x.PlaylistId,
                        principalSchema: "music",
                        principalTable: "playlists",
                        principalColumn: "PlaylistId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlaylistTracks_tracks_TrackId",
                        column: x => x.TrackId,
                        principalSchema: "music",
                        principalTable: "tracks",
                        principalColumn: "TrackId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_albums_ArtistId",
                schema: "music",
                table: "albums",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_employee_territory_EmployeeId",
                schema: "company",
                table: "employee_territory",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_employee_territory_TerritoryId",
                schema: "company",
                table: "employee_territory",
                column: "TerritoryId");

            migrationBuilder.CreateIndex(
                name: "IX_order_details_OrderId",
                schema: "company",
                table: "order_details",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_order_details_ProductId",
                schema: "company",
                table: "order_details",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_orders_CustomerId",
                schema: "company",
                table: "orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_orders_EmployeeId",
                schema: "company",
                table: "orders",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_PlaylistTracks_TrackId",
                table: "PlaylistTracks",
                column: "TrackId");

            migrationBuilder.CreateIndex(
                name: "IX_products_CategoryId",
                schema: "company",
                table: "products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_products_SupplierId",
                schema: "company",
                table: "products",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_territories_RegionId",
                schema: "company",
                table: "territories",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_tracks_AlbumId",
                schema: "music",
                table: "tracks",
                column: "AlbumId");

            migrationBuilder.CreateIndex(
                name: "IX_tracks_GenreId",
                schema: "music",
                table: "tracks",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_tracks_MediaTypeId",
                schema: "music",
                table: "tracks",
                column: "MediaTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Airports");

            migrationBuilder.DropTable(
                name: "Colors");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Elements");

            migrationBuilder.DropTable(
                name: "employee_territory",
                schema: "company");

            migrationBuilder.DropTable(
                name: "GameOfThrones");

            migrationBuilder.DropTable(
                name: "MoonMissions");

            migrationBuilder.DropTable(
                name: "order_details",
                schema: "company");

            migrationBuilder.DropTable(
                name: "PlaylistTracks");

            migrationBuilder.DropTable(
                name: "TallyTable");

            migrationBuilder.DropTable(
                name: "Types");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "territories",
                schema: "company");

            migrationBuilder.DropTable(
                name: "orders",
                schema: "company");

            migrationBuilder.DropTable(
                name: "products",
                schema: "company");

            migrationBuilder.DropTable(
                name: "playlists",
                schema: "music");

            migrationBuilder.DropTable(
                name: "tracks",
                schema: "music");

            migrationBuilder.DropTable(
                name: "regions",
                schema: "company");

            migrationBuilder.DropTable(
                name: "customers",
                schema: "company");

            migrationBuilder.DropTable(
                name: "employees",
                schema: "company");

            migrationBuilder.DropTable(
                name: "categories",
                schema: "company");

            migrationBuilder.DropTable(
                name: "suppliers",
                schema: "company");

            migrationBuilder.DropTable(
                name: "albums",
                schema: "music");

            migrationBuilder.DropTable(
                name: "genres",
                schema: "music");

            migrationBuilder.DropTable(
                name: "media_types",
                schema: "music");

            migrationBuilder.DropTable(
                name: "artists",
                schema: "music");
        }
    }
}
