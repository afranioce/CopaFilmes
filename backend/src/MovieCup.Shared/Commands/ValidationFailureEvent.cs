using FluentValidation.Results;
using System.Collections.Generic;

namespace MovieCup.Shared.Commands
{
    public class ValidationFailureEvent : ICommandResult
    {
        public ValidationFailureEvent(IEnumerable<ValidationFailure> failures)
        {
            Failures = failures;
        }

        public IEnumerable<ValidationFailure> Failures { get; }
    }
}
