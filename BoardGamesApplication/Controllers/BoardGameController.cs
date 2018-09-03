using BoardGamesDataAccess.Enums;
using BoardGamesDataAccess.Models;
using BoardGamesDataAccess.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BoardGamesApplication.Controllers
{
    public class BoardGameController : Controller
    {
        // GET: BoardGame
        public ActionResult Index(int gameId)
        {
            BoardGameService boardGameService = new BoardGameService(ConfigData.Instance.BoardGamesConnectionString, Source.Application);
            BoardGame boardGame = boardGameService.GetFromDb(gameId);
            return RedirectToAction("Details", new { gameId });
        }

        public ActionResult Details(int gameId)
        {
            BoardGameService boardGameService = new BoardGameService(ConfigData.Instance.BoardGamesConnectionString, Source.Application);
            BoardGame boardGame = boardGameService.GetFromDb(gameId);

            LogService logService = new LogService(ConfigData.Instance.BoardGamesConnectionString, Source.Application);
            ViewBag.Logs = logService.GetEntityLogs(gameId, 10);
            return View(boardGame);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(BoardGame boardGame)
        {
            if (ModelState.IsValid)
            {
                if(boardGame.MinPlayersNumber<1 || boardGame.MaxPlayersNumber<1 || boardGame.MaxPlayersNumber<boardGame.MinPlayersNumber)
                {
                    TempData["InvalidDataMessage"] = "Number of players is invalid";
                    return View();
                }
                BoardGameService boardGameService = GetService();
                boardGameService.InsertEntityToDb(boardGame);
                return RedirectToAction("Index", "BoardGameLite");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int gameId)
        {
            BoardGameService boardGameService = GetService();
            BoardGame boardGame = boardGameService.GetFromDb(gameId);
            return View(boardGame);
        }
        [HttpPost]
        public ActionResult Edit(BoardGame boardGame)
        {
            if(ModelState.IsValid)
            {
                BoardGameService boardGameService = GetService();
                boardGameService.UpdateEntity(boardGame);
                return RedirectToAction("Index", "BoardGameLite");
            }
            return View();
        }

        BoardGameService GetService()
        {
            return new BoardGameService(ConfigData.Instance.BoardGamesConnectionString, Source.Application);
        }
    }
}