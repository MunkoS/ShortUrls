using System;
using NlayerApp.BLL.DTO;
using System.Collections.Generic;

namespace NlayerApp.BLL.Interfaces
{
    public interface IShortUrlServices
    {
       
        IEnumerable<ShortUrlDto> GetAll();

        ShortUrlDto GetByUrl(string url);

        string GetByKey(string key);

        string Create(Uri url);

        void Dispose();
    }
}
