using BoardGamesDataAccess.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGamesDataAccess.Interfaces.Models
{
    public interface ILog
    {
        int Id { get; }
        int GameId { get; }
        DateTime Date { get; }
        Source Source { get; }
    }
}
