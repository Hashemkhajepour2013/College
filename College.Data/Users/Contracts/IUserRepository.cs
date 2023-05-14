using College.Data.Repositories.Contracts;
using College.Data.Users.Contracts.Dtos;
using College.Entities;

namespace College.Data.Users.Contracts
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User?> GetByUserAndPass(LoginUserDto dto, CancellationToken cancellationToken);
    }
}
