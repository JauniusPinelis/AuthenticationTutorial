﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ApiTwo.Controllers
{
    public class HomeController : Controller
    {
		private readonly IHttpClientFactory _httpClientFactory;

		public HomeController(IHttpClientFactory httpclientFactory)
		{
			_httpClientFactory = httpclientFactory;
		}
    }
}
