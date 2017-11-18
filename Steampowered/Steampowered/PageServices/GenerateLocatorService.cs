using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steampowered.PageServices
{
    public static class GenerateLocatorService
    {
        public static string GenerateStringLocator(string template, string value)
        {
            return string.Format(template, value);
        }
    }
}
