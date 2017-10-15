using System;
using System.Collections.Generic;
using System.Linq;
using NlayerApp.DAL.Entities;
using NlayerApp.DAL.EF;
using NlayerApp.DAL.Interfaces;
using System.Data.Entity;

namespace NlayerApp.DAL.Repositories
{
    public class ShortUrlRepositories : IRepository<ShortUrlModel>
    {
      
        private UrlContext db;

        public ShortUrlRepositories(UrlContext context)
        {
            this.db = context;
        }


        public IEnumerable<ShortUrlModel> GetAll()
        {
          var v=  db.ShortUrls.FirstOrDefault(x => x.Url == "1");
            return db.ShortUrls;
          
          
        }
        public ShortUrlModel GetByUrl(string url)
        {
            return db.ShortUrls.FirstOrDefault(x => x.Url == url);
        }

        public ShortUrlModel GetByKey(string key)
        {
            return db.ShortUrls.FirstOrDefault(x => x.ShortUrl == key);
        }

        public void Create(ShortUrlModel shortUrl)
        {
           db.ShortUrls.Add(shortUrl);
           db.SaveChanges();
        }

        public void Update(ShortUrlModel shortUrl)
        {
            db.SaveChanges();
        }
    }
}
