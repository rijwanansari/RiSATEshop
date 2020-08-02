using RiSAT.Eshop.Application.Customers.Queries.GetCustomerDetail;
using RiSAT.Eshop.Persistence;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using RiSAT.Eshop.Application.UnitTests.Common;
using Xunit;
using AutoMapper;

namespace RiSAT.Eshop.Application.UnitTests.Customers.Queries
{
    [Collection("QueryCollection")]
    public class GetCustomerDetailQueryHandlerTests
    { 
        private readonly RiSATeshopDbContext _context;
        private readonly IMapper _mapper;

        public GetCustomerDetailQueryHandlerTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }    

        [Fact]
        public async Task GetCustomerDetail()
        {
            var sut = new GetCustomerDetailQueryHandler(_context, _mapper);

            var result = await sut.Handle(new GetCustomerDetailQuery { Id = "JASON" }, CancellationToken.None);

            result.ShouldBeOfType<CustomerDetailVm>();
            result.Id.ShouldBe("JASON");
        }
    }
}
