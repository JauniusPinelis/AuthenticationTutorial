using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MvcClient.Controllers
{
    public class HomeController : Controller
    {
        private IHttpClientFactory _httpClientFactory;

		public HomeController(IHttpClientFactory httpClientFactory)
		{
            _httpClientFactory = httpClientFactory;
		}

        [Route("/home")]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> Secret()
        {
            var idToken = await HttpContext.GetTokenAsync("id_token");
            var refreshToken = await HttpContext.GetTokenAsync("refresh_token");

            await RefreshAccessToken();

            return View();
        }

        private async Task RefreshAccessToken()
		{
            var serverClient = _httpClientFactory.CreateClient();
            var discoveryDocument = await serverClient.GetDiscoveryDocumentAsync("https://localhost:44397/");

            var refreshToken = await HttpContext.GetTokenAsync("refresh_token");

            var refreshTokenClient = _httpClientFactory.CreateClient();

            var tokenResponse = await refreshTokenClient.RequestRefreshTokenAsync(new RefreshTokenRequest { 
                Address = discoveryDocument.TokenEndpoint,
                RefreshToken = refreshToken,
                ClientId = "client_id_mvc",
                ClientSecret = "client_secret_mvc",
            });

            var authInfo = await HttpContext.AuthenticateAsync("Cookie");

            authInfo.Properties.UpdateTokenValue("acess_token", tokenResponse.AccessToken);
            authInfo.Properties.UpdateTokenValue("id_token", tokenResponse.IdentityToken);
            authInfo.Properties.UpdateTokenValue("refresh_token", tokenResponse.RefreshToken);

            await HttpContext.SignInAsync("Cookie", authInfo.Principal, authInfo.Properties);
		}
    }
}
