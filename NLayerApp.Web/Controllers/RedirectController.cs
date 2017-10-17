using System;
using System.Web.Mvc;
using NlayerApp.BLL.Interfaces;

namespace NLayerApp.Web.Controllers
{
    public class RedirectController : Controller
    {
        private readonly IShortUrlServices _shortUrlServices;
     
        public RedirectController(IShortUrlServices serv)
        {
            _shortUrlServices = serv;
        
        }

        [Route("r/{key}")]
        public ActionResult Index(string key)
        {
            var url = _shortUrlServices.GetByKey(key);
            if (String.IsNullOrWhiteSpace(url))
                return View("Error");

            return Redirect(url);

        }

       
    }
}