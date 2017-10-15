using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NlayerApp.BLL.DTO;
namespace NlayerApp.BLL.Interfaces
{
    public interface IKeyGenerator
    {
        string Create(ShortUrlDto url);
    }
}
