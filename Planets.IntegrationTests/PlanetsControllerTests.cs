using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Planets.IntegrationTests
{
    [TestClass]
    public class PlanetsControllerTests
    {
        [TestMethod]
        public async Task TestGetAllPlanetsEndpoint()
        {
            var webApplicationFactory = new WebApplicationFactory<Program>();
            var httpClient = webApplicationFactory.CreateClient();

            var response = await httpClient.GetAsync("/api/planets");

            response.EnsureSuccessStatusCode();
        }

        [TestMethod]
        public async Task TestGetPlanetEndpointForKnownPlanet()
        {
            var webApplicationFactory = new WebApplicationFactory<Program>();
            var httpClient = webApplicationFactory.CreateClient();

            var response = await httpClient.GetAsync("/api/planets/earth");

            response.EnsureSuccessStatusCode();
        }
    }
}
