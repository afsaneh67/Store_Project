using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Helpers
{
    public class IDGenerator
    {
        public static string GenerateCacheKeyFromRequest(HttpRequest request)
        {
            var KeyBuilder = new StringBuilder();
            KeyBuilder.Append($"{request.Path}");
            foreach (var a in request.Query.OrderBy(x => x.Key))
            {
                KeyBuilder.Append($"{a.Key}-{a.Value}");
            }
            return KeyBuilder.ToString();
        }
    }
}
