using ProvaPub.Models;
using ProvaPub.Repository;
using ProvaPub.Services.Interfaces;

namespace ProvaPub.Services
{
    public abstract class Service<T> where T : class
    {
        protected readonly TestDbContext _ctx;

        protected Service(TestDbContext ctx)
        {
            _ctx = ctx;
        }

        protected IList<T> GetElements(int? page)
            => page.HasValue ? _ctx.Set<T>().AsQueryable().Skip((page.Value - 1) * 10).Take(10).ToList() : _ctx.Set<T>().AsQueryable().ToList();
            
        
    }
}
