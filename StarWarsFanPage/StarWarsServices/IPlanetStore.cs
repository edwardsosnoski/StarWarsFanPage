using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StarWarsFanPage.Models;

namespace StarWarsFanPage.StarWarsServices
{
    public interface IPlanetStore
    {
        Task<PlanetResponse> GetPlanetById(int planetId);
        Task<PageOfPlanetsResponse> GetPageOfPlanets(int pageNumber);
        Task<List<PlanetResponse>> GetListOfAllPlanets();
    }
}