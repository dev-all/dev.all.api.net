using Shop.Api.DataAccess.Contracts.Entities;
using Shop.Api.DataAccess.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Api.DataAccess.Repositories
{
   public interface IUserRepository: IRepository<UserEntity>
    {
        //   Task<UserEntity> Add(UserEntity userEntity);
        Task<UserEntity> Update( UserEntity userEntity);
    }
}
