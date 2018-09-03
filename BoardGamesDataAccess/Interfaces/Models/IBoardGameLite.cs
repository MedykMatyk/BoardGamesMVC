using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGamesDataAccess.Interfaces.Models
{
    public interface IBoardGameLite
    {
        int Id { get; }
        string Name { get; set; }
    }
}
