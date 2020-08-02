using System;
using AutoMapper;
using RiSAT.Eshop.Application.Common.Mappings;
using RiSAT.Eshop.Persistence;
using Xunit;

namespace RiSAT.Eshop.Application.UnitTests.Common
{
    public class QueryTestFixture : IDisposable
    {
        public RiSATeshopDbContext Context { get; private set; }
        public IMapper Mapper { get; private set; }

        public QueryTestFixture()
        {
            Context = RiSATeshopContextFactory.Create();

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            Mapper = configurationProvider.CreateMapper();
        }

        public void Dispose()
        {
            RiSATeshopContextFactory.Destroy(Context);
        }
    }

    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
}