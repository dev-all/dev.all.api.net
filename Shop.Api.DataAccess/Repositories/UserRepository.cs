
using Shop.Api.DataAccess.Contracts;
using Shop.Api.DataAccess.Contracts.Entities;
using Shop.Api.DataAccess.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Api.DataAccess.Repositories
{
   public class UserRepository : IUserRepository
    {
        //metodos para el crud https://www.youtube.com/watch?v=wfpdH0EiUzI&list=PLU3UD_RM_1Abkcw8jjCl4o179jfyD47mj&index=18

        private readonly IShopDBContext _shopDBContext;

        public UserRepository(IShopDBContext shopDBContext)
        {
            _shopDBContext = shopDBContext;
        }



        public async Task<UserEntity> Get(int idEntity)
        {
            var result = await _shopDBContext.Users.FirstOrDefaultAsync( x => x.Id == idEntity);
            return result;

        }

        public async Task<UserEntity> Add(UserEntity userEntity)
        {
            // fozar la ejecucion de la RetryPolity
            // throw new Exception("test politica de Re intento RetryPolity");


            await _shopDBContext.Users.AddAsync(userEntity);
            await _shopDBContext.SaveChangesAsync();
            return userEntity;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _shopDBContext.Users.SingleAsync(x => x.Id == id);

            _shopDBContext.Users.Remove(entity);

            await _shopDBContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<UserEntity>> GetAll()
        {
            return await  _shopDBContext.Users.ToListAsync();
        }


        public Task<bool> Exist(int id)
        {
            throw new NotImplementedException();
        }
                    
        public async Task<UserEntity> Update(int idEntity, UserEntity updateUserEntity)
        {
            var entity = await Get(idEntity);
            entity.NombreApellido = updateUserEntity.NombreApellido;
            _shopDBContext.Users.Update(entity);
            await _shopDBContext.SaveChangesAsync();
            return entity;
        }
        public async Task<UserEntity> Update(UserEntity updateUserEntity)
        {

            var updateEntity = _shopDBContext.Users.Update(updateUserEntity);

            await _shopDBContext.SaveChangesAsync();

            return updateEntity.Entity;
        }

       
    }
}
