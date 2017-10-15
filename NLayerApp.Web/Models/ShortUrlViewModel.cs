using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NLayerApp.Web.Models
{
    public class ShortUrlViewModel
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string ShortUrl { get; set; }
        public DateTime DateCreated { get; set; }
        public int CountRedirects { get; set; }
    }
}