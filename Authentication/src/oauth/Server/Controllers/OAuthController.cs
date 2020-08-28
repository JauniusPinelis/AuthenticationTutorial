using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Controllers
{
    public class OAuthController : Controller
    {
        [HttpGet]
        public IActionResult Authorize(
            string response_type,
            string client_id,
            string redirect_uri,
            string scope,
            string state
            )
        {
            return View();
        }

        [HttpPost]
        public IActionResult Authorize(string response_type,
            string client_id,
            string redirect_uri,
            string scope,
            string state,
            string username)
        {
            return View();
        }

        public IActionResult Token()
        {
            return View();
        }
    }
}
