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

        public int Create(ShortUrlModel shortUrl)
        {
            shortUrl.Id= db.ShortUrls.Count() + 1;
            db.ShortUrls.Add(shortUrl);
            db.SaveChanges();
            return shortUrl.Id;
        }
         

        public void Update(ShortUrlModel shortUrl)
        {
           
            var stored = db.ShortUrls.FirstOrDefault(x => x.Id == shortUrl.Id);
            if (stored == null)
                return;
            stored.ShortUrl = shortUrl.ShortUrl;
            stored.Url = shortUrl.Url;
            stored.CountRedirects = shortUrl.CountRedirects;
            stored.DateCreated = shortUrl.DateCreated;
            
            db.SaveChanges();

        }
    }
}
