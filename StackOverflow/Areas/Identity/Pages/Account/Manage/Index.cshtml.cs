﻿using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StackOverflow.Models;

namespace StackOverflow.Areas.Identity.Pages.Account.Manage;

public class IndexModel : PageModel
{
    private readonly SignInManager<User> _signInManager;
    private readonly UserManager<User> _userManager;

    public IndexModel(
        UserManager<User> userManager,
        SignInManager<User> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public string Username { get; set; }

    [TempData] public string StatusMessage { get; set; }

    [BindProperty] public InputModel Input { get; set; }

    private async Task LoadAsync(User user)
    {
        var userName = await _userManager.GetUserNameAsync(user);

        Username = userName;

        Input = new InputModel
        {
            PhoneNumber = user.PhoneNumber,
            Name = user.Name,
            Surname = user.Surname,
            Login = user.Login,
            Rating = user.Rating
        };
    }

    public async Task<IActionResult> OnGetAsync()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null) return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");

        await LoadAsync(user);
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null) return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");

        if (!ModelState.IsValid)
        {
            await LoadAsync(user);
            return Page();
        }

        user.Name = Input.Name;
        user.Surname = Input.Surname;
        user.PhoneNumber = Input.PhoneNumber;
        user.Login = Input.Login;

        await _userManager.UpdateAsync(user);

        await _signInManager.RefreshSignInAsync(user);
        StatusMessage = "Your profile has been updated";
        return RedirectToPage();
    }

    public class InputModel
    {
        [Phone]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Name")] public string Name { get; set; }

        [Display(Name = "Surname")] public string Surname { get; set; }

        [Display(Name = "Login")] public string Login { get; set; }

        [Display(Name = "Rating")] public float? Rating { get; set; }
    }
}