using System;
using System.Collections.Generic;

namespace StarWarsFanPage.Models
{
    public class PageOfPlanetsResponse
    {
        public int Count { get; set; }
        public string Next { get; set; }
        public string Previous { get; set; }
        public List<PlanetResponse> Results { get; set; }
    }
}