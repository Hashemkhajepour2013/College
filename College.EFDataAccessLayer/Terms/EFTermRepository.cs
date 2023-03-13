using College.EFDataAccessLayer.Repositories;
using College.EFDataAccessLayer.Terms.Contracts;
using College.Entities;
using College.Persistence.EF;

namespace College.EFDataAccessLayer.Terms
{
    public class EFTermRepository : Repository<Term>, ITermRepository
    {
        public EFTermRepository(EFCollegeContext dbContext)
          : base(dbContext)
        {
        }
    }
}
