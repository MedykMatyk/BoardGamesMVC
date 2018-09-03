using BoardGamesDataAccess.Enums;
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
    public class LogService : EntityService, IEntityService
    {
        public LogService(string connectionString, Source source) : base(connectionString, source)
        {
        }

        internal void Insert(int entityId, DateTime dateTime, Source source)
        {
            IRepository<Log> logRepository = GetLogRepository();
            logRepository.Insert(new Log(entityId, DateTime.Now, source));
        }

        public IEnumerable<Log> GetEntityLogs(int entityId)
        {
            LogRepository<Log> logRepository = GetLogRepository();
            return logRepository.GetAllEntitiesByGameId(entityId);
        }

        public IEnumerable<Log> GetEntityLogs(int entityId, int logsCount, bool orderByDescending = true)
        {
            List<Log> logs = GetEntityLogs(entityId).ToList();
            if (orderByDescending)
            {
                logs = logs.OrderByDescending(x => x.Date).ToList();
            }
            else
            {
                logs = logs.OrderBy(x => x.Date).ToList();
            }
            return logs.Take(logsCount);
        }

        private LogRepository<Log> GetLogRepository()
        {
            return new LogRepository<Log>(ConnectionString);
        }
    }
}
