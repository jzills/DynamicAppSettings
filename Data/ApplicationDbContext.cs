using System;
using Microsoft.EntityFrameworkCore;

namespace DynamicAppSettings.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options)
         : base(options) { }

        public virtual DbSet<AppSetting> AppSettings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {   
            modelBuilder
                .Entity<AppSetting>()
                .HasData(new AppSetting[] 
                {
                    new AppSetting { Id = Guid.NewGuid(), Key = "Smtp", Value = "{\"Host\": \"some@domain.com\",\"Port\": 25, \"EnableSSL\": true}"}
                });
        }
    }
}