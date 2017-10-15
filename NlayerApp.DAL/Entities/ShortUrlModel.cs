﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NlayerApp.DAL.Entities
{
   public class ShortUrlModel
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string ShortUrl { get; set; }
        public DateTime DateCreated { get; set; }
        public int CountRedirects { get; set; }

    }
}
