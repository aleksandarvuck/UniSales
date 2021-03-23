using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace UniSales.API.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<ContactInfo> ContactInfos { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Category>(ConfigureCategory);
            modelBuilder.Entity<ShoppingCart>(ConfigureShoppingCart);
            modelBuilder.Entity<ShoppingCartItem>(ConfigureShoppingCartItem);
            modelBuilder.Entity<ContactInfo>(ConfigureContactInfo);
            modelBuilder.Entity<Address>(ConfigureAddress);
            modelBuilder.Entity<Order>()
                .Property(p => p.OrderTotal)
                .HasColumnType("decimal(18,2)"); ;
        }


        private void ConfigureAddress(EntityTypeBuilder<Address> obj)
        {
        }

        private void ConfigureContactInfo(EntityTypeBuilder<ContactInfo> obj)
        {
        }

        private void ConfigureShoppingCartItem(EntityTypeBuilder<ShoppingCartItem> obj)
        {
        }

        private void ConfigureShoppingCart(EntityTypeBuilder<ShoppingCart> obj)
        {
        }

        private void ConfigureCategory(EntityTypeBuilder<Category> entityTypeBuilder)
        {
            entityTypeBuilder.ToTable("Category");

            entityTypeBuilder.Property(c => c.CategoryId)
                //.ForSqlServerUseSequenceHiLo("category_hilo")
                .IsRequired();

            entityTypeBuilder.Property(c => c.CategoryName)
                .IsRequired(true)
                .HasMaxLength(100);
        }

    }
}