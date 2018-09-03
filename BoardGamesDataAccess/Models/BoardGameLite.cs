using BoardGamesDataAccess.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BoardGamesDataAccess.Models
{
    public class BoardGameLite : IBoardGameLite
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public BoardGameLite()
        {

        }
        public BoardGameLite(string name)
        {
            Name = name;
        }

        public BoardGameLite(int id, string name) : this(name)
        {
            Id = id;
        }
    }
}