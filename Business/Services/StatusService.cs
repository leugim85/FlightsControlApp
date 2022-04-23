using DataBase;
using System;
using System.Collections.Generic;

namespace Business.Services
{
    public class StatusService : IStatusService
    {
        private readonly IDatabaseConnection connection;

        public StatusService(IDatabaseConnection connection)
        {
            this.connection = connection ?? throw new ArgumentNullException(nameof(connection));
        }

        public bool AddStatus(string statusName)
        {
            var exists = connection.ValidateIfExists(statusName, "Status", "FligthStatus");

            if (!exists)
            {
                connection.AddStatus(statusName);
                return true;
            }
            return false;
        }

        public List<string> GetStatusList()
        {
            var statusList = connection.GetEntitiesName("Status", "FligthStatus");
            return statusList;
        }

        public int GetId(string name)
        {
            return connection.GetEntityId(name, "Status", "FligthStatus");
        }
    }
}

