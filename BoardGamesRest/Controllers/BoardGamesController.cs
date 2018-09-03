using BoardGamesDataAccess.Enums;
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
    public class BoardGamesController : ApiController
    {
        [HttpGet]
        public BoardGame GetGameDetails(int id)
        {
            BoardGameService boardGameService = new BoardGameService(ConfigData.Instance.BoardGamesConnectionString, Source.Rest);
            BoardGame boardGame = boardGameService.GetFromDb(id);

            return boardGame;
        }
    }
}
