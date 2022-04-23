using System.Collections.Generic;

namespace Business.Services
{
    public interface IStatusService
    {
        bool AddStatus(string statusName);

        List<string> GetStatusList();
        
        int GetId(string name);
    }
}