using Microsoft.EntityFrameworkCore;
using OnionArcCQRS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArcCQRS.Persistence.Context
{
    public class CarBookContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //abra a5 
            //optionsBuilder.UseSqlServer("server=DESKTOP-3QG9GTV;initial catalog = CarBookDb; integrated security=true; TrustServerCertificate=True");
            // tulpar t5
            optionsBuilder.UseSqlServer("server=DESKTOP-21DNK0N;initial catalog = CarBookDb; integrated security=true; TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarPricing>()
                .Property(c => c.Amount)
                .HasColumnType("decimal(18,2)"); // Örnek olarak, decimal(18,2) olarak yapılandırıldı. 
        }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<Brand> Brands{ get; set; }
        public DbSet<Car> Cars{ get; set; }
        public DbSet<CarDescription> CarDescriptions{ get; set; }
        public DbSet<CarFeature> CarFeatures{ get; set; }
        public DbSet<CarPricing> CarPricings{ get; set; }
        public DbSet<Category> Categories{ get; set; }
        public DbSet<Contact> Contacts{ get; set; }
        public DbSet<Feature> Features{ get; set; }
        public DbSet<FooterAddress>FooterAddresses{ get; set; }
        public DbSet<Location>Locations{ get; set; }
        public DbSet<Pricing>Pricings{ get; set; }
        public DbSet<Service>Services{ get; set; }
        public DbSet<SocialMedia>SocialMedias{ get; set; }
        public DbSet<Testimonial>Testimonials{ get; set; }
        public DbSet<Blog>Blogs{ get; set; }
        public DbSet<Author>Authors{ get; set; }
        public DbSet<TagCloud>TagClouds{ get; set; }
        public DbSet<Comment>Comments{ get; set; }
        public DbSet<RentACar>RentACars{ get; set; }
    
    }
}
