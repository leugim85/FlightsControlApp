using System.Collections.Generic;

namespace Business.Services
{
    public interface ICitiesService
    {
        bool AddCity(string cityName);

        List<string> GetCities();
        
        int GetId(string name);
    }
}