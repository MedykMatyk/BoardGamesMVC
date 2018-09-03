using BoardGamesDataAccess.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGamesDataAccess.Interfaces.Services
{
    public interface IEntityService
    {
        string ConnectionString { get;}
        Source Source { get; }
    }
}
