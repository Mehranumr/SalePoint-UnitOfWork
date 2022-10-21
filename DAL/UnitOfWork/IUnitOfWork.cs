using System;

namespace salepoint.DAL
{
   public interface IUnitOfWork : IDisposable
   {
        GenericRepository<Brand> BrandRepository { get; }
        GenericRepository<Store> StoreRepository { get; }

        void Save();
    }
}