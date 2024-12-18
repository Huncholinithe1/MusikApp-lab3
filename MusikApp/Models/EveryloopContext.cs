using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MusikApp.Models;

namespace MusikApp.Models;

public partial class EveryloopContext : DbContext
{
    public EveryloopContext()
    {
    }

    public EveryloopContext(DbContextOptions<EveryloopContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Airport> Airports { get; set; }

    public virtual DbSet<Album> Albums { get; set; }

    public virtual DbSet<Artist> Artists { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Color> Colors { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Element> Elements { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<EmployeeTerritory> EmployeeTerritories { get; set; }

    public virtual DbSet<GameOfThrone> GameOfThrones { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<MediaType> MediaTypes { get; set; }

    public virtual DbSet<MoonMission> MoonMissions { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<Playlist> Playlists { get; set; }

    public virtual DbSet<PlaylistTrack> PlaylistTracks { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Region> Regions { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<TallyTable> TallyTables { get; set; }

    public virtual DbSet<Territory> Territories { get; set; }

    public virtual DbSet<Track> Tracks { get; set; }

    public virtual DbSet<Type> Types { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=DILAN;Database=everyloop;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        base.OnModelCreating(modelBuilder);

        
        modelBuilder.Entity<PlaylistTrack>()
            .HasKey(pt => new { pt.PlaylistId, pt.TrackId });

        
        modelBuilder.Entity<PlaylistTrack>()
            .HasOne(pt => pt.Playlist)
            .WithMany(p => p.PlaylistTracks)
            .HasForeignKey(pt => pt.PlaylistId);

        modelBuilder.Entity<PlaylistTrack>()
            .HasOne(pt => pt.Track)
            .WithMany(t => t.PlaylistTracks)
            .HasForeignKey(pt => pt.TrackId);

        modelBuilder.UseCollation("Finnish_Swedish_CI_AS");

        modelBuilder.Entity<Airport>(entity =>
        {
            entity.HasKey(e => e.Iata).HasName("PK_airports");

            entity.Property(e => e.Iata)
                .HasMaxLength(10)
                .HasColumnName("IATA");
            entity.Property(e => e.AirportName)
                .HasMaxLength(200)
                .HasColumnName("Airport name");
            entity.Property(e => e.Dst)
                .HasMaxLength(20)
                .HasColumnName("DST");
            entity.Property(e => e.Icao)
                .HasMaxLength(10)
                .HasColumnName("ICAO");
            entity.Property(e => e.LocationServed)
                .HasMaxLength(200)
                .HasColumnName("Location served");
            entity.Property(e => e.Time).HasMaxLength(20);
        });

        modelBuilder.Entity<Album>(entity =>
        {
            entity.ToTable("albums", "music");

            entity.Property(e => e.AlbumId).ValueGeneratedNever();
            entity.Property(e => e.Title).HasMaxLength(160);

            entity.HasOne(d => d.Artist).WithMany(p => p.Albums)
                .HasForeignKey(d => d.ArtistId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_albums_artists");
        });

        modelBuilder.Entity<Artist>(entity =>
        {
            entity.ToTable("artists", "music");

            entity.Property(e => e.ArtistId).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(120);
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Categories");

            entity.ToTable("categories", "company");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CategoryName).HasMaxLength(50);
            entity.Property(e => e.Description).HasMaxLength(100);
        });

        modelBuilder.Entity<Color>(entity =>
        {
            entity.HasKey(e => e.Name).HasName("PK_colors");

            entity.Property(e => e.Name).HasMaxLength(20);
            entity.Property(e => e.Code).HasMaxLength(7);
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.Country1).HasName("PK_CountryData");

            entity.Property(e => e.Country1)
                .HasMaxLength(100)
                .HasColumnName("Country");
            entity.Property(e => e.Agriculture).HasMaxLength(10);
            entity.Property(e => e.Arable)
                .HasMaxLength(10)
                .HasColumnName("Arable (%)");
            entity.Property(e => e.AreaSqMi).HasColumnName("Area (sq# mi#)");
            entity.Property(e => e.Birthrate).HasMaxLength(10);
            entity.Property(e => e.CoastlineCoastAreaRatio)
                .HasMaxLength(20)
                .HasColumnName("Coastline (coast/area ratio)");
            entity.Property(e => e.Crops)
                .HasMaxLength(10)
                .HasColumnName("Crops (%)");
            entity.Property(e => e.Deathrate).HasMaxLength(10);
            entity.Property(e => e.GdpPerCapita).HasColumnName("GDP ($ per capita)");
            entity.Property(e => e.Industry).HasMaxLength(10);
            entity.Property(e => e.InfantMortalityPer1000Births)
                .HasMaxLength(20)
                .HasColumnName("Infant mortality (per 1000 births)");
            entity.Property(e => e.Literacy)
                .HasMaxLength(10)
                .HasColumnName("Literacy (%)");
            entity.Property(e => e.NetMigration)
                .HasMaxLength(20)
                .HasColumnName("Net migration");
            entity.Property(e => e.Other)
                .HasMaxLength(10)
                .HasColumnName("Other (%)");
            entity.Property(e => e.PhonesPer1000)
                .HasMaxLength(20)
                .HasColumnName("Phones (per 1000)");
            entity.Property(e => e.PopDensityPerSqMi)
                .HasMaxLength(20)
                .HasColumnName("Pop# Density (per sq# mi#)");
            entity.Property(e => e.Region).HasMaxLength(50);
            entity.Property(e => e.Service).HasMaxLength(10);
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Customers");

            entity.ToTable("customers", "company");

            entity.Property(e => e.Id).HasMaxLength(10);
            entity.Property(e => e.Address).HasMaxLength(100);
            entity.Property(e => e.City).HasMaxLength(50);
            entity.Property(e => e.CompanyName).HasMaxLength(100);
            entity.Property(e => e.ContactName).HasMaxLength(50);
            entity.Property(e => e.ContactTitle).HasMaxLength(50);
            entity.Property(e => e.Country).HasMaxLength(50);
            entity.Property(e => e.Fax).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(50);
            entity.Property(e => e.PostalCode).HasMaxLength(20);
            entity.Property(e => e.Region).HasMaxLength(50);
        });

        modelBuilder.Entity<Element>(entity =>
        {
            entity.HasKey(e => e.Number).HasName("PK_elements");

            entity.Property(e => e.Number).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Symbol).HasMaxLength(10);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Employees");

            entity.ToTable("employees", "company");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Address).HasMaxLength(50);
            entity.Property(e => e.BirthDate).HasMaxLength(10);
            entity.Property(e => e.City).HasMaxLength(20);
            entity.Property(e => e.Country).HasMaxLength(10);
            entity.Property(e => e.Extension).HasMaxLength(10);
            entity.Property(e => e.FirstName).HasMaxLength(20);
            entity.Property(e => e.HireDate).HasMaxLength(10);
            entity.Property(e => e.HomePhone).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(20);
            entity.Property(e => e.Notes).HasMaxLength(500);
            entity.Property(e => e.PhotoPath).HasMaxLength(100);
            entity.Property(e => e.PostalCode).HasMaxLength(20);
            entity.Property(e => e.Region).HasMaxLength(13);
            entity.Property(e => e.Title).HasMaxLength(50);
            entity.Property(e => e.TitleOfCourtesy).HasMaxLength(10);
        });

        modelBuilder.Entity<EmployeeTerritory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_EmployeeTerritory");

            entity.ToTable("employee_territory", "company");

            entity.Property(e => e.Id).HasMaxLength(7);

            entity.HasOne(d => d.Employee).WithMany(p => p.EmployeeTerritories)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK_EmployeeTerritory_Employees");

            entity.HasOne(d => d.Territory).WithMany(p => p.EmployeeTerritories)
                .HasForeignKey(d => d.TerritoryId)
                .HasConstraintName("FK_EmployeeTerritory_Territories");
        });

        modelBuilder.Entity<GameOfThrone>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.DirectedBy).HasColumnName("Directed by");
            entity.Property(e => e.OriginalAirDate).HasColumnName("Original air date");
            entity.Property(e => e.USViewersMillions).HasColumnName("U.S. viewers(millions)");
            entity.Property(e => e.WrittenBy).HasColumnName("Written by");
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.ToTable("genres", "music");

            entity.Property(e => e.GenreId).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(120);
        });

        modelBuilder.Entity<MediaType>(entity =>
        {
            entity.ToTable("media_types", "music");

            entity.Property(e => e.MediaTypeId).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(120);
        });

        modelBuilder.Entity<MoonMission>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.CarrierRocket).HasColumnName("Carrier rocket");
            entity.Property(e => e.LaunchDate).HasColumnName("Launch date");
            entity.Property(e => e.MissionType).HasColumnName("Mission type");
            entity.Property(e => e.Spacecraft).HasMaxLength(100);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Orders");

