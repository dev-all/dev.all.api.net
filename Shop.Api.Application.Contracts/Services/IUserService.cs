using Shop.Api.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Api.Application.Contracts.Services
{
    public interface IUserService
    {
       
        Task<User> GetUser(int id);
        Task<IEnumerable<User>> GetUserAll();
        Task<User> AddUser(User user);
        Task DeleteUser(int id);
        Task<User> UpdateUser(User user);
      
    }
}
