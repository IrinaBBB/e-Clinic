using e_Clinic.Hubs;
using e_Clinic.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace e_Clinic.Web.Controllers
{
    [AllowAnonymous]
    public class HubController : Controller
    {
        private readonly IHubContext<DeathlyHallowsHub> _deathlyHub;
        public HubController(IHubContext<DeathlyHallowsHub> deathlyHub)
        {
            _deathlyHub = deathlyHub;
        }

        public IActionResult List()
        {
            return View();
        }

        public async Task<IActionResult> DeathlyHallows(string type)
        {
            if (ClinicConstants.DeathlyHallowRace.ContainsKey(type))
            {
                ClinicConstants.DeathlyHallowRace[type]++;
            }
            await _deathlyHub.Clients.All.SendAsync("updateDealthyHallowCount",
               ClinicConstants.DeathlyHallowRace[ClinicConstants.Cloack],
               ClinicConstants.DeathlyHallowRace[ClinicConstants.Stone],
               ClinicConstants.DeathlyHallowRace[ClinicConstants.Wand]);
            return Accepted();
        }
    }
}