            entity.ToTable("orders", "company");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CustomerId).HasMaxLength(10);
            entity.Property(e => e.OrderDate).HasMaxLength(10);
            entity.Property(e => e.RequiredDate).HasMaxLength(10);
            entity.Property(e => e.ShipAddress).HasMaxLength(100);
            entity.Property(e => e.ShipCity).HasMaxLength(50);
            entity.Property(e => e.ShipCountry).HasMaxLength(50);
            entity.Property(e => e.ShipName).HasMaxLength(100);
            entity.Property(e => e.ShipPostalCode).HasMaxLength(20);
            entity.Property(e => e.ShipRegion).HasMaxLength(50);
            entity.Property(e => e.ShippedDate).HasMaxLength(10);

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_Orders_Customers");

            entity.HasOne(d => d.Employee).WithMany(p => p.Orders)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK_Orders_Employees");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_OrderDetails");

            entity.ToTable("order_details", "company");

            entity.Property(e => e.Id).HasMaxLength(10);

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK_OrderDetails_Orders");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_OrderDetails_Products");
        });

        modelBuilder.Entity<Playlist>(entity =>
        {
            entity.ToTable("playlists", "music");

            entity.Property(e => e.PlaylistId).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(120);
        });

        modelBuilder.Entity<PlaylistTrack>(entity =>
        {
            
            entity.ToTable("playlist_track", "music");

            entity.HasKey(e => new { e.PlaylistId, e.TrackId });

            entity.HasOne(e => e.Playlist)
                .WithMany(p => p.PlaylistTracks)
                .HasForeignKey(e => e.PlaylistId);

            entity.HasOne(e => e.Track)
                .WithMany(t => t.PlaylistTracks)
                .HasForeignKey(e => e.TrackId);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Products");

            entity.ToTable("products", "company");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ProductName).HasMaxLength(100);
            entity.Property(e => e.QuantityPerUnit).HasMaxLength(50);

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_Products_Categories");

            entity.HasOne(d => d.Supplier).WithMany(p => p.Products)
                .HasForeignKey(d => d.SupplierId)
                .HasConstraintName("FK_Products_Suppliers");
        });

        modelBuilder.Entity<Region>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Regions");

            entity.ToTable("regions", "company");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.RegionDescription).HasMaxLength(20);
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Suppliers");

            entity.ToTable("suppliers", "company");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Address).HasMaxLength(100);
            entity.Property(e => e.City).HasMaxLength(50);
            entity.Property(e => e.CompanyName).HasMaxLength(100);
            entity.Property(e => e.ContactName).HasMaxLength(50);
            entity.Property(e => e.ContactTitle).HasMaxLength(50);
            entity.Property(e => e.Country).HasMaxLength(50);
            entity.Property(e => e.Fax).HasMaxLength(50);
            entity.Property(e => e.HomePage).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(50);
            entity.Property(e => e.PostalCode).HasMaxLength(20);
            entity.Property(e => e.Region).HasMaxLength(50);
        });

        modelBuilder.Entity<TallyTable>(entity =>
        {
            entity.HasKey(e => e.N);

            entity.ToTable("TallyTable");

            entity.Property(e => e.N)
                .ValueGeneratedNever()
                .HasColumnName("n");
        });

        modelBuilder.Entity<Territory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Territories");

            entity.ToTable("territories", "company");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.TerritoryDescription).HasMaxLength(50);

            entity.HasOne(d => d.Region).WithMany(p => p.Territories)
                .HasForeignKey(d => d.RegionId)
                .HasConstraintName("FK_Territories_Regions");
        });

        modelBuilder.Entity<Track>(entity =>
        {
            entity.ToTable("tracks", "music");

            entity.Property(e => e.TrackId).ValueGeneratedNever();
            entity.Property(e => e.Composer).HasMaxLength(220);
            entity.Property(e => e.Name).HasMaxLength(200);

            entity.HasOne(d => d.Album).WithMany(p => p.Tracks)
                .HasForeignKey(d => d.AlbumId)
                .HasConstraintName("FK_tracks_albums");

            entity.HasOne(d => d.Genre).WithMany(p => p.Tracks)
                .HasForeignKey(d => d.GenreId)
                .HasConstraintName("FK_tracks_genres");

            entity.HasOne(d => d.MediaType).WithMany(p => p.Tracks)
                .HasForeignKey(d => d.MediaTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tracks_media_types");
        });

        modelBuilder.Entity<Type>(entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_users");

            entity.Property(e => e.Id)
                .HasMaxLength(12)
                .HasColumnName("ID");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FirstName).HasMaxLength(20);
            entity.Property(e => e.LastName).HasMaxLength(20);
            entity.Property(e => e.Password).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.UserName).HasMaxLength(6);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
