using Microsoft.AspNetCore.Mvc;
using SJ.One_Core.Data.Repositories;
using SJ.One_Core.Models;
using SJ.One_Core.Models.AdminViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace SJ.One_Core.Controllers
{
    public class AdminController : Controller
    {
        private IUserRepository userRepository;

        public AdminController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<IActionResult> Users()
        {
            var usersPaging = await userRepository.GetListAsync(null, orderBy: x => x.OrderBy(x => x.Surname));
            PagingViewModel paging = new PagingViewModel
            {
                From = usersPaging.From,
                Index = usersPaging.Index,
                Size = usersPaging.Size,
                Count = usersPaging.Count,
                Pages = usersPaging.Pages
            };
            UsersListVewModel userModel = new UsersListVewModel { Users = usersPaging.Items };
            return View(userModel);
        }
    }
}
