using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RiSAT.Eshop.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace RiSAT.Eshop.Application.Categories.Queries.GetCategoriesList
{
    public class GetCategoriesListQueryHandler : IRequestHandler<GetCategoriesListQuery, CategoriesListVm>
    {
        private readonly IRiSATeshopDbContext _context;
        private readonly IMapper _mapper;

        public GetCategoriesListQueryHandler(IRiSATeshopDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CategoriesListVm> Handle(GetCategoriesListQuery request, CancellationToken cancellationToken)
        {
            var categories = await _context.Categories
                .ProjectTo<CategoryDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            var vm = new CategoriesListVm
            {
                Categories = categories,
                Count = categories.Count
            };

            return vm;
        }
    }
}