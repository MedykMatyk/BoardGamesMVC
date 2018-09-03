using BoardGamesDataAccess.Enums;
using BoardGamesDataAccess.Interfaces.Models;
using BoardGamesDataAccess.Interfaces.Repositories;
using BoardGamesDataAccess.Interfaces.Services;
using BoardGamesDataAccess.Models;
using BoardGamesDataAccess.Repositories;
using BoardGamesRest.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGamesDataAccess.Services
{
    public class BoardGameService : EntityService, IEntityService
    {
        public BoardGameService(string connectionString, Source source) : base(connectionString, source)
        {
        }

        public BoardGame GetFromDb(int entityId)
        {
            IRepository<BoardGame> boardGameRepository = GetRepository();
            BoardGame boardGame = boardGameRepository.GetEntityById(entityId);
            LogService logService = new LogService(ConnectionString, Source);
            logService.Insert(entityId, DateTime.Now, this.Source);
            return boardGame;
        }
        public IEnumerable<BoardGame> GetCollectionFromDb(int maxEntitiesCount)
        {
            if (maxEntitiesCount == 0)
            {
                return new List<BoardGame>();
            }

            IEnumerable<BoardGame> boardGames = new List<BoardGame>();
            IRepository<BoardGame> boardGameRepository = GetRepository();


            if (maxEntitiesCount == -1)
            {
                boardGames = boardGameRepository.GetAllEntities();
            }
            else
            {
                boardGames = boardGameRepository.GetEntities(maxEntitiesCount);
            }

            return boardGames;
        }

        public void InsertEntityToDb(BoardGame entity)
        {
            IRepository<BoardGame> boardGameRepository = GetRepository();
            boardGameRepository.Insert(entity);
        }

        public void UpdateEntity(BoardGame entity)
        {
            IRepository<BoardGame> boardGameRepository = GetRepository();
            boardGameRepository.Update(entity);
        }

        public IRepository<BoardGame> GetRepository()
        {
            return new BoardGameRepository<BoardGame>(ConnectionString);
        }
    }
}
