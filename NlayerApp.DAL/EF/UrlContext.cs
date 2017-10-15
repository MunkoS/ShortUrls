using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using NlayerApp.DAL.Entities;
using System;
namespace NlayerApp.DAL.EF
{
    public class UrlContext : DbContext
    {
        public DbSet<ShortUrlModel> ShortUrls { get; set; }


        static UrlContext()
        {
            Database.SetInitializer<UrlContext>(new UrlDbInitializer());
        }
        /*  public UrlContext(string connectionString)
              : base(connectionString)
          {
          }*/
          public UrlContext()
          : base("MyDB")
      {
      }


    }

    public class UrlDbInitializer : DropCreateDatabaseIfModelChanges<UrlContext>
    {
        protected override void Seed(UrlContext db)
        {
            db.ShortUrls.Add(new ShortUrlModel { Url = "1", ShortUrl = "2",DateCreated= new DateTime(2015, 7, 20, 18, 30, 25), CountRedirects = 1 });
            db.ShortUrls.Add(new ShortUrlModel { Url = "2", ShortUrl = "3", DateCreated = new DateTime(2015, 7, 20, 18, 30, 25), CountRedirects = 2 });
            db.ShortUrls.Add(new ShortUrlModel { Url = "4", ShortUrl = "5", DateCreated = new DateTime(2015, 7, 20, 18, 30, 25),CountRedirects = 4 });

            db.SaveChanges();
        }
    }
}

