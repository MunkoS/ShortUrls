using System;
using System.Linq;
using NlayerApp.BLL.Interfaces;
using NlayerApp.BLL.Services;
using NlayerApp.BLL.DTO;
using System.Net.Http;
using System.Web.Http;



namespace NLayerApp.Web.Controllers
{
    public class ShortUriController : ApiController
    {
        private readonly IShortUrlServices _shortUrlServices;
        private readonly string _roteFormat;

        public ShortUriController(IShortUrlServices manager)
        {
           // IKernel ninjectKernel = new StandardKernel();
           // ninjectKernel.Bind<IShortUrlServices>().To<ShorsUrlServices>();
           // _shortUrlServices = ninjectKernel.Get<IShortUrlServices>();
             _shortUrlServices = manager;
            _roteFormat = "{0}/r/{1}";
        }

        string CreateUrl(string key, string host)
        {
            return String.Format(_roteFormat, host, key);
        }

        public string Host
        {
            get { return Request.RequestUri.GetLeftPart(UriPartial.Authority); }
        }

        [Route("r/{key}")]
        [HttpGet]
        [AllowAnonymous]
        public IHttpActionResult Trsansfer(string key)
        {
            var url = _shortUrlServices.GetByUrl(key).ShortUrl;
            if (String.IsNullOrWhiteSpace(url))
                return NotFound();

            return Redirect(new Uri(url));
        }

       /*[Route("api/create")]
        [HttpPost]
        public HttpResponseMessage Create([FromBody] string url)
        {
            var a= new ShortUrlDto() ;
            a.Url = url;
            _shortUrlServices.Create(a);
            return Request.CreateResponse(CreateUrl(url, Host));
            //return Request.CreateResponse(CreateUrl(result, Host));
        }*/

        [Route("api/links")]
        [HttpGet]
        public HttpResponseMessage Links(int index, int size)
        {
         
            var result = _shortUrlServices.GetAll().Select(x => new ShortUrlDto
            {
                Url = x.Url,
                ShortUrl = x.ShortUrl,
                DateCreated = x.DateCreated,
                CountRedirects = x.CountRedirects,
            });
           
            return Request.CreateResponse(new { result });
        }






    }
}