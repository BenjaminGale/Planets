using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Planets.Application;
using Planets.Application.UseCases.GetPlanet;
using Planets.Domain;

namespace Planets.UnitTests
{
    [TestClass]
    public class GetPlanetQueryTests
    {
        [DataTestMethod]
        [DynamicData(nameof(GetTestData), DynamicDataSourceType.Method)]
        public void GivenAGetPlanetsQuery_WhenExecuted_ThenTheExpectedPlanetDtoIsReturned(
            string planetName,
            Planet planet,
            PlanetDto expectedResult)
        {
            var planetRepositoryMock = new Mock<IPlanetRepository>();
            planetRepositoryMock
                .Setup(r => r.Get(It.Is<string>(name => name == planetName)))
                .Returns(planet);

            var sut = new GetPlanetQuery(planetRepositoryMock.Object);
            var result = sut.Execute(planetName);

            result
                .Should()
                .BeEquivalentTo(expectedResult);
        }

        public static IEnumerable<object?[]> GetTestData()
        {
            yield return new object?[]
            {
                "Zebes",
                null,
                null
            };

            yield return new object?[]
            {
                "Earth",
                Planet.Earth,
                new PlanetDto
                {
                    Name = "Earth",
                    Diameter = "12,756.00 km",
                    DistanceFromSun = "149,600,000.00 km",
                    Mass = "5.97x10^24 kg",
                    Type = "Rocky",
                    ImageUrl = "images\\Earth.png"
                }
            };

            yield return new object?[]
            {
                "Earth",
                Planet.Jupiter,
                new PlanetDto
                {
                    Name = "Jupiter",
                    Diameter = "142,984.00 km",
                    DistanceFromSun = "778,600,000.00 km",
                    Mass = "1898x10^24 kg",
                    Type = "GasGiant",
                    ImageUrl = "images\\Jupiter.png"
                }
            };
        }
    }
}
