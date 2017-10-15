using System;
using System.Collections.Generic;
using System.Linq;
using NlayerApp.DAL.Entities;
using NlayerApp.DAL.EF;
using NlayerApp.DAL.Interfaces;
using System.Data.Entity;

namespace NlayerApp.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private UrlContext db;
        private ShortUrlRepositories shortUrlRepository;

        public EFUnitOfWork(string connectionString)
        {
            db = new UrlContext(connectionString);
        }
        public IRepository<ShortUrlModel> ShortUrls
        {
            get
            {
                if (shortUrlRepository == null)
                    shortUrlRepository = new ShortUrlRepositories(db);
                return shortUrlRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


    }
}
