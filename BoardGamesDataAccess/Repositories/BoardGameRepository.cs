using BoardGamesDataAccess.Interfaces.Repositories;
using BoardGamesDataAccess.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BoardGamesRest.Repositories
{
    class BoardGameRepository<T> : IRepository<BoardGame>
    {
        public BoardGameRepository(string connectionString)
        {
            ConnectionString = connectionString;
        }
        public string ConnectionString { get; }

        public BoardGame GetEntityById(int entityId)
        {
            BoardGame boardGame;
            using (IDbConnection databaseConnection = new SqlConnection(ConnectionString))
            {
                boardGame = databaseConnection.Query<BoardGame>(
                    $"SELECT * " +
                    $"FROM Games " +
                    $"WHERE Id = @id",
                    new { id = entityId }
                    ).FirstOrDefault();
            }
            return boardGame;
        }

        public IEnumerable<BoardGame> GetAllEntities()
        {
            List<BoardGame> boardGames = new List<BoardGame>();
            using (IDbConnection databaseConnection = new SqlConnection(ConnectionString))
            {
                boardGames = databaseConnection.Query<BoardGame>(
                    $"SELECT * " +
                    $"FROM Games "
                    ).ToList();
            }
            return boardGames;
        }

        public IEnumerable<BoardGame> GetEntities(int entitiesCount)
        {
            List<BoardGame> boardGames = new List<BoardGame>();
            using (IDbConnection databaseConnection = new SqlConnection(ConnectionString))
            {
                boardGames = databaseConnection.Query<BoardGame>(
                    $"SELECT * " +
                    $"FROM Games"
                    ).Take(entitiesCount).ToList();
            }
            return boardGames;
        }

        public void Delete(int entityId)
        {
            throw new NotImplementedException();
        }

        public void Insert(BoardGame entity)
        {
            BoardGame boardGame = new BoardGame();
            using (IDbConnection databaseConnection = new SqlConnection(ConnectionString))
            {
                databaseConnection.Query<BoardGame>(
                     $"INSERT INTO Games(Name, MinPlayersNumber, MaxPlayersNumber) " +
                     $"VALUES(@name, @minPlayersNumber, @maxPlayersNumber)",
                     new {
                         name = entity.Name,
                         minPlayersNumber = entity.MinPlayersNumber,
                         maxPlayersNumber = entity.MaxPlayersNumber }
                     );
            }
        }

        public void Update(BoardGame entity)
        {
            using (IDbConnection databaseConnection = new SqlConnection(ConnectionString))
            {
                databaseConnection.Execute($"UPDATE Games " +
                     $"SET Name = @name, MinPlayersNumber = @minPlayersNumber, MaxPlayersNumber = @maxPlayersNumber " +
                     $"WHERE Id = @id",
                     new
                     {
                         id = entity.Id,
                         name = entity.Name,
                         minPlayersNumber = entity.MinPlayersNumber,
                         maxPlayersNumber = entity.MaxPlayersNumber
                     }
                     );
            }
        }
    }
}