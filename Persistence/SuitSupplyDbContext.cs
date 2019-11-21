using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Configurations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Persistence
{
    public class SuitSupplyDbContext : DbContext, ISuitSupplyDbContext
    {
        public SuitSupplyDbContext(DbContextOptions<SuitSupplyDbContext> options) : base(options)
        {
             
        }

        public DbSet<ProductCatalog> ProductCatalogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductCatalog>().HasData(
                new ProductCatalog
                {
                    Id = 1,
                    Code = "Suit_Black",
                    Name = "Black Suit",
                    Photo = "http://pngimg.com/uploads/suit/suit_PNG8134.png",
                    Price = 140m
                },
                 new ProductCatalog
                 {
                     Id = 2,
                     Code = "Blue_Black",
                     Name = "Blue Suit",
                     Photo = "http://pngimg.com/uploads/suit/suit_PNG8121.png",
                     Price = 150m
                 },
                new ProductCatalog
                {
                    Id = 3,
                    Code = "Grey_Black",
                    Name = "Grey Suit",
                    Photo = "http://pngimg.com/uploads/suit/suit_PNG8133.png",
                    Price = 160m
                }
            );

            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(SuitSupplyDbContext).Assembly);
            modelBuilder.ApplyConfiguration<ProductCatalog>(new ProductCatalogConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        //public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        //{
        //    return base.SaveChangesAsync(cancellationToken);
        //}
    }
}
