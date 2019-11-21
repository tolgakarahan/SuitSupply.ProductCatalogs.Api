using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Common.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException()
            : base("One or more validation failures have occurred.")
        {
            Failures = new List<string>();
        }

        public List<string> Failures { get; }

        public ValidationException(List<ValidationFailure> failures)
            : this()
        {
            Failures = failures.Select(x => x.ErrorMessage).ToList();
        }
    }
}
