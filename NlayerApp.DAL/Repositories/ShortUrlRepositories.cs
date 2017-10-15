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

        public IEnumerable<ShortUrlModel> Find(Func<ShortUrlModel, Boolean> predicate)
        {
            return db.ShortUrls.Where(predicate).ToList();
        }


        public void Create(ShortUrlModel shortUrl)
        {
           db.ShortUrls.Add(shortUrl);
        }

        public void Update(ShortUrlModel shortUrl)
        {
            var stored = db.ShortUrls.FirstOrDefault(x => x.Id == shortUrl.Id);
            if (stored == null)
                return;
            stored.Url = shortUrl.Url;
            stored.ShortUrl = shortUrl.ShortUrl;
            stored.CountRedirects = shortUrl.CountRedirects;
            stored.DateCreated = shortUrl.DateCreated;
        }
    }
}
