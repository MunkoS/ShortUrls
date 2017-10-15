using System;
using NlayerApp.BLL.DTO;
using System.Collections.Generic;

namespace NlayerApp.BLL.Interfaces
{
    public interface IShortUrlServices
    {
       
        IEnumerable<ShortUrlDto> GetAll();

        ShortUrlDto GetByUrl(string url);
      //  ShortUrlDto GetByKey(string key);

     //   void Create(ShortUrlDto item);

      //  void Update(ShortUrlDto item);

        void Dispose();
    }
}
