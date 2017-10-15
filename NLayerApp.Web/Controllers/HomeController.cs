using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NlayerApp.BLL.Interfaces;
using NlayerApp.BLL.DTO;
using NLayerApp.Web.Models;
using AutoMapper;
using NlayerApp.BLL.Infrastructure;

namespace NLayerApp.Web.Controllers
{
    public class HomeController : Controller
    {

        private readonly IShortUrlServices shortUrlServices;

        public  HomeController(IShortUrlServices serv)
        {
            shortUrlServices = serv;
        }

        public ActionResult Index()
        {
            IEnumerable<ShortUrlDto> urlDtos= shortUrlServices.GetAll();
            Mapper.Initialize(cfg => cfg.CreateMap<ShortUrlDto, ShortUrlViewModel>());
            var urls = Mapper.Map<IEnumerable<ShortUrlDto>, List<ShortUrlViewModel>>(urlDtos);
            return View();
        }

        public ActionResult List()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            shortUrlServices.Dispose();
            base.Dispose(disposing);
        }
    }
}