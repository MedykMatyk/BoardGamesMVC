using BoardGamesDataAccess.Enums;
using BoardGamesDataAccess.Interfaces.Repositories;
using BoardGamesDataAccess.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGamesDataAccess.Repositories
{
    class LogRepository<T> : IRepository<Log>
    {
        public string ConnectionString { get; }

        public LogRepository(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public void Delete(int entityId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Log> GetAllEntities()
        {
            IEnumerable<Log> logs = new List<Log>();
            using (IDbConnection databaseConnection = new SqlConnection(ConnectionString))
            {
                logs = databaseConnection.Query<Log>(
                    $"SELECT * " +
                    $"FROM Logs"
                    ).ToList();
            }
            return logs;
        }

        public IEnumerable<Log> GetEntities(int entitiesCount)
        {
            IEnumerable<Log> logs = new List<Log>();
            using (IDbConnection databaseConnection = new SqlConnection(ConnectionString))
            {
                logs = databaseConnection.Query<Log>(
                    $"SELECT * " +
                    $"FROM Logs"
                    ).Take(entitiesCount).ToList();
            }
            return logs;
        }

        public IEnumerable<Log> GetAllEntitiesByGameId(int gameId)
        {
            IEnumerable<Log> logs = new List<Log>();
            using (IDbConnection databaseConnection = new SqlConnection(ConnectionString))
            {
                logs = databaseConnection.Query<Log>(
                    $"SELECT * " +
                    $"FROM Logs " +
                    $"WHERE GameId = @gameId",
                    new {gameId = gameId}
                    ).ToList();
            }
            return logs;
        }

        public Log GetEntityById(int entityId)
        {
            throw new NotImplementedException();
        }

        public void Insert(Log entity)
        {
            using (IDbConnection databaseConnection = new SqlConnection(ConnectionString))
            {
                databaseConnection.Query<Log>(
                   $"INSERT INTO Logs(GameId, Date, Source) " +
                   $"VALUES(@gameId, @date, @source) ",
                   new { gameId = entity.GameId, date = entity.Date, source = entity.Source }
                   );
            }
        }

        public void Update(Log entity)
        {
            throw new NotImplementedException();
        }
    }
}
