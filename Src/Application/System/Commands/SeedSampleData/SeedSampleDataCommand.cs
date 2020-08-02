using MediatR;
using RiSAT.Eshop.Application.Common.Interfaces;
using RiSAT.Eshop.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace RiSAT.Eshop.Application.System.Commands.SeedSampleData
{
    public class SeedSampleDataCommand : IRequest
    {
    }

    public class SeedSampleDataCommandHandler : IRequestHandler<SeedSampleDataCommand>
    {
        private readonly IRiSATeshopDbContext _context;
        private readonly IUserManager _userManager;

        public SeedSampleDataCommandHandler(IRiSATeshopDbContext context, IUserManager userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<Unit> Handle(SeedSampleDataCommand request, CancellationToken cancellationToken)
        {
            var seeder = new SampleDataSeeder(_context, _userManager);

            await seeder.SeedAllAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
