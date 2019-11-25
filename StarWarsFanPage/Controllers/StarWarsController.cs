using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StarWarsFanPage.StarWarsServices;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StarWarsFanPage.Controllers
{
    public class StarWarsController : Controller
    {
        private readonly IPlanetFacade _planetFacade;

        public StarWarsController(IPlanetFacade planetFacade)
        {
            _planetFacade = planetFacade;
        }

        // GET: /<controller>/
        public async Task<IActionResult> Home()
        {
            var model = await _planetFacade.PopulatePlanetsListViewModel();
            return View(model);
        }
    }
}