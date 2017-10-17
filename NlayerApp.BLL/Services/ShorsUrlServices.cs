using System;
using NlayerApp.BLL.DTO;
using NlayerApp.DAL.Entities;
using NlayerApp.BLL.BusinessModels;
using NlayerApp.DAL.Interfaces;
using NlayerApp.BLL.Interfaces;
using System.Collections.Generic;
using AutoMapper;
using System.Transactions;
namespace NlayerApp.BLL.Services
{
    public class ShorsUrlServices : IShortUrlServices
    {
        IUnitOfWork Database { get; set; }
        private readonly IKeyGenerator _generator;
        public ShorsUrlServices(IUnitOfWork uow, IKeyGenerator generator)
        {
            Database = uow;
            _generator = generator;
        }

        public ShortUrlDto GetByUrl(string url)
        {
            var shortUrl = Database.ShortUrls.GetByUrl(url);
            return Mapper.Map<ShortUrlModel, ShortUrlDto>(shortUrl); 

        }

        public IEnumerable<ShortUrlDto> GetAll()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<ShortUrlModel, ShortUrlDto>());
            return Mapper.Map<IEnumerable<ShortUrlModel>, List<ShortUrlDto>>(Database.ShortUrls.GetAll());
        }

        public string GetByKey(string key)
        {
            var Url = Database.ShortUrls.GetByKey(key);
            if (Url == null) return Url?.Url;
            Url.CountRedirects++;
            using (var trans = new TransactionScope())
            {
                Database.ShortUrls.Update(Url);
                trans.Complete();
            }
            return Url.Url;

        }


        public string Create(Uri url)
        {

            var stored = Database.ShortUrls.GetByUrl(url.ToString());
            if (stored != null)
                return stored.ShortUrl;

            var shortUrl = new ShortUrlDto
            {
                DateCreated = DateTime.UtcNow,
                Url = url.ToString(),
                CountRedirects = 0
            };
            
            using (var trans = new TransactionScope())
            {
                Mapper.Initialize(cfg => cfg.CreateMap<ShortUrlDto, ShortUrlModel>());
                shortUrl.Id = Database.ShortUrls.Create(Mapper.Map<ShortUrlDto, ShortUrlModel>(shortUrl));
              
                shortUrl.ShortUrl = _generator.Create(shortUrl.Id);

              
               
                Database.ShortUrls.Update(Mapper.Map<ShortUrlDto, ShortUrlModel>(shortUrl));

                trans.Complete();
            }

            return shortUrl.ShortUrl;
          
        }


        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
