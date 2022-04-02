using Application.Common.Models;

namespace Application.Common.Errors
{
    public class ValidationError : BaseError
    {
        public ValidationError(string message) : base(400, message)
        {
        }

        public override string Type => Constants.ValidationErrorType;

        public override string Title => Constants.ValidationErrorTitle;
    }
}
