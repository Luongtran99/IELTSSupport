using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SupportingIELTSWriting.Services;

namespace SupportingIELTSWriting.Controllers
{
    
    public class AuthController : Controller
    {
        private readonly IIdentityServices _services;
        public AuthController(IIdentityServices services)
        {
            _services = services;
        }
    }
}