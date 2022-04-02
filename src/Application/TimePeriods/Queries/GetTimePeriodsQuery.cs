using Application.Common.Errors;
using Application.Common.Interfaces;
using Application.Common.Mappings;
using Application.TimePeriods.ViewModels;
using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.TimePeriods.Queries
{
    public class GetTimePeriodsQuery :
        IRequest<Result<ICollection<TimePeriodViewModel>, BaseError>>,
        IMapFrom<ICurrentUserService>
    {
        public string UserId { get; set; }
    }

    public class GetTimePeriodsQueryHandler : IRequestHandler<GetTimePeriodsQuery, Result<ICollection<TimePeriodViewModel>, BaseError>>
    {
        private readonly IApplicationDbContext _dbContext;

        public GetTimePeriodsQueryHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Result<ICollection<TimePeriodViewModel>, BaseError>> Handle(GetTimePeriodsQuery request, CancellationToken cancellationToken)
        {
            var entries = _dbContext.MoneyEntries
                .Where(e => e.UserId == request.UserId)
                .OrderBy(e => e.Date)
                .Select(e => new DateTime?(e.Date));

            var startDate = await entries.FirstOrDefaultAsync();
            var endDate = await entries.LastOrDefaultAsync();
            
            if (startDate is null || endDate is null)
            {
                return Result.Success<ICollection<TimePeriodViewModel>, BaseError>(Array.Empty<TimePeriodViewModel>());
            }

            var start = (DateTime)startDate;
            var end = (DateTime)endDate;

            var months = (end.Year - start.Year) * 12 + (end.Month - start.Month);
            var timePeriods = Enumerable.Range(0, months + 1)
                .Select(i => start.AddMonths(i))
                .Select(date =>
                {
                    var startDate = new DateTime(date.Year, date.Month, 1);
                    var endDate = startDate.AddMonths(1).AddDays(-1);
                    return new TimePeriodViewModel
                    {
                        Name = date.ToString("MMM yyyy"),
                        StartDate = startDate,
                        EndDate = endDate
                    };
                })
                .ToList();

            return Result.Success<ICollection<TimePeriodViewModel>, BaseError>(timePeriods);
        }
    }
}
