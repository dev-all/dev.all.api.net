using Polly;
using Shop.Api.Application.Configuration;
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
        public readonly IAppConfig _appConfig;
        //private readonly IConfiguration _configuration;
        public  UserService(IUserRepository userRepository , IAppConfig appConfig)
        {
            _userRepository = userRepository;
            _appConfig = appConfig;
        }

        public async Task<User> AddUser(User user)
        {
            // nu usa automaper pero se podria utilizar 
            // este metodo es mas laborioso pero mas claro
            //var entidad = await _userRepository.Add(UserMapper.Map(user));
            //return UserMapper.Map(entidad);


            //solo para evaluar y aprender la utilizacion de polly 
            //EL Ejemplo usa la policita de reintento es decir se ejecuta las veces q diga el maxTrys a un intervalo de tiempo especificado en timeToWait
            // ideal para cuaando se consulta proeedores externos 
            //var maxActual = _configuration.GetSection("Polly:MaxTrys").Value;
            var maxTrys = _appConfig.MaxTrys;
            var timeToWait =TimeSpan.FromSeconds(_appConfig.SecondsToWait);
            var retryPility = Policy.Handle<Exception>().WaitAndRetryAsync(maxTrys,i=> timeToWait);
            return await retryPility.ExecuteAsync(async () =>
                     {
                         var entidad = await _userRepository.Add(UserMapper.Map(user));
                         return UserMapper.Map(entidad);
                     });
          


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
