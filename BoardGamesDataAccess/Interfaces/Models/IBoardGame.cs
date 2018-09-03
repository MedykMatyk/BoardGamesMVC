﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGamesDataAccess.Interfaces.Models
{
    public interface IBoardGame : IBoardGameLite
    {
        int MinPlayersNumber { get; set; }
        int MaxPlayersNumber { get; set; }
    }
}
