using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Api.Application.Contracts.Services
{
    public interface IUserService
    {

        Task<string> GetUserNombreApellido(int id);
    }
}
