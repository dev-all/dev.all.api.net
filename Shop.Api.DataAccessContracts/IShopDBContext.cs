using Microsoft.EntityFrameworkCore;
using Shop.Api.DataAccess.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Api.DataAccess.Contracts
{
    public interface IShopDBContext
    {

        DbSet<UserEntity> Users { get; set; }


    }
}
