using Shop.Api.Application.Contracts.Services;
using Shop.Api.Business.Models;
using Shop.Api.DataAccess.Contracts.Repositories;
using Shop.Api.DataAccess.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Api.Application.Services
{
   public  class UserService: IUserService

    {
        private readonly IUserRepository _userRepository;

        public  UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> AddUser(User user)
        {
            // nu usa automaper pero se podria utilizar 
            // este metodo es mas laborioso pero mas claro
            var entidad = await _userRepository.Add(UserMapper.Map(user));
            return UserMapper.Map(entidad);

        }

        public async Task<User> GetUser(int id)
        {
            var entidad = await _userRepository.Get(id);
            return UserMapper.Map(entidad);
        }

        public async Task<IEnumerable<User>> GetUserAll()
        {
            var userList = await _userRepository.GetAll();            
            return userList.Select(UserMapper.Map);
        }

        public async Task DeleteUser(int id)
        {
             await _userRepository.DeleteAsync(id);
        }

        public async Task<User> UpdateUser(User user)
        {
            var entidad = await _userRepository.Update(UserMapper.Map(user));
            return UserMapper.Map(entidad);
        }

    }
}
