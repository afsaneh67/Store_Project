using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class BaseException:Exception
    {
        public List<string> Messages { get; set; }
        public BaseException():base()
        { }
        public BaseException(IEnumerable<ValidationFailure> validationFailure) : base(null)
        {
            Messages = validationFailure.Select(x=>x.ErrorMessage).ToList();
        }
        public BaseException(List<string> message):base(null)
        {
            Messages = message;
        }
        public BaseException(string message) : base(message)
        {
          
        }
    }
}
