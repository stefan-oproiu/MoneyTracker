using Application.Common.Interfaces;
using Application.TimePeriods.Queries;
using Application.TimePeriods.ViewModels;
using Application.Users.Commands;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    [Route("api/me")]
    [ApiController]
    [Authorize]
    public class MeController : BaseController
    {
        public MeController(IMediator mediator, IMapper mapper, ICurrentUserService currentUserService)
            : base(mediator, mapper, currentUserService)
        {
        }

        [Route("check")]
        public Task<IActionResult> CheckCurrentUser()
        {
            var command = Mapper.Map<CheckUserCommand>(CurrentUserService);
            return Handle<CheckUserCommand, Unit>(command);
        }

        [Route("time-periods")]
        public Task<IActionResult> GetTimePeriods()
        {
            var query = Mapper.Map<GetTimePeriodsQuery>(CurrentUserService);
            return Handle<GetTimePeriodsQuery, ICollection<TimePeriodViewModel>>(query);
        }
    }
}
