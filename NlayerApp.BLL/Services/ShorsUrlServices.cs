using System;
using NlayerApp.BLL.DTO;
using NlayerApp.DAL.Entities;
using NlayerApp.BLL.BusinessModels;
using NlayerApp.DAL.Interfaces;
using NlayerApp.BLL.Infrastructure;
using NlayerApp.BLL.Interfaces;
using System.Collections.Generic;
using AutoMapper;

namespace NlayerApp.BLL.Services
{
    public class ShorsUrlServices : IShortUrlServices
    {
        IUnitOfWork Database { get; set; }

        public ShorsUrlServices(IUnitOfWork uow)
        {
            Database = uow;
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
      

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
