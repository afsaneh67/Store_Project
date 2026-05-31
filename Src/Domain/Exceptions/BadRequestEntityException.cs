using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class BadRequestEntityException:BaseException
    {
        public BadRequestEntityException(List<string> message) : base(message) { }
        public BadRequestEntityException(string message) : base(message) { }
        public BadRequestEntityException() : base("خطایی رخ داده است. مجددا تلاش کنید") { }
    }
}
