using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
		{
            return View();
		}

        [Authorize]
        public IActionResult Secret()
        {
            return View();
        }

        public IActionResult Authenticate()
		{
            return RedirectToAction("Action");
		}

    }
}
