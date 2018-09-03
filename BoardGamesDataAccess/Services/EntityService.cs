using BoardGamesDataAccess.Enums;
using BoardGamesDataAccess.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGamesDataAccess.Services
{
    public abstract class EntityService : IEntityService
    {
        public string ConnectionString { get; set; }
        public Source Source { get; }

        public EntityService(string connectionString, Source source)
        {
            ConnectionString = connectionString;
            Source = source;
        }
    }
}
