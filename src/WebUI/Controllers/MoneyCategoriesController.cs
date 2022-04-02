using Application.Common.Interfaces;
using Application.MoneyCategories.Queries;
using Application.MoneyCategories.ViewModels;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    [Route("api/money-categories")]
    [ApiController]
    [Authorize]
    public class MoneyCategoriesController : BaseController
    {
        public MoneyCategoriesController(IMediator mediator, IMapper mapper, ICurrentUserService currentUserService)
            : base(mediator, mapper, currentUserService)
        {
        }

        [HttpGet]
        public Task<IActionResult> GetMoneyCategories()
        {
            var query = new GetMoneyCategoriesQuery();
            return Handle<GetMoneyCategoriesQuery, ICollection<MoneyCategoryViewModel>>(query);
        }
    }
}
