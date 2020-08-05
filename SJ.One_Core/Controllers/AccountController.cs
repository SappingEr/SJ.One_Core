using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SJ.One_Core.Models;
using SJ.One_Core.Models.AccountViewModels;
using System;
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
            if (!User.Identity.IsAuthenticated)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel registerModel)
        {
            if (ModelState.IsValid)
            {
                User user = new User
                {
                    Email = registerModel.Email,
                    UserName = registerModel.Email,
                    Status = Status.Active,
                    RegistrationDate = DateTime.Now.Date
                };

                var result = await userManager.CreateAsync(user, registerModel.Password);
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, false);
                    return RedirectToAction("СhooseUserGender", "Account", new { user.Id });
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

        [HttpGet]
        public async Task<IActionResult> СhooseUserGender(string id)
        {
            User user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                return View(new UserGenderViewModel { Id = id });
            }
            return BadRequest();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> СhooseUserGender(UserGenderViewModel genderModel)
        {
            if (ModelState.IsValid)
            {
                User user = await userManager.FindByIdAsync(genderModel.Id);
                if (user != null)
                {
                    user.Gender = genderModel.Gender;
                    IdentityResult result = await userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        if (!string.IsNullOrWhiteSpace(user.FullName))
                        {
                            return RedirectToAction("Info", "Account", new { genderModel.Id });
                        }
                        return RedirectToAction("UpdUserData", "Account", new { id = genderModel.Id, });
                    }
                    ModelState.AddModelError("", "Не удалось обновить данные пользователя");
                    return View(genderModel);
                }
                ModelState.AddModelError("", "Пользователь не найден");
            }
            return View(genderModel);
        }


        [HttpGet]
        public async Task<IActionResult> UpdUserData(string id)
        {
            User user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                UserDataViewModel dataModel = new UserDataViewModel
                {
                    ReturnUrl = Request.Headers["Referer"].ToString()
                };
                if (!string.IsNullOrWhiteSpace(user.FullName) && !user.DOB.HasValue)
                {
                    dataModel.Id = id;
                    dataModel.FirstName = user.FirstName;
                    dataModel.Surname = user.Surname;
                    dataModel.DOB = user.DOB.Value;
                }
                else
                {
                    dataModel.Id = id;
                }
                return View(dataModel);
            }
            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> UpdUserData(UserDataViewModel dataModel)
        {
            if (ModelState.IsValid)
            {
                User user = await userManager.FindByIdAsync(dataModel.Id);
                if (user != null)
                {
                    user.FirstName = dataModel.FirstName;
                    user.Surname = dataModel.Surname;
                    user.DOB = dataModel.DOB;
                    IdentityResult result = await userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        if (string.IsNullOrWhiteSpace(user.FullName) && !user.DOB.HasValue)
                        {
                            return RedirectToAction("Info", "Account", new { dataModel.Id });
                        }
                        else
                        {
                            return RedirectToAction("СhooseLocality", "Account", new { dataModel.Id });
                        }
                    }
                    ModelState.AddModelError("", "Не удалось обновить данные пользователя");
                    return View(dataModel);
                }
                ModelState.AddModelError("", "Пользователь не найден");
            }
            return View(dataModel);
        }

        [HttpGet]
        public IActionResult СhooseLocality()
        {

        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult СhooseLocality()
        {

        }



        [HttpGet, AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            return View(new LoginViewModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel loginModel)
        {
            if (ModelState.IsValid)
            {
                User user = await userManager.FindByEmailAsync(loginModel.Email);
                if (user != null)
                {
                    if (user.Status == Status.Blocked)
                    {
                        ModelState.AddModelError("", "Аккаунт заблокирован администратором!");
                        return View(loginModel);
                    }
                    else
                    {
                        await signInManager.SignOutAsync();
                        Microsoft.AspNetCore.Identity.SignInResult result =
                                await signInManager.PasswordSignInAsync(
                                    user, loginModel.Password, false, false);
                        if (result.Succeeded)
                        {
                            return Redirect(loginModel.ReturnUrl ?? "/");
                        }
                    }
                    
                }
                ModelState.AddModelError(nameof(LoginViewModel.Email),
                    "Invalid user or password");
            }
            return View(loginModel);
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
