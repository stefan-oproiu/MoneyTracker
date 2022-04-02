using Application.Common.Errors;
using Application.Common.Interfaces;
using Application.MoneyCategories.ViewModels;
using AutoMapper;
using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.MoneyCategories.Queries
{
    public class GetMoneyCategoriesQuery :
        IRequest<Result<ICollection<MoneyCategoryViewModel>, BaseError>>
    {
    }

    public class GetMoneyCategoriesQueryHandler :
        IRequestHandler<GetMoneyCategoriesQuery, Result<ICollection<MoneyCategoryViewModel>, BaseError>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetMoneyCategoriesQueryHandler(
            IApplicationDbContext dbContext,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<Result<ICollection<MoneyCategoryViewModel>, BaseError>> Handle(GetMoneyCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = await _dbContext.MoneyCategories.ToListAsync();

            var categoriesViewModels = _mapper.Map<ICollection<MoneyCategoryViewModel>>(categories);

            return Result.Success<ICollection<MoneyCategoryViewModel>, BaseError>(categoriesViewModels);
        }
    }
}
