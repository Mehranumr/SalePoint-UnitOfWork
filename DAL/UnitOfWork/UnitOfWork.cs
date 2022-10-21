using System;

namespace salepoint.DAL
{
   public class UnitOfWork : IUnitOfWork
   {
        private SalesPointContext context;
        private GenericRepository<Brand> brandRepository;
        private GenericRepository<Store> storeRepository;

        public UnitOfWork(SalesPointContext context)
        {
            this.context = context;
        }

        public GenericRepository<Brand> BrandRepository
        {
            get
            {

                if (this.brandRepository == null)
                {
                    this.brandRepository = new GenericRepository<Brand>(context);
                }
                return brandRepository;
            }
        }

        public GenericRepository<Store> StoreRepository
        {
            get
            {

                if (this.storeRepository == null)
                {
                    this.storeRepository = new GenericRepository<Store>(context);
                }
                return storeRepository;
            }
        }
        
        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}