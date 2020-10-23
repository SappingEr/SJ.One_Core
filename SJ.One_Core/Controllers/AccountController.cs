using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SJ.One_Core.Data.Repositories;
using SJ.One_Core.Models;
using SJ.One_Core.Models.AccountViewModels;
using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SJ.One_Core.Controllers
{

    public class AccountController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly IRegionRepository regionRepository;
        private readonly ILocalityRepository localityRepository;
        private readonly ISportClubRepository sportClubRepository;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager,
            IRegionRepository regionRepository, ILocalityRepository localityRepository, ISportClubRepository sportClubRepository)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.regionRepository = regionRepository;
            this.localityRepository = localityRepository;
            this.sportClubRepository = sportClubRepository;
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
                    return RedirectToAction("UserInfo", "Account", new { user.Id });
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
        public async Task<IActionResult> СhooseUserGender(int id)
        {
            User user = await userManager.FindByIdAsync(id.ToString());
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
                User user = await userManager.FindByIdAsync(genderModel.Id.ToString());
                if (user != null)
                {
                    user.Gender = genderModel.Gender;
                    IdentityResult result = await userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        if (!string.IsNullOrWhiteSpace(user.FullName))
                        {
                            return RedirectToAction("UserInfo", "Account", new { genderModel.Id });
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
        public async Task<IActionResult> UpdUserData(int id)
        {
            User user = await userManager.FindByIdAsync(id.ToString());
            if (user != null)
            {
                UserDataViewModel dataModel = new UserDataViewModel
                {
                    ReturnUrl = Request.Headers["Referer"].ToString()
                };
                if (!string.IsNullOrWhiteSpace(user.FullName) && user.DOB.HasValue)
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

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdUserData(UserDataViewModel dataModel)
        {
            if (ModelState.IsValid)
            {
                User user = await userManager.FindByIdAsync(dataModel.Id.ToString());
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
        public async Task<IActionResult> СhooseLocality(int id)
        {
            User user = await userManager.FindByIdAsync(id.ToString());
            if (user != null)
            {
                LocalityViewModel localityModel = new LocalityViewModel
                {
                    Id = id,
                    ReturnUrl = Request.Headers["Referer"].ToString()
                };
                var regions = await regionRepository.GetAllAsync();
                if (user.LocalityId == null)
                {                    
                    localityModel.Regions = regions.Select(r => new SelectListItem { Value = r.Id.ToString(), Text = r.Name });
                }
                else
                {
                    var locality= await localityRepository.GetOneAsync(user.LocalityId);
                    var region = locality.Region;
                    int regionId = region.Id;
                    localityModel.RegionId = regionId;

                    localityModel.Regions = regions
                        .Select(r => new SelectListItem
                        {
                            Value = r.Id.ToString(),
                            Text = r.Name,
                            Selected = localityModel.RegionId.Equals(regionId)
                        });

                    localityModel.Localities = region.Localities
                        .Select(l => new SelectListItem { Value = l.Id.ToString(), Text = l.Name });
                }
                if (user.SportClubId == null)
                {
                    localityModel.AddClub = true;
                }
                return View(localityModel);
            }
            return BadRequest();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> СhooseLocality(LocalityViewModel localityModel)
        {
            if (ModelState.IsValid && localityModel.LocalityId > 0)
            {
                User user = await userManager.FindByIdAsync(localityModel.Id.ToString());
                Locality locality = await localityRepository.GetOneAsync(localityModel.LocalityId);
                if (locality != null)
                {
                    user.Locality = locality;
                    IdentityResult result = await userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        if (localityModel.Club)
                        {
                            return RedirectToAction("СhooseSportClub", new { localityModel.Id });
                        }
                        else
                        {
                            return RedirectToAction("UserInfo", new { localityModel.Id });
                        }
                    }
                }
                ModelState.AddModelError("", "Не удалось обновить данные пользователя");
                return View(localityModel);
            }
            return View(localityModel);
        }

        [HttpGet]
        public async Task<ActionResult> СhooseSportClub(int id)
        {
            User user = await userManager.FindByIdAsync(id.ToString());
            Locality locality = await localityRepository.GetOneAsync(user.LocalityId);
            if (user != null && locality != null)
            {
                SportClubViewModel model = new SportClubViewModel
                {
                    Id = id,
                    ReturnUrl = Request.Headers["Referer"].ToString()
                };

                Region region = await regionRepository.GetOneAsync(locality.RegionId);

                int regionId = region.Id;
                int localityId = locality.Id;
                model.ClubRegionId = regionId;
                model.ClubLocalityId = localityId;
                var regions = await regionRepository.GetAllAsync();
                var regionLocalities = await localityRepository.GetSomeAsync(l => l.RegionId == regionId);
                var localityClubs = await sportClubRepository.GetSomeAsync(c => c.LocalityId == localityId);

                model.ClubRegions = regions
                   .Select(r => new SelectListItem { Value = r.Id.ToString(), Text = r.Name, Selected = model.ClubRegionId.Equals(regionId) });

                model.ClubLocalities = regionLocalities
                   .Select(i => new SelectListItem { Value = i.Id.ToString(), Text = i.Name, Selected = model.ClubLocalityId.Equals(localityId) });

                model.Clubs = localityClubs
                    .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name });

                return View(model);
            }
            return BadRequest();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> СhooseSportClub(SportClubViewModel clubModel)
        {
            if (ModelState.IsValid)
            {
                User user = await userManager.FindByIdAsync(clubModel.Id.ToString());
                SportClub sportClub = await sportClubRepository.GetOneAsync(clubModel.ClubId);
                sportClub.SportClubUsers.Add(user);
                await sportClubRepository.UpdateAsync(sportClub);
                return RedirectToAction("UserInfo", new { clubModel.Id });
            }
            return View(clubModel);
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
                    "Неправильное имя пользователя или пароль");
            }
            return View(loginModel);
        }

        [HttpGet]
        public async Task<IActionResult> UploadAvatar(int id)
        {
            User user = await userManager.FindByIdAsync(id.ToString());
            if (user != null)
            {
                AvatarViewModel avatarModel = new AvatarViewModel { Id = id };
                if (user.Avatar != null)
                {
                    avatarModel.Delete = true;
                }
                return View(avatarModel);
            }
            return BadRequest();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> UploadAvatar(AvatarViewModel avatarModel)
        {
            if (ModelState.IsValid && avatarModel.Avatar != null)
            {
                User user = await userManager.FindByIdAsync(avatarModel.Id.ToString());
                byte[] avatarData = null;
                using (BinaryReader binaryReader = new BinaryReader(avatarModel.Avatar.OpenReadStream()))
                {
                    avatarData = binaryReader.ReadBytes((int)avatarModel.Avatar.Length);
                }
                user.Avatar = avatarData;
                IdentityResult result = await userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("UserInfo", new { avatarModel.Id });
                }
                ModelState.AddModelError("", "Не удалось сохранить изменения");
                return View(avatarModel);
            }
            ModelState.AddModelError("", "Выберите файл!");
            return View(avatarModel);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteAvatar(int id)
        {
            User user = await userManager.FindByIdAsync(id.ToString());
            if (user != null && user.Avatar != null)
            {
                user.Avatar = null;
                await userManager.UpdateAsync(user);
                return RedirectToAction("UserInfo", new { id });
            }
            TempData["errMessage"] = "Не удалось удалить аватар";
            return RedirectToAction("UploadAvatar", new { id });
        }

        [HttpGet]
        public async Task<IActionResult> ChangePassword(int id)
        {
            User user = await userManager.FindByIdAsync(id.ToString());
            if (user != null)
            {
                return View(new ChangePasswordViewModel { Id = id });
            }
            return BadRequest();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel passwordModel)
        {
            if (ModelState.IsValid)
            {
                User user = await userManager.FindByIdAsync(passwordModel.Id.ToString());
                var changePass = userManager.ChangePasswordAsync(user, passwordModel.Password, passwordModel.NewPassword);
                if (changePass.Result.Succeeded)
                {
                    await signInManager.SignOutAsync();
                    return RedirectToAction("Login");
                }
                ModelState.AddModelError("", "Ошибка смены пароля. Попробуйте ещё раз.");
            }
            return View(passwordModel);
        }

        [HttpGet]
        public async Task<IActionResult> UserInfo(int id, UserInfoViewModel userInfoModel)
        {
            User user = await userManager.FindByIdAsync(id.ToString());
            if (user != null)
            {
                userInfoModel.Id = user.Id;
                userInfoModel.Avatar = user.Avatar;
                userInfoModel.Email = user.Email;
                userInfoModel.FirstName = user.FirstName;
                userInfoModel.Surname = user.Surname;
                userInfoModel.Gender = user.Gender;
                userInfoModel.DOB = user.DOB;                
                if (user.LocalityId != null)
                {
                    Locality locality = await localityRepository.GetOneAsync(user.LocalityId);                     
                    userInfoModel.Locality = locality.Name;
                }                
                if (user.SportClubId != null)
                {
                    SportClub sportClub = await sportClubRepository.GetOneAsync(user.SportClubId);
                    userInfoModel.Club = sportClub.Name;
                }
                return View(userInfoModel);
            }
            return BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> DeleteUser(int id)
        {
            User user = await userManager.FindByIdAsync(id.ToString());
            if (user != null)
            {
                return View(new DeleteUserViewModel { Id = id });
            }
            return BadRequest();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteUser(DeleteUserViewModel deleteUserModel)
        {
            if (ModelState.IsValid)
            {
                User user = await userManager.FindByIdAsync(deleteUserModel.Id.ToString());
                var checkPassword = userManager.PasswordHasher.VerifyHashedPassword(user, user.PasswordHash, deleteUserModel.Password).ToString();
                if (checkPassword == "Success")
                {
                    var deleteResult = await userManager.DeleteAsync(user);
                    if (deleteResult.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    ModelState.AddModelError("", "Не удалось удалить учётную запись. Попробуйте ещё раз");
                    return View(deleteUserModel);
                }
                ModelState.AddModelError("", "Неверный пароль");
                return View(deleteUserModel);
            }
            return View(deleteUserModel);
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
