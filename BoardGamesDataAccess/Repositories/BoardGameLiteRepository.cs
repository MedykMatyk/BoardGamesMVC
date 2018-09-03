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
    class BoardGameLiteRepository<T> : IRepository<BoardGameLite>
    {
        public string ConnectionString { get; set; }

        public BoardGameLiteRepository(string connectionString)
        {
            ConnectionString = connectionString;
        }
        public BoardGameLite GetEntityById(int entityId)
        {
            BoardGameLite boardGame;
            using (IDbConnection databaseConnection = new SqlConnection(ConnectionString))
            {
                boardGame = databaseConnection.Query<BoardGameLite>(
                    $"SELECT * " +
                    $"FROM Games " +
                    $"WHERE Id = @id ",
                    new { entityId }
                    ).FirstOrDefault();
            }
            return boardGame;
        }

        public IEnumerable<BoardGameLite> GetAllEntities()
        {
            List<BoardGameLite> boardGamesLite;
            using (IDbConnection databaseConnection = new SqlConnection(ConnectionString))
            {
                boardGamesLite = databaseConnection.Query<BoardGameLite>(
                    $"SELECT * " +
                    $"FROM Games"
                    ).ToList();
            }
            return boardGamesLite;
        }

        public IEnumerable<BoardGameLite> GetEntities(int entitiesCount)
        {
            List<BoardGameLite> boardGamesLite;
            using (IDbConnection databaseConnection = new SqlConnection(ConnectionString))
            {
                boardGamesLite = databaseConnection.Query<BoardGameLite>(
                    $"SELECT * " +
                    $"FROM Games"
                    ).Take(entitiesCount).ToList();
            }
            return boardGamesLite;
        }

        public void Delete(int entityId)
        {
            BoardGame boardGame = new BoardGame();
            using (IDbConnection databaseConnection = new SqlConnection(ConnectionString))
            {
                databaseConnection.Query<BoardGame>(
                     $"DELETE FROM Games " +
                     $"WHERE Id = @id",
                     new
                     {
                         id = entityId
                     }
                     );
            }
        }

        public void Insert(BoardGameLite entity)
        {
            throw new NotImplementedException();
        }


        public void Update(BoardGameLite entity)
        {
            throw new NotImplementedException();
        }
    }
}
