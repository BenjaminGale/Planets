namespace Planets.Application.UseCases.GetPlanet
{
    public class GetPlanetQuery
    {
        private readonly IPlanetRepository _planetRepository;

        public GetPlanetQuery(IPlanetRepository planetRepository) =>
            _planetRepository = planetRepository;

        public PlanetDto? Execute(string planetName)
        {
            var planet = _planetRepository.Get(planetName);
            if (planet is null) return null;

            return new PlanetDto
            {
                Name = planet.Name,
                Diameter = planet.DiameterKm.ToString("N") + " km",
                DistanceFromSun = planet.DistanceFromSunKm.ToString("N") + " km",
                Mass = planet.MassKg.ToString("G") + "x10^24 kg",
                Type = planet.Type.ToString(),
            };
        }
    }
}
