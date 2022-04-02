using Application.Common.Models;

namespace Application.Common.Errors
{
    public class UnhandledServerError : BaseError
    {
        public UnhandledServerError(string message) : base(500, message)
        {
        }

        public override string Type => Constants.UnhandledServerErrorType;

        public override string Title => Constants.UnhandledServerErrorTitle;
    }
}
