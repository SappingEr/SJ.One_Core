using Microsoft.AspNetCore.Mvc;
using SJ.One_Core.Data.Repositories;
using SJ.One_Core.Models;
using System.Collections.Generic;

namespace SJ.One_Core.Controllers
{
    public class AdminController : Controller
    {
        private readonly IUserRepository userReposutory;

        public AdminController(IUserRepository userRepository)
        {
            this.userReposutory = userReposutory;
        }

        //public IActionResult Index()
        //{
        //    List<User> users = new List<User>();
        //    users = userReposutory.GetAll(User, User.Fir);
        //    return View();
        //}
    }
}
