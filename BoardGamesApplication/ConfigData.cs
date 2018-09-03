using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace BoardGamesApplication
{
    public class ConfigData
    {
        public string BoardGamesConnectionString { get; }
        private static ConfigData _instance;
        public static ConfigData Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new ConfigData();
                }
                return _instance;
            }
        }
        private ConfigData()
        {
            BoardGamesConnectionString = ConfigurationManager.ConnectionStrings["BoardGamesMVC"].ConnectionString;
        }
    }
}