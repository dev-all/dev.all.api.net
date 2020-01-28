using Shop.Api.Business.Models;
using Shop.Api.DataAccess.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Api.DataAccess.Mappers
{
   public static class UserMapper
    {
        public static UserEntity Map(User dto)
        {
            return new UserEntity()
            {
                Id = dto.Id,
                NombreApellido = dto.NombreApellido,
                Google = dto.Google,
                Activo = dto.Activo,
                FechaCreacion = dto.FechaCreacion
            };
        }
        public static User Map(UserEntity entity)
        {
            return new User()
            {
                Id = entity.Id,
                NombreApellido = entity.NombreApellido,
                Google = entity.Google,
                Activo = entity.Activo,
                FechaCreacion = entity.FechaCreacion
            };
        }
    
    }
}

