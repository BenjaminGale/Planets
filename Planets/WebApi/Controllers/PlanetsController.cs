using Microsoft.AspNetCore.Mvc;
using Planets.Application.UseCases.GetAllPlanets;
using Planets.Application.UseCases.GetPlanet;
using System.ComponentModel.DataAnnotations;

namespace Planets.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlanetsController : ControllerBase
    {
        private readonly GetAllPlanetsQuery _getAllPlanetsQuery;
        private readonly GetPlanetQuery _getPlanetQuery;

        public PlanetsController(GetAllPlanetsQuery getAllPlanetsQuery, GetPlanetQuery getPlanetQuery)
        {
            _getAllPlanetsQuery = getAllPlanetsQuery;
            _getPlanetQuery = getPlanetQuery;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<PlanetSummaryDto>))]
        public IEnumerable<PlanetSummaryDto> Get() =>
            _getAllPlanetsQuery.Execute();

        [HttpGet]
        [Route("{name}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PlanetDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(void))]
        public IActionResult GetPlanet([Required] string name)
        {
            var planet = _getPlanetQuery.Execute(name);
            return planet != null ? Ok(planet) : NotFound();
        }
    }
}
