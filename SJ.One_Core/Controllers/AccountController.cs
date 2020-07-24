using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SJ.One_Core.Models;
using SJ.One_Core.Models.AccountViewModels;
using System.Threading.Tasks;

namespace SJ.One_Core.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<User> userManager;
        private SignInManager<User> signInManager;

        public AccountController(UserManager<User> userMgr,
                SignInManager<User> signinMgr)
        {
            userManager = userMgr;
            signInManager = signinMgr;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerModel)
        {
            if (ModelState.IsValid)
            {
                User user = new User
                {
                    Email = registerModel.Email,
                    UserName = registerModel.Email,
                    Status = Status.Active
                };

                var result = await userManager.CreateAsync(user, registerModel.Password);
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(registerModel);
        }
    }
}
