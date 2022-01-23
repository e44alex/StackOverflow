using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StackOverflow.Models;

namespace StackOverflow.Controllers;

public class UserController : Controller
{
    private readonly UserManager<User> _userManager;

    public UserController(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    public async Task<IActionResult> UserPage(Guid id)
    {
        var user = await _userManager.FindByIdAsync(id.ToString());

        return View(user);
    }
}