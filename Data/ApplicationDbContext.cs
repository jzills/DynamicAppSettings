using System;
using System.Text.Json;
using DynamicAppSettings.Configurations;
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
                        Id = 1,
                        Key = "Smtp", 
                        Value = "{\"Host\": \"some@domain.com\",\"Port\": 25, \"EnableSSL\": true}",
                        IsJsonValue = true
                    },
                    new AppSetting 
                    { 
                        Id = 2,
                        Key = "Api:BaseUrl", 
                        Value = "www.someapi.com/api",
                        IsJsonValue = false
                    },
                    new AppSetting 
                    { 
                        Id = 3,
                        Key = "Api:Authentication:Key", 
                        Value = Guid.NewGuid().ToString(),
                        IsJsonValue = false
                    },
                    new AppSetting 
                    { 
                        Id = 4,
                        Key = "Api:Authentication:Secret", 
                        Value = Guid.NewGuid().ToString(),
                        IsJsonValue = false
                    },
                    new AppSetting
                    {
                        Id = 5,
                        Key = "ApiOther",
                        Value = JsonSerializer.Serialize(new ApiOtherOptions
                        {
                            BaseUrl = "www.someotherapi.com/api",
                            Authentication = new AuthenticationOptions
                            {
                                Key = Guid.NewGuid().ToString(),
                                Secret = Guid.NewGuid().ToString()
                            }
                        }),
                        IsJsonValue = true
                    }
                });
        }
    }
}