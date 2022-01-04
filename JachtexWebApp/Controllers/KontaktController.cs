using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JachtexWebApp.Controllers
{
    public class KontaktController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
