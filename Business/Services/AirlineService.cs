using DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class AirlineService : IAirlineService
    {
        private readonly IDatabaseConnection connection;

        public AirlineService(IDatabaseConnection connection)
        {
            this.connection = connection ?? throw new ArgumentNullException(nameof(connection));
        }

        public bool AddAirline(string airlineName)
        {
            var exists = connection.ValidateIfExists(airlineName, "AirLineName", "AirLines");

            if (!exists)
            {
                connection.AddAirline(airlineName);
                return true;
            }
            return false;
        }

        public List<string> GetAirlines()
        {
            var airlines = connection.GetEntitiesName("AirLineName", "AirLines");
            return airlines;
        }

        public int GetId(string name) 
        {
            return connection.GetEntityId(name, "AirLineName", "AirLines");
        }
    }
}
