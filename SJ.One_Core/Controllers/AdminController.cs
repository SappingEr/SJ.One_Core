using Microsoft.AspNetCore.Mvc;
using SJ.One_Core.Data.Repositories;
using SJ.One_Core.Models;
using SJ.One_Core.Models.AdminViewModels;
using SJ.One_Core.Service.Filters;
using SJ.One_Core.Service.Filters.ModelFilters;
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

        public async Task<IActionResult> Users(FetchOptions fetchOptions, int page = 1)
        {
            UserFilter userFilter = new UserFilter();
            var usersPaging = await userRepository.Find(userFilter, fetchOptions, null, page, 20, false);
            PagingViewModel paging = new PagingViewModel
            {
                From = usersPaging.From,
                Index = usersPaging.Index,
                Size = usersPaging.Size,
                Count = usersPaging.Count,
                Page = usersPaging.Page,
                Pages = usersPaging.Pages,
                HasPrevious = usersPaging.HasPrevious,
                HasNext = usersPaging.HasNext
            };
            UsersListVewModel userModel = new UsersListVewModel { Users = usersPaging.Items, Paging = paging, FetchOptions = fetchOptions };
            return View(userModel);
        }

        //public async Task<IActionResult> FastSearchUsers(string searchString)
        //{

        //}
    }
}
