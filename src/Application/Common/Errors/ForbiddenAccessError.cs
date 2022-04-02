using Application.Common.Models;

namespace Application.Common.Errors
{
    public class ForbiddenAccessError : BaseError
    {
        public ForbiddenAccessError(string message) : base(403, message)
        {
        }

        public override string Type => Constants.ForbiddenAccessErrorType;

        public override string Title => Constants.ForbiddenAccessErrorTitle;
    }
}
