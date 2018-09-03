using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGamesDataAccess.Interfaces.Repositories
{
    public interface IRepository<T>
    {
        string ConnectionString { get; }
        T GetEntityById(int entityId);
        IEnumerable<T> GetAllEntities();
        IEnumerable<T> GetEntities(int entitiesCount);
        void Insert(T entity);
        void Update(T entity);
        void Delete(int entityId);
    }
}
