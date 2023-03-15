using Planets.Application;
using Planets.Domain;

namespace Planets.Infrastructure
{
    public class InMemoryPlanetRepository : IPlanetRepository
    {
        private static readonly IEnumerable<Planet> AllPlanets = new List<Planet>
        {
            Planet.Mercury,
            Planet.Venus,
            Planet.Earth,
            Planet.Mars,
            Planet.Jupiter,
            Planet.Saturn,
            Planet.Uranus,
            Planet.Neptune
        };

        public Planet? Get(string planetName) =>
            AllPlanets
                .FirstOrDefault(p => string.Equals(p.Name, planetName, StringComparison.OrdinalIgnoreCase));

        public IEnumerable<Planet> GetAll() =>
            AllPlanets;
    }
}
