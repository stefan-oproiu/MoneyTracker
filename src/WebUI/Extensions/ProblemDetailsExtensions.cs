using Application.Common.Errors;
using Application.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Extensions
{
    public static class ProblemDetailsExtensions
    {
        public static ProblemDetails ToProblemDetails(this BaseError error)
        {
            return new ProblemDetails
            {
                Status = error.Status,
                Title = error.Title,
                Detail = error.Message,
                Type = error.Type
            };
        }
    }
}
