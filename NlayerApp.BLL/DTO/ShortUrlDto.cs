using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NlayerApp.BLL.DTO
{
    public class ShortUrlDto
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string ShortUrl { get; set; }
        public DateTime DateCreated { get; set; }
        public int CountRedirects { get; set; }
    }
}
