using Planets.Application;
using Planets.Domain;

namespace Planets.Infrastructure
{
    public class InMemoryPlanetRepository : IPlanetRepository
    {
        private static readonly Planet[] Planets = new[]
        {
            new Planet { Name = "Mercury", DiameterKm = 4_879 ,  DistanceFromSunKm = 57_900_000 },
            new Planet { Name = "Venus",   DiameterKm = 12_104,  DistanceFromSunKm = 108_200_000 },
            new Planet { Name = "Earth",   DiameterKm = 12_756,  DistanceFromSunKm = 149_600_000 },
            new Planet { Name = "Mars",    DiameterKm = 6_792,   DistanceFromSunKm = 227_900_000 },
            new Planet { Name = "Jupiter", DiameterKm = 142_984, DistanceFromSunKm = 778_600_000 },
            new Planet { Name = "Saturn" , DiameterKm = 120_536, DistanceFromSunKm = 1_433_500_000 },
            new Planet { Name = "Uranus",  DiameterKm = 51_118,  DistanceFromSunKm = 2_872_500_000 },
            new Planet { Name = "Neptune", DiameterKm = 49_528,  DistanceFromSunKm = 4_495_100_000 },
        };

        public Planet? Get(string planetName) =>
            Planets
                .FirstOrDefault(p => string.Equals(p.Name, planetName, StringComparison.OrdinalIgnoreCase));

        public IEnumerable<Planet> GetAll() =>
            Planets
                .ToList();
    }
}
