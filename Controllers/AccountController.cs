using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

public class AccountController : Controller
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;

    public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    // Register
    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(string email, string password)
    {
        if (ModelState.IsValid)
        {
            try{
            var user = new IdentityUser { UserName = email, Email = email };
            var result = await _userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
                return RedirectToAction("Index", "Expense");
            }
            else{
                Console.WriteLine("Create not succeeded");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }} catch (Exception ex){
                Console.WriteLine($"Validation Error: {ex.Message}");
            }
        } else {
            foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
            {
                Console.WriteLine($"Validation Error: {error.ErrorMessage}");
            }
        }

        return View();
    }

    // Login
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(string email, string password)
    {
        if (ModelState.IsValid)
        {
            var result = await _signInManager.PasswordSignInAsync(email, password, isPersistent: false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Expense");
            }
            else {
                Console.WriteLine("Result not succeeded");
            }

            ModelState.AddModelError("", "Invalid login attempt.");
        } else {
            foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
            {
                Console.WriteLine($"Validation Error: {error.ErrorMessage}");
            }
        }

        return View();
    }

    // Logout
    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Login", "Account");
    }
}
