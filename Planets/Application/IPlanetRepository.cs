using Planets.Domain;

namespace Planets.Application
{
    public interface IPlanetRepository
    {
        IEnumerable<Planet> GetAll();

        Planet? Get(string planetName);
    }
}
