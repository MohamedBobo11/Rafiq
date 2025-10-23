using Rafiq.Domain.Common;
using Rafiq.Domain.Common.Results;
using Rafiq.Domain.Test.Enum;

namespace Rafiq.Domain.Test
{
    public sealed class Test : AuditableEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public TestState State { get; set; }

        private Test() { }

        public Test(Guid id, string title, string description, TestState state)
            : base(id)
        {
            Title = title;
            Description = description;
            State = state;
        }

        public static Result<Test> Create(Guid id, string title, string description, TestState state)
        {
            if (id == Guid.Empty)
                return TestErrors.TestIdRequired;

            if (string.IsNullOrWhiteSpace(title))
            {
                return TestErrors.TitleIsRequired;
            }

            if (string.IsNullOrWhiteSpace(description))
            {
                return TestErrors.DescriptionIsRequired;
            }

            var test = new Test(id, title, description, state);
            return test;
        }
    }
}