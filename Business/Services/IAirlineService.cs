using System.Collections.Generic;

namespace Business.Services
{
    public interface IAirlineService
    {
        bool AddAirline(string airlineName);

        List<string> GetAirlines();
        
        int GetId(string name);
    }
}