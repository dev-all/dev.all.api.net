using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Api.DataAccess.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Api.DataAccess.EntityConfig
{
    public class UserEntityConfig
    {

        //
        public static void SetEntityBuilder(EntityTypeBuilder<UserEntity> entityBuilder) {
            entityBuilder.ToTable("Users");
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.Id).IsRequired();
            entityBuilder.Property(x => x.Id).UseSqlServerIdentityColumn();
        }
    }
}


