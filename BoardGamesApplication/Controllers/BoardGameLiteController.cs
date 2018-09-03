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
    public class BoardGameLiteController : Controller
    {
        // GET: BoardGameLite
        public ActionResult Index()
        {
            BoardGameLiteService boardGameLiteService = GetService();
            List<BoardGameLite> boardGameLite = boardGameLiteService.GetAllFromDb().ToList();
            return View(boardGameLite);
        }
        [HttpGet]
        public ActionResult Delete(int gameId, string gameName)
        {
            return View(new BoardGameLite(gameId, gameName));
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult Delete(int gameId)
        {
            BoardGameLiteService boardGameLiteService = GetService();
            boardGameLiteService.DeleteEntityFromDb(gameId);
            return RedirectToAction("Index");
        }
        //[HttpPost]
        //public ActionResult Delete(BoardGameLite boardGameLite)
        //{
        //    BoardGameLiteService boardGameLiteService = GetService();
        //    boardGameLiteService.DeleteEntityFromDb(boardGameLite.Id);
        //    return RedirectToAction("Index");
        //}
        BoardGameLiteService GetService()
        {
            return new BoardGameLiteService(ConfigData.Instance.BoardGamesConnectionString, Source.Application);
        }
    }
}