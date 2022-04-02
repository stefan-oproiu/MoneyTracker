namespace Application.Common.Models
{
    public static class Constants
    {
        // Generic error messages
        public const string ValidationErrorTitle = "One or more validation errors occured";
        public const string ForbiddenAccessErrorTitle = "The user is not allowed to access this resource";
        public const string NotFoundErrorTitle = "The specified resource was not found";
        public const string ConflictErrorTitle = "Conflict with the current state of the target resource";
        public const string UnhandledServerErrorTitle = "Server error";

        // Specific error messages
        public const string UnhandledServerErrorMessage = "Server error";
        public const string OperationCancelledErrorMessage = "Operation cancelled";
        public const string DbUpdateErrorMessage = "Database update error";
        public const string UserAlreadyRegisteredErrorMessage = "The user is already registered";

        // Error types
        public const string ValidationErrorType = "https://tools.ietf.org/html/rfc7231#section-6.5.1";
        public const string ForbiddenAccessErrorType = "https://tools.ietf.org/html/rfc7231#section-6.5.3";
        public const string NotFoundErrorType = "https://tools.ietf.org/html/rfc7231#section-6.5.4";
        public const string ConflictErrorType = "https://tools.ietf.org/html/rfc7231#section-6.5.8";
        public const string UnhandledServerErrorType = "https://tools.ietf.org/html/rfc7231#section-6.6.1";

        // Configuration
        public const string ConnectionStringConfigPath = "ConnectionStrings:DefaultConnection";
        public const string AuthDomainConfigPath = "Auth:Domain";
        public const string AuthClientIdConfigPath = "Auth:ClientId";
        public const string AuthAudienceConfigPath = "Auth:Audience";
        public const string AdminRole = "Admin";
    }
}
