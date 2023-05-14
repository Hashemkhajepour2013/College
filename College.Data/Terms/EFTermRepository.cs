using College.Common;
using College.Data.Repositories;
using College.Data.Terms.Contracts;
using College.Entities;

namespace College.Data.Terms
{
    public class EFTermRepository : Repository<Term>, ITermRepository, IScopedDependency
    {
        public EFTermRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
