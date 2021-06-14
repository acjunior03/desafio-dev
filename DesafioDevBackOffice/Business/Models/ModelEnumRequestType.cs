using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
    public enum ModelEnumRequestType
    {
        GET = 0,
        POST = 1,
        PUT = 2,
        DELETE = 3,
        PATCH = 4
    }
}
