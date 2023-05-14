using AutoMapper.QueryableExtensions;
using College.Common;
using College.Data.Repositories;
using College.Data.Users.Contracts;
using College.Data.Users.Contracts.Dtos;
using College.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace College.Data.Users
{
    public class EFUserRepository : Repository<User>, IUserRepository, IScopedDependency
    {
        public EFUserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<User?> GetByUserAndPass(LoginUserDto dto, CancellationToken cancellationToken)
        {
            return await TableNoTracking
                .SingleOrDefaultAsync(_ => _.UserName == dto.UserName && _.PasswordHash == dto.Password, cancellationToken);
        }
    }
}
