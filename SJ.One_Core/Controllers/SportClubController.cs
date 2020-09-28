using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SJ.One_Core.Data.Repositories;
using SJ.One_Core.Models;
using SJ.One_Core.Models.SportClubViewModels;
using System.Linq;

namespace SJ.One_Core.Controllers
{
    public class SportClubController : Controller
    {
        private readonly ISportClubRepository sportClubRepository;
        private readonly ILocalityRepository localityRepository;

        public SportClubController(ISportClubRepository sportClubRepository, ILocalityRepository localityRepository)
        {
            this.sportClubRepository = sportClubRepository;
            this.localityRepository = localityRepository;
        }

        public IActionResult GetSportClubsDropDownList(int id)
        {
            SportClubsDropDownListViewModel clubModel = new SportClubsDropDownListViewModel
            {
                Clubs = sportClubRepository.GetSome(c => c.LocalityId == id)
                    .Select(l => new SelectListItem { Value = l.Id.ToString(), Text = l.Name })
            };
            return PartialView(clubModel);
        }
        public IActionResult AddNewSportClub(NewSportClubViewModel sportClubModel)
        {
            Locality locality = localityRepository.GetOne(sportClubModel.LocalityId);
            if (locality != null && sportClubModel.Name.Length > 0)
            {
                var clubs = sportClubRepository.GetByNameLocalitySportClubs(sportClubModel.LocalityId, sportClubModel.Name);
                if (clubs.Count > 0)
                {
                    return Json(new { success = false, responseText = "Ошибка! " + sportClubModel.Name + " есть в списке!" });
                }
                else
                {                   
                    locality.LocalitySportClubs.Add(new SportClub { Name = sportClubModel.Name });
                    localityRepository.Update(locality);
                    return Json(new { success = true, responseText = "Список клубов успешно обновлён." });
                }
            }
            return Json(new
            {
                success = false,
                responseText = "Ошибка! Выберите регион, населённый пункт и введите название нового спортивного клуба."
            });
        }


    }
}
