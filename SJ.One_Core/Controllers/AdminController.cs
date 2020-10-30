using Microsoft.AspNetCore.Mvc;
using SJ.One_Core.Data.Repositories;
using SJ.One_Core.Models;
using SJ.One_Core.Models.AdminViewModels;
using SJ.One_Core.Service.Filters;
using SJ.One_Core.Service.Search;
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

        public async Task<IActionResult> Users(FetchOptions fetchOptions)
        {
            FastSearch search = new FastSearch { SearchString = "Ан" };
            var t = userRepository.FastSearch(search);
            //var usersPaging = await userRepository.GetListAsync(where: i=>i.FirstName.Contains("Ан"), orderBy: x => x.OrderBy(x => x.Surname));
            //PagingViewModel paging = new PagingViewModel
            //{
            //    From = usersPaging.From,
            //    Index = usersPaging.Index,
            //    Size = usersPaging.Size,
            //    Count = usersPaging.Count,
            //    Pages = usersPaging.Pages
            //};
            UsersListVewModel userModel = new UsersListVewModel { FetchOptions = fetchOptions };
            return View(userModel);
        }
    }
}
