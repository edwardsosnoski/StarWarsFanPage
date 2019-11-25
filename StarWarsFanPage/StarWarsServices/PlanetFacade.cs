using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StarWarsFanPage.Models;

namespace StarWarsFanPage.StarWarsServices
{
    public class PlanetFacade : IPlanetFacade
    {
        private readonly IPlanetStore _planetStore;

        public PlanetFacade(IPlanetStore planetStore)
        {
            _planetStore = planetStore;
        }

        public async Task<PlanetsListViewModel> PopulatePlanetsListViewModel()
        {
            var allPlanets = await _planetStore.GetListOfAllPlanets();
            var planetsListViewModel = new PlanetsListViewModel();
            planetsListViewModel.ListOfPlanets = new List<PlanetViewModel>();

            foreach (var planet in allPlanets)
            {
                var planetViewModel = new PlanetViewModel();

                planetViewModel.Name = planet.Name;
                planetViewModel.Url = planet.Url;

                planetsListViewModel.ListOfPlanets.Add(planetViewModel);
            }

            return planetsListViewModel;
        }

        public PlanetViewModel PopulatePlanetViewModel(PlanetResponse planetResponse)
        {
            var planetViewModel = new PlanetViewModel();

            planetViewModel.Name = planetResponse.Name;
            planetViewModel.Url = planetResponse.Url;

            return planetViewModel;
        }
    }
}
