using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class ValidationEntityException : BaseException
    {
        public ValidationEntityException(List<string> message) : base(message) { }
        public ValidationEntityException(string message) : base(message) { }
        public ValidationEntityException(IEnumerable<ValidationFailure> validationFailure) : base(validationFailure) { }
        public ValidationEntityException() : base("خطایی رخ داده است. مجددا تلاش کنید") { }
    }
}
