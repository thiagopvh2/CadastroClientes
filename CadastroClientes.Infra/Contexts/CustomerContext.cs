using CadastroClientes.Domain.Entities;
using CadastroClientes.Domain.ValueObjects;
using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;

namespace CadastroClientes.Infra.Contexts
{
    public class CustomerContext : DbContext
    {
        public CustomerContext(DbContextOptions<CustomerContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Notification>();
            modelBuilder.Ignore<Cpf>();
            modelBuilder.Entity<Customer>().ToTable("Customer");
            modelBuilder.Entity<Customer>().HasKey(x => x.Id);
            modelBuilder.Entity<Customer>().Property(x => x.Id).ValueGeneratedNever();
            modelBuilder.Entity<Customer>().HasIndex(x => x.Name);
            modelBuilder.Entity<Customer>().Property(x => x.Name).HasMaxLength(100).HasColumnType("varchar(100)");
            modelBuilder.Entity<Customer>().Property(x => x.BirthDate);
            modelBuilder.Entity<Customer>().OwnsOne(x => x.FacebookUrl).Property(x => x.Value).HasColumnName("FacebookUrl").HasMaxLength(250).HasColumnType("varchar(250)");
            modelBuilder.Entity<Customer>().OwnsOne(x => x.LinkedinUrl).Property(x => x.Value).HasColumnName("LinkedinUrl").HasMaxLength(250).HasColumnType("varchar(250)");
            modelBuilder.Entity<Customer>().OwnsOne(x => x.TwitterUrl).Property(x => x.Value).HasColumnName("TwitterUrl").HasMaxLength(250).HasColumnType("varchar(250)");
            modelBuilder.Entity<Customer>().OwnsOne(x => x.InstagramUrl).Property(x => x.Value).HasColumnName("InstagramUrl").HasMaxLength(250).HasColumnType("varchar(250)");
            modelBuilder.Entity<Customer>().OwnsOne(x => x.Cpf).Property(x => x.Value).HasColumnName("Cpf").HasMaxLength(11).HasColumnType("varchar(11)");
            modelBuilder.Entity<Customer>().Property(x => x.Rg).HasMaxLength(20).HasColumnType("varchar(20)");


            modelBuilder.Entity<Customer>().HasMany(a => a.PhoneNumbers)
                .WithOne(b => b.Customer)
                .HasForeignKey(b => b.CustomerId);

            modelBuilder.Entity<Customer>().HasMany(a => a.Addresses)
                .WithOne(b => b.Customer)
                .HasForeignKey(b => b.CustomerId);
        }
    }
}