using BoardGamesDataAccess.Enums;
using BoardGamesDataAccess.Interfaces.Models;
using BoardGamesDataAccess.Interfaces.Repositories;
using BoardGamesDataAccess.Interfaces.Services;
using BoardGamesDataAccess.Models;
using BoardGamesDataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGamesDataAccess.Services
{
    public class BoardGameLiteService : EntityService, IEntityService
    {
        public BoardGameLiteService(string connectionString, Source source) : base(connectionString, source)
        {
        }
        public BoardGameLite GetFromDb(int entityId)
        {
            IRepository<BoardGameLite> boardGameLiteRepository = GetRepository();
            BoardGameLite boardGameLite = boardGameLiteRepository.GetEntityById(entityId);
            return boardGameLite;
        }

        public IEnumerable<BoardGameLite> GetAllFromDb()
        {
            IEnumerable<BoardGameLite> boardGamesLite = new List<BoardGameLite>();
            IRepository<BoardGameLite> boardGameLiteRepository = GetRepository();
            boardGamesLite = boardGameLiteRepository.GetAllEntities();
            return boardGamesLite;
        }

        public IEnumerable<BoardGameLite> GetCollectionFromDb(int maxEntitiesCount)
        {
            if (maxEntitiesCount == 0)
            {
                return new List<BoardGameLite>();
            }

            IEnumerable<BoardGameLite> boardGamesLite = new List<BoardGameLite>();
            IRepository<BoardGameLite> boardGameLiteRepository = GetRepository();


            if (maxEntitiesCount == -1)
            {
                boardGamesLite = boardGameLiteRepository.GetAllEntities();
            }
            else
            {
                boardGamesLite = boardGameLiteRepository.GetEntities(maxEntitiesCount);
            }

            return boardGamesLite;
        }

        public void DeleteEntityFromDb(int entityId)
        {
            BoardGameLiteRepository<BoardGameLite> boardGameLiteRepository = GetRepository();
            boardGameLiteRepository.Delete(entityId);
        }

        private BoardGameLiteRepository<BoardGameLite> GetRepository()
        {
            return new BoardGameLiteRepository<BoardGameLite>(ConnectionString);
        }
    }
}
