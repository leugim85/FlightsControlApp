using DataBase;
using System;
using System.Collections.Generic;

namespace Business.Services
{
    public class CitiesService : ICitiesService
    {
        private readonly IDatabaseConnection connection;
        public CitiesService(IDatabaseConnection connection)
        {
            this.connection = connection ?? throw new ArgumentNullException(nameof(connection));
        }

        public bool AddCity(string cityName)
        {
            var exists = connection.ValidateIfExists(cityName, "City", "Cities");

            if (!exists)
            {
                connection.AddCity(cityName);
                return true;
            }
            return false;
        }

        public List<string> GetCities()
        {
            var cities = connection.GetEntitiesName("City", "Cities");
            return cities;
        }

        public int GetId(string name)
        {
            return connection.GetEntityId(name, "City", "Cities");
        }
    }
}
