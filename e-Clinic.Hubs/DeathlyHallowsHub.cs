using e_Clinic.Utility;
using Microsoft.AspNetCore.SignalR;

namespace e_Clinic.Hubs
{
    public class DeathlyHallowsHub : Hub
    {
        public Dictionary<string, int> GetRaceStatus()
        {
            return ClinicConstants.DeathlyHallowRace;
        }
    }
}
