using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Planets.Application;
using Planets.Application.UseCases.GetAllPlanets;
using Planets.Domain;

namespace Planets.UnitTests
{
    [TestClass]
    public class GetAllPlanetsQueryTests
    {
        [DataTestMethod]
        [DynamicData(nameof(GetTestData), DynamicDataSourceType.Method)]
        public void GivenAGetAllPlanetsQuery_WhenExecuted_ThenTheExpectedPlanetSummariesAreReturned(
            IEnumerable<Planet> planets,
            IEnumerable<PlanetSummaryDto> expectedResult)
        {
            var planetRepositoryMock = new Mock<IPlanetRepository>();
            planetRepositoryMock
                .Setup(r => r.GetAll())
                .Returns(planets);

            var sut = new GetAllPlanetsQuery(planetRepositoryMock.Object);
            var result = sut.Execute();

            result
                .Should()
                .BeEquivalentTo(expectedResult, options => options.WithStrictOrdering());
        }

        public static IEnumerable<object[]> GetTestData()
        {
            yield return new object[]
            {
                Enumerable.Empty<Planet>(),
                Enumerable.Empty<PlanetSummaryDto>()
            };

            yield return new object[]
            {
                new List<Planet> { Planet.Earth },
                new List<PlanetSummaryDto> { new PlanetSummaryDto { Name = "Earth" } }
            };

            yield return new object[]
            {
                new List<Planet> { Planet.Uranus, Planet.Saturn },
                new List<PlanetSummaryDto>
                {
                    new PlanetSummaryDto { Name = "Uranus" },
                    new PlanetSummaryDto { Name = "Saturn" }
                }
            };

            yield return new object[]
            {
                new List<Planet> { Planet.Jupiter, Planet.Venus, Planet.Mercury },
                new List<PlanetSummaryDto>
                {
                    new PlanetSummaryDto { Name = "Jupiter" },
                    new PlanetSummaryDto { Name = "Venus" },
                    new PlanetSummaryDto { Name = "Mercury" }
                }
            };
        }
    }
}
