using BoardGamesDataAccess.Interfaces;
using BoardGamesDataAccess.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BoardGamesDataAccess.Models
{
    public class BoardGame : IBoardGame
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int MinPlayersNumber { get; set; }
        [Required]
        public int MaxPlayersNumber { get; set; }
        public BoardGame()
        {

        }

        public BoardGame(string name, int minPlayersNumber, int maxPlayersNumber)
        {
            Name = name;
            MinPlayersNumber = minPlayersNumber;
            MaxPlayersNumber = maxPlayersNumber;
        }

        public BoardGame(int id, string name, int minPlayersNumber, int maxPlayersNumber)
        {
            Id = id;
            Name = name;
            MinPlayersNumber = minPlayersNumber;
            MaxPlayersNumber = maxPlayersNumber;
        }
    }
}