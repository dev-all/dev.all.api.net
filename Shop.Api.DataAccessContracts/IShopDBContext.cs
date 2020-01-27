using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Shop.Api.DataAccess.Contracts.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Api.DataAccess.Contracts
{
    public interface IShopDBContext
    {

        DbSet<UserEntity> Users { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        DatabaseFacade Database { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));

        void RemoveRange(IEnumerable<object> entities);
        EntityEntry Update(object entity);

    }
}
