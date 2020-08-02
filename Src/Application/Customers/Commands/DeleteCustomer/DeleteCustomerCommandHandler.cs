using MediatR;
using RiSAT.Eshop.Application.Common.Exceptions;
using RiSAT.Eshop.Application.Common.Interfaces;
using RiSAT.Eshop.Domain.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RiSAT.Eshop.Application.Customers.Commands.DeleteCustomer
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand>
    {
        private readonly IRiSATeshopDbContext _context;

        public DeleteCustomerCommandHandler(IRiSATeshopDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Customers
                .FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Customer), request.Id);
            }

            var hasOrders = _context.Orders.Any(o => o.CustomerId == entity.CustomerId);
            if (hasOrders)
            {
                throw new DeleteFailureException(nameof(Customer), request.Id, "There are existing orders associated with this customer.");
            }

            _context.Customers.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
