using Shop.Api.Business.Models;
using Shop.Api.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Api.Mappers
{
    public static class UserMapper
    {
        public static User Map(UserModels userModel)
        {
            return new User()
            {
                NombreApellido = userModel.NombreApellido,
                Activo = userModel.Activo,
                Google = userModel.Google,
                FechaCreacion = DateTime.Now
            };
        }
        public static UserModels Map(User user)
        {
            return new UserModels()
            {
                NombreApellido = user.NombreApellido,
                Activo = user.Activo,
                Google = user.Google,
                FechaCreacion = user.FechaCreacion
            };
        }
    }
}
