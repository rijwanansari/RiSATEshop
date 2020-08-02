using MediatR;
using RiSAT.Eshop.Application.Common.Exceptions;
using RiSAT.Eshop.Application.Common.Interfaces;
using RiSAT.Eshop.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace RiSAT.Eshop.Application.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommand : IRequest
    {
        public int Id { get; set; }

        public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
        {
            private readonly IRiSATeshopDbContext _context;

            public DeleteCategoryCommandHandler(IRiSATeshopDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.Categories
                    .FindAsync(request.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Category), request.Id);
                }

                _context.Categories.Remove(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
