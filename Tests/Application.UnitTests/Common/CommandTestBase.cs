using System;
using RiSAT.Eshop.Persistence;

namespace RiSAT.Eshop.Application.UnitTests.Common
{
    public class CommandTestBase : IDisposable
    {
        protected readonly RiSATeshopDbContext _context;

        public CommandTestBase()
        {
            _context = RiSATeshopContextFactory.Create();
        }

        public void Dispose()
        {
            RiSATeshopContextFactory.Destroy(_context);
        }
    }
}