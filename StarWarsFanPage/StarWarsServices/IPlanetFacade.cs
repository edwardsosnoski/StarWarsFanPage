using System;
using System.Threading.Tasks;
using StarWarsFanPage.Models;

namespace StarWarsFanPage.StarWarsServices
{
    public interface IPlanetFacade
    {
        PlanetViewModel PopulatePlanetViewModel(PlanetResponse planetResponse);
        Task<PlanetsListViewModel> PopulatePlanetsListViewModel();
    }
}