using Microsoft.EntityFrameworkCore;
using DEVinCar.Service.Models;
using DEVinCar.Repository.Data.Mappings;

namespace DEVinCar.Repository.Data;

public class DevInCarDbContext : DbContext
{
    private readonly IConfiguration _configuration;

    public DevInCarDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    //public DbSet<XYZ> XYZs { get; set; }

    public DbSet<City> Cities { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<Sale> Sales { get; set; }
    public DbSet<SaleCar> SaleCars { get; set; }
    public DbSet<Delivery> Deliveries { get; set; }
    public DbSet<State> States { get; set; }
    public DbSet<Address> Addresses { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        optionsBuilder.UseSqlServer(
            _configuration.GetConnectionString("DEV_IN_CAR")
        );
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new CityMap());
        modelBuilder.ApplyConfiguration(new UserMap());
        modelBuilder.ApplyConfiguration(new CarMap());
        modelBuilder.ApplyConfiguration(new SaleMap());
        modelBuilder.Entity<SaleCar>(entity =>
        {
            entity.ToTable("SaleCars");
            entity.HasKey(sc => sc.Id);
            entity.Property(sc => sc.Id)
                .HasColumnType("int");

            entity.Property(sc => sc.SaleId)
                .HasColumnType("int")
                .IsRequired();

            entity.Property(sc => sc.CarId)
                .HasColumnType("int")
                .IsRequired();

            entity.Property(sc => sc.UnitPrice)
                .HasPrecision(18, 2);

            entity.Property(sc => sc.Amount)
                .HasColumnType("int");

            entity.HasOne<Car>(c => c.Car)
                .WithMany(c => c.Sales)
                .HasForeignKey(c => c.Id);

            entity.HasOne<Sale>(s => s.Sale)
                .WithMany(c => c.Cars)
                .HasForeignKey(s => s.Id);

        });

        modelBuilder.Entity<Delivery>(entity =>
        {
            entity.ToTable("Deliveries");

            entity.HasKey(d => d.Id);

            entity.Property(d => d.Id)
                .HasColumnType("int");

            entity.Property(d => d.AddressId)
                .HasColumnType("int");

            entity
                .Property(d => d.SaleId)
                .HasColumnType("int");

            entity
                .Property(d => d.DeliveryForecast);


            entity.HasOne<Address>(a => a.Address)
                .WithMany(d => d.Deliveries)
                .HasForeignKey(a => a.AddressId);

            entity.HasOne<Sale>(s => s.Sale)
                .WithMany(d => d.Deliveries)
                .HasForeignKey(s => s.SaleId);

        });

        modelBuilder.Entity<Address>(entity =>
        {
            entity.ToTable("Addresses");

            entity.HasKey(d => d.Id);

            entity.Property(d => d.CityId).HasColumnType("int").IsRequired();

            entity.Property(d => d.Street).HasMaxLength(150).IsRequired();

            entity.Property(d => d.Cep).HasMaxLength(8).IsRequired();

            entity.Property(d => d.Number).HasColumnType("int").IsRequired();

            entity.Property(d => d.Complement).HasMaxLength(255);

            entity.HasOne<City>(address => address.City)
            .WithMany(d => d.Addresses)
            .HasForeignKey(address => address.CityId)
            .IsRequired();
        }

      );

        modelBuilder.Entity<State>(entity =>
        {
            entity.ToTable("States");
            entity.HasKey(s => s.Id);

            entity
                .Property(s => s.Name)
                .HasMaxLength(100)
                .IsRequired();

            entity
                .Property(s => s.Initials)
                .HasMaxLength(2)
                .IsRequired();

            entity
                .HasData(new[] {
                    new State (1, "Acre", "AC"),
                    new State (2, "Alagoas", "AL"),
                    new State (3, "Amapá", "AP"),
                    new State (4, "Amazonas", "AM"),
                    new State (5, "Bahia", "BA"),
                    new State (6, "Ceará", "CE"),
                    new State (7, "Distrito Federal", "DF"),
                    new State (8, "Espírito Santo", "ES"),
                    new State (9, "Goiás", "GO"),
                    new State (10, "Maranhão", "MA"),
                    new State (11, "Mato Grosso", "MT"),
                    new State (12, "Mato Grosso do Sul", "MS"),
                    new State (13, "Minas Gerais", "MG"),
                    new State (14, "Pará", "PA"),
                    new State (15, "Paraíba", "PB"),
                    new State (16, "Paraná", "PR"),
                    new State (17, "Pernambuco", "PE"),
                    new State (18, "Piauí", "PI"),
                    new State (19, "Rio de Janeiro", "RJ"),
                    new State (20, "Rio Grande do Norte", "RN"),
                    new State (21, "Rio Grande do Sul", "RS"),
                    new State (22, "Rondônia", "RO"),
                    new State (23, "Roraima", "RR"),
                    new State (24, "Santa Catarina", "SC"),
                    new State (25, "São Paulo", "SP"),
                    new State (26, "Sergipe", "SE"),
                    new State (27, "Tocantins", "TO")
                });
        });
    }
}

