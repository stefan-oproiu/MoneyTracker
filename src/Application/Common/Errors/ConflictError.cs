using Application.Common.Models;

namespace Application.Common.Errors
{
    public class ConflictError : BaseError
    {

        public ConflictError(string message) : base(409, message)
        {
        }

        public override string Type => Constants.ConflictErrorType;

        public override string Title => Constants.ConflictErrorTitle;
    }
}
