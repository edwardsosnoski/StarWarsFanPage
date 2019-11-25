using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using StarWarsFanPage.Models;

namespace StarWarsFanPage.StarWarsServices
{
    public class PlanetStore : IPlanetStore
    {
        public async Task<PlanetResponse> GetPlanetById(int planetId)
        {
            using(var httpClient = new HttpClient { BaseAddress = new Uri("https://swapi.co/api/") })
            {
                var result = await httpClient.GetStringAsync($"planets/{planetId}");
                return JsonConvert.DeserializeObject<PlanetResponse>(result);
            }
        }

        public async Task<PageOfPlanetsResponse> GetPageOfPlanets(int pageNumber)
        {
            using (var httpClient = new HttpClient { BaseAddress = new Uri("https://swapi.co/api/") })
            {
                var result = await httpClient.GetStringAsync($"planets/?page={pageNumber}");
                return JsonConvert.DeserializeObject<PageOfPlanetsResponse>(result);
            }
        }

        public async Task<List<PlanetResponse>> GetListOfAllPlanets()
        {
            int planetPage = 0;
            var listOfPlanets = new List<PlanetResponse>();
            PageOfPlanetsResponse allPlanets;

            do
            {
                planetPage++;
                allPlanets = await GetPageOfPlanets(planetPage);

                foreach (var result in allPlanets.Results)
                {
                    listOfPlanets.Add(result);
                }
            }
            while (allPlanets.Next != null);

            return listOfPlanets;
        }
    }
}