using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StackOverflowWebApi.Services;

namespace StackOverflow.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LogoutModel : PageModel
    {
        private readonly IApiClient _apiClient;
        public LogoutModel(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }


        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost(string returnUrl = null)
        {
            try
            {
                HttpContext.Response.Cookies.Delete("token");
                HttpContext.Response.Cookies.Delete("user");

            }
            catch (Exception)
            {
            }

            return Redirect("~/Account/Login");
        }
    }
}
