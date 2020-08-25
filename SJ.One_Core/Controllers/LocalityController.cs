using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SJ.One_Core.Data.Repositories;
using SJ.One_Core.Models;
using SJ.One_Core.Models.LocalityViewModels;
using System.Linq;

namespace SJ.One_Core.Controllers
{
    public class LocalityController : Controller
    {
        private readonly IRegionRepository regionRepository;
        private readonly ILocalityRepository localityRepository;

        public LocalityController(IRegionRepository regionRepository, ILocalityRepository localityRepository)
        {
            this.regionRepository = regionRepository;
            this.localityRepository = localityRepository;
        }

        [HttpGet]
        public IActionResult GetLocalitiesDropDownList(int id)
        {
            LocalitiesDropDownListViewModel localitiesModel = new LocalitiesDropDownListViewModel
            {
                Localities = localityRepository.GetSome(l => l.RegionId == id)
                .Select(l => new SelectListItem { Value = l.Id.ToString(), Text = l.Name })
            };
            return PartialView(localitiesModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddNewLocality([Bind("RegionId,Name")] NewLocalityViewModel localityModel)
        {
            Region region = regionRepository.GetOne(localityModel.RegionId);

            if (region != null && localityModel.Name != null && localityModel.Name.Length >= 0)
            {
                var localities = localityRepository.GetByNameRegionLocalities(localityModel.RegionId, localityModel.Name);
               
                if (localities.Count > 0)
                {
                    return Json(new { success = false, responseText = "Ошибка! " + localityModel.Name + " есть в списке!" });
                }
                else
                {
                    region.Localities.Add(new Locality { Name = localityModel.Name });
                    regionRepository.Update(region);
                    return Json(new { success = true, responseText = "Список населённых пунктов успешно обновлён." });
                }
            }
            return Json(new { success = false, responseText = "Ошибка! Выберите регион и введите название нового населённого пункта." });
        }
    }
}
