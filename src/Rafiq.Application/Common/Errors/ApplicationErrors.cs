using Rafiq.Domain.Common.Results;

namespace Rafiq.Application.Common.Errors;

public static class ApplicationErrors
{
    // example error
    public static Error InvalidPaginationParameters =>
        Error.Validation(code: "ApplicationErrors.InvalidPaginationParameters", description: "The pagination parameters provided are invalid.");
}