using Microsoft.EntityFrameworkCore;

namespace salepoint.DAL
{
    public class SalesPointContext: DbContext
    {
        public SalesPointContext(DbContextOptions<SalesPointContext> options): base(options){}
        public DbSet<Brand> Brand {get;set;}
        public DbSet<Store> Store {get;set;}
    }
}