using Shop.Api.DataAccess.Contracts.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shop.Api.DataAccess.Contracts.Repositories
{
    public interface IUserRepository : IRepository<UserEntity>
    {

        Task<UserEntity> Get(int id);

        Task<IEnumerable<UserEntity>> GetAll();

        Task<UserEntity> Add(UserEntity user);

        Task<UserEntity> Update(UserEntity userEntity);

        Task DeleteAsync(int id);
    }
}
