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
    [Route("api/users")]
    [ApiController]
    [Authorize]
    public class UsersController : BaseController
    {
        public UsersController(IMediator mediator, IMapper mapper, ICurrentUserService currentUserService)
            : base(mediator, mapper, currentUserService)
        {
        }
    }
}
