using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupportingIELTSWriting.Infrastructure
{
    public static class GenerateExtensions
    {
        public static string GetUserId(this HttpContext http)
        {
            if(http.User == null)
            {
                return string.Empty;
            }
            return http.User.Claims.Single(p => p.Type == "id").Value;
        }

    }
}
