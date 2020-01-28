using Shop.Api.Application.Contracts.Services;
using Shop.Api.Business.Models;
using Shop.Api.DataAccess.Contracts.Repositories;
using System;
using System.Collections.Generic;
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

        public async Task<string> GetUserNombreApellido(int id)  {
            var entidad =await _userRepository.Get(id);
            return entidad.NombreApellido;
        }

        //public async Task<User> AddUser(User user)
        //{


        //    var entidad = await _userRepository.Add(user);
        //  //  return entidad.NombreApellido;


        //}


    }
}
