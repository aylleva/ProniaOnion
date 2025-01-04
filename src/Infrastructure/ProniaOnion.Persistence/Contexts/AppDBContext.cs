using Microsoft.EntityFrameworkCore;
using ProniaOnion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;


namespace ProniaOnion.Persistence.Contexts
{
    public class AppDBContext:DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options):base(options) { }   
       
        public DbSet<Product> Products { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductColors> ProductColors { get; set; }

        public DbSet<Size> Sizes { get; set; }
        public DbSet<ProductSizes> ProductSizes { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<ProductTags> ProductTags { get; set; }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Author> Author { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<BlogTags> BlogsTags { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
