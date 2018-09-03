using BoardGamesDataAccess.Enums;
using BoardGamesDataAccess.Interfaces.Models;
using BoardGamesDataAccess.Models;
using BoardGamesDataAccess.Services;
using BoardGamesRest.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BoardGamesRest.Controllers
{
    public class BoardGamesLiteController : ApiController
    {
        [HttpGet]
        public IEnumerable<BoardGameLite> GetGamesList(int gamesCount = -1)
        {
            BoardGameLiteService boardGameLiteService = new BoardGameLiteService(ConfigData.Instance.BoardGamesConnectionString, Source.Rest);
            IEnumerable<BoardGameLite> boardGame = boardGameLiteService.GetCollectionFromDb(gamesCount);

            return boardGame;
        }
    }
}
