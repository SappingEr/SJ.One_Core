using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SJ.One_Core.Data.Repositories;
using SJ.One_Core.Models;
using SJ.One_Core.Models.LocalityViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public async Task<IActionResult> GetLocalitiesDropDownList(int id)
        {
            LocalitiesDropDownListViewModel localitiesModel = new LocalitiesDropDownListViewModel();
            List<Locality> localities = await localityRepository.GetSomeAsync(l => l.RegionId == id);
            localitiesModel.Localities = localities.Select(s => new SelectListItem { Value = s.Id.ToString(), Text = s.Name });
            return PartialView(localitiesModel);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> AddNewLocality([Bind("RegionId, Name")] NewLocalityViewModel localityModel)
        {
            Region region = await regionRepository.GetOneAsync(localityModel.RegionId);

            if (region != null && localityModel.Name != null && localityModel.Name.Length >= 0)
            {
                var localities = await localityRepository.GetByNameRegionLocalitiesAsync(localityModel.RegionId, localityModel.Name);

                if (localities.Count > 0)
                {
                    return Json(new { success = false, responseText = "Ошибка! " + localityModel.Name + " есть в списке!" });
                }
                else
                {
                    region.Localities.Add(new Locality { Name = localityModel.Name });
                    await regionRepository.UpdateAsync(region);
                    return Json(new { success = true, responseText = "Список населённых пунктов успешно обновлён." });
                }
            }
            return Json(new { success = false, responseText = "Ошибка! Выберите регион и введите название нового населённого пункта." });
        }
    }
}
