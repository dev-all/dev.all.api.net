using Microsoft.EntityFrameworkCore;
using Shop.Api.DataAccess.Contracts;
using Shop.Api.DataAccess.Contracts.Entities;
using Shop.Api.DataAccess.EntityConfig;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Api.DataAccess
{
    //por defecto de hereda de DbContext
    public class ShopDBContext : DbContext , IShopDBContext
    //IdentityDbContext<AppUser>
    {

        public DbSet<UserEntity> Users { get; set; }
        public ShopDBContext(DbContextOptions options):base(options)
        {

        }
        public ShopDBContext() 
        {

        }

        //sobrecarga del contexto al crear la base de datos
        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            UserEntityConfig.SetEntityBuilder(modelBuilder.Entity<UserEntity>());

            base.OnModelCreating(modelBuilder);

        }


    }
}
