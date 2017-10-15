using NlayerApp.DAL.Entities;
using System;


namespace NlayerApp.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<ShortUrlModel> ShortUrls { get; }
        void Save();
    }
}
