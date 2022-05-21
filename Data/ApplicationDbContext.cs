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
                    new AppSetting 
                    { 
                        Key = "Smtp", 
                        Value = "{\"Host\": \"some@domain.com\",\"Port\": 25, \"EnableSSL\": true}",
                        IsJsonValue = true
                    },
                    new AppSetting 
                    { 
                        Key = "Api:BaseUrl", 
                        Value = "www.someapi.com/api",
                        IsJsonValue = false
                    },
                    new AppSetting 
                    { 
                        Key = "Api:Authentication:Key", 
                        Value = Guid.NewGuid().ToString(),
                        IsJsonValue = false
                    },
                    new AppSetting 
                    { 
                        Key = "Api:Authentication:Secret", 
                        Value = Guid.NewGuid().ToString(),
                        IsJsonValue = false
                    }
                });
        }
    }
}