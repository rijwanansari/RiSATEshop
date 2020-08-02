using System.Threading.Tasks;
using RiSAT.Eshop.Application.Customers.Queries.GetCustomersList;
using RiSAT.Eshop.WebUI.IntegrationTests.Common;
using Xunit;

namespace RiSAT.Eshop.WebUI.IntegrationTests.Controllers.Customers
{
    public class GetAll : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public GetAll(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task ReturnsCustomersListViewModel()
        {
            var client = await _factory.GetAuthenticatedClientAsync();

            var response = await client.GetAsync("/api/customers/getall");

            response.EnsureSuccessStatusCode();

            var vm = await Utilities.GetResponseContent<CustomersListVm>(response);

            Assert.IsType<CustomersListVm>(vm);
            Assert.NotEmpty(vm.Customers);
        }
    }
}
