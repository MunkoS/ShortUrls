using System.Collections.Generic;
using System.Web.Mvc;
using NlayerApp.BLL.Interfaces;
using NlayerApp.BLL.DTO;
using NLayerApp.Web.Models;
using AutoMapper;
using System;





namespace NLayerApp.Web.Controllers
{
    public class HomeController : Controller
    {

        private readonly IShortUrlServices _shortUrlServices;
        private readonly string _roteFormat;
        public  HomeController(IShortUrlServices serv)
        {
            _shortUrlServices = serv;
            _roteFormat = "{0}/r/{1}";
        }

        string CreateUrl(string key, string host)
        {
            return String.Format(_roteFormat, host, key);
        }

        public string Host
        {
            get { return Request.Url.GetLeftPart(UriPartial.Authority); ; }
        }



        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult List()
        {
            IEnumerable<ShortUrlDto> urlDtos = _shortUrlServices.GetAll();
            var host = Host;
            Mapper.Initialize(cfg => cfg.CreateMap<ShortUrlDto, ShortUrlViewModel>());
            var urls = Mapper.Map<IEnumerable<ShortUrlDto>, List<ShortUrlViewModel>>(urlDtos);
            for(int i = 0; i < urls.Count; i++)
            {
                urls[i].ShortUrl = CreateUrl(urls[i].ShortUrl, host);

            }
          
            ViewBag.Url = urls;
            return View();


        }

        public ActionResult Contact()
        {
            return View();
        }

       
        public JsonResult Create(string url)
        {
            
            var shortUrl= _shortUrlServices.Create(new Uri(url));
        
            return Json(CreateUrl(shortUrl, Host), JsonRequestBehavior.AllowGet);
            
        }

        
      

       
        protected override void Dispose(bool disposing)
        {
            _shortUrlServices.Dispose();
            base.Dispose(disposing);
        }
    }
}