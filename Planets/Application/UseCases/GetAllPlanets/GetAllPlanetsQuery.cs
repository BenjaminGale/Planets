namespace Planets.Application.UseCases.GetAllPlanets
{
    public class GetAllPlanetsQuery
    {
        private readonly IPlanetRepository _planetRepository;

        public GetAllPlanetsQuery(IPlanetRepository planetRepository) =>
            _planetRepository = planetRepository;

        public IEnumerable<PlanetSummaryDto> Execute() =>
            _planetRepository
                .GetAll()
                .Select(p => new PlanetSummaryDto { Name = p.Name });
    }
}
