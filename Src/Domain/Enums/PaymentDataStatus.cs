using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enums
{
    public enum PaymentDataStatus
    {
        Pending = 1,
        Success,
        Failed,
        Canceled
    }
}
