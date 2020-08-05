using Microsoft.AspNetCore.Mvc;

namespace SJ.One_Core.Controllers
{
    public class BaseController : Controller
    {
        public IActionResult RedirectToBackUrl()
        {
            var backUrl = Request.Headers["Referer"].ToString();
            var redirectUrl = !string.IsNullOrWhiteSpace(backUrl) ? backUrl : Url.Action("Index");
            return Redirect(redirectUrl);
        }

        public IActionResult RedirectToBackUrl(string defaultUrl)
        {
            var backUrl = Request.Headers["Referer"].ToString();            
            var redirectUrl = !string.IsNullOrWhiteSpace(backUrl) ? backUrl : defaultUrl;
            return Redirect(redirectUrl);
        }
    }
}
