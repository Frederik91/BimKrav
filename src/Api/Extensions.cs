using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BimKrav.Api;

public static class Extensions
{
    public static int? TryParseIntNullable(this StringValues val)
    {
        return int.TryParse(val, out int outValue) ? outValue : null;
    }
}
