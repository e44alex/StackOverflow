﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using StackOverflowWebApi.Models;
using StackOverflowWebApi.Services;

namespace StackOverflow.Areas.Identity.Pages.Account
{

    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly ILogger _logger;
        private readonly IApiClient _apiClient;

        public RegisterModel(IApiClient apiClient, ILogger logger)
        {
            _apiClient = apiClient;
            _logger = logger;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required]
            [Display(Name = "Name")]
            public string Name{ get; set; }

            [Required]
            [Display(Name = "Surname")]
            public string Surname{ get; set; }


            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    Name = Input.Name,
                    Surname = Input.Surname,
                    Login = Input.Email.Substring(0, Input.Email.IndexOf('@')),
                    Email = Input.Email,
                    DateRegistered = DateTime.Now
                };
                var result = await _apiClient.AddUserAsync(user);
                if (result)
                {
                    _logger.LogInformation("User created a new account with password.");

                    if (await _apiClient.Authenticate(user.Login, Input.Password))
                    {
                        HttpContext.Response.Cookies.Append("token", "true");
                        HttpContext.Response.Cookies.Append("user", "e44alex");
                        return Redirect("~/");
                    }
                    return Redirect("~/Account/Login");
                }

            }
            // If we got this far, something failed, redisplay form
            return Page();

        }
    }
}
