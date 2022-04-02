using Application.Common.Errors;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Common.Models;
using AutoMapper;
using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebUI.Extensions;

namespace WebUI.Controllers
{
    public class BaseController : ControllerBase
    {
        private readonly ISender _mediator;
        protected readonly ICurrentUserService CurrentUserService;
        protected readonly IMapper Mapper;

        public BaseController(IMediator mediator, IMapper mapper, ICurrentUserService currentUserService)
        {
            _mediator = mediator;
            Mapper = mapper;
            CurrentUserService = currentUserService;
        }

        protected async Task<IActionResult> Handle<TRequest, TSuccess>(
            TRequest request,
            Func<TSuccess, IActionResult> successHandler,
            Func<BaseError, IActionResult> errorHandler,
            CancellationToken cancellationToken = default)
            where TRequest : IRequest<Result<TSuccess, BaseError>>
        {
            Result<TSuccess, BaseError> result;
            try
            {
                result = await _mediator.Send(request, cancellationToken);
            }
            catch (ValidationException e)
            {
                result = Result.Failure<TSuccess, BaseError>(new ValidationError(e.Message));
            }
            catch (Exception)
            {
                result = Result.Failure<TSuccess, BaseError>(new UnhandledServerError(Constants.UnhandledServerErrorMessage));
            }

            return result.Match(successHandler, errorHandler);
        }

        protected Task<IActionResult> Handle<TRequest, TSuccess>(
            TRequest request,
            Func<TSuccess, IActionResult> successHandler,
            CancellationToken cancellationToken = default)
            where TRequest : IRequest<Result<TSuccess, BaseError>>
        {
            return Handle(request, successHandler, DefaultErrorHandler, cancellationToken);
        }

        protected Task<IActionResult> Handle<TRequest, TSuccess>(
            TRequest request,
            CancellationToken cancellationToken = default)
            where TRequest : IRequest<Result<TSuccess, BaseError>>
        {
            return Handle<TRequest, TSuccess>(request, value => Ok(value), DefaultErrorHandler, cancellationToken);
        }

        private IActionResult DefaultErrorHandler(BaseError failure)
        {
            var problemDetails = failure.ToProblemDetails();

            return failure switch
            {
                ValidationError => BadRequest(problemDetails),
                ForbiddenAccessError error => StatusCode(error.Status, problemDetails),
                NotFoundError => NotFound(problemDetails),
                ConflictError => Conflict(problemDetails),
                UnhandledServerError error => StatusCode(error.Status, problemDetails),
                _ => throw new InvalidOperationException()
            };
        }
    }
}
