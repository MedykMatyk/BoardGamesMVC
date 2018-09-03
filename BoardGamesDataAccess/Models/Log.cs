using BoardGamesDataAccess.Enums;
using BoardGamesDataAccess.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGamesDataAccess.Models
{
    public class Log : ILog
    {
        public Log(int gameId, DateTime date, Source source)
        {
            GameId = gameId;
            Date = date;
            Source = source;
        }

        public Log(int id, int gameId, DateTime date, Source source) : this(gameId, date, source)
        {
            Id = id;
        }

        public int Id { get; }
        public int GameId { get; }

        public DateTime Date { get; }

        public Source Source { get; }
    }
}
