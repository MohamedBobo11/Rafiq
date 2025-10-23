using Rafiq.Domain.Common.Results;

namespace Rafiq.Domain.Test
{
    public static class TestErrors
    {
        public static Error TestIdRequired =>
            Error.Validation(code: "TestErrors.TestIdRequired", description: "Test Id is required.");
        public static Error TitleIsRequired =>
            Error.Validation(code: "TestErrors.TitleIsRequired", description: "Title is required.");

        public static Error DescriptionIsRequired =>
            Error.Validation(code: "TestErrors.DescriptionIsRequired", description: "Description is required.");
    }
}

