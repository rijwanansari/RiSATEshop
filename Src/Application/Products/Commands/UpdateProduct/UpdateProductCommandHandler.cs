using System.Threading;
using System.Threading.Tasks;
using MediatR;
using RiSAT.Eshop.Application.Common.Exceptions;
using RiSAT.Eshop.Application.Common.Interfaces;
using RiSAT.Eshop.Domain.Entities;

namespace RiSAT.Eshop.Application.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly IRiSATeshopDbContext _context;

        public UpdateProductCommandHandler(IRiSATeshopDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Products.FindAsync(request.ProductId);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Product), request.ProductId);
            }

            entity.ProductId = request.ProductId;
            entity.ProductName = request.ProductName;
            entity.CategoryId = request.CategoryId;
            entity.SupplierId = request.SupplierId;
            entity.UnitPrice = request.UnitPrice;
            entity.Discontinued = request.Discontinued;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
