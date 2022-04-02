using Application.Common.Models;

namespace Application.Common.Errors
{
    public class NotFoundError : BaseError
    {
        public NotFoundError(string message) : base(404, message)
        {
        }

        public override string Type => Constants.NotFoundErrorType;

        public override string Title => Constants.NotFoundErrorTitle;
    }
}
