using MainProjekt.Database.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace MainProjekt.Database
{
    public class ApplicationDbContex : IdentityDbContext<ApplicationUser>
    {
        public DbSet<MessageEntity> Messages { get; set; }

        public ApplicationDbContex(DbContextOptions<ApplicationDbContex> options) : base(options)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name="Administrator",
                    NormalizedName="ADMINISTRATOR"
                },
                new IdentityRole
                {
                    Id=Guid.NewGuid().ToString(),
                    Name="Premium",
                    NormalizedName="PREMIUM"
                }
            ); 
        }
    }
}
