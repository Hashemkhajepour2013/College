using College.Data.Repositories.Contracts;
using College.Data.Users.Contracts.Dtos;
using College.Entities.Users;

namespace College.Data.Users.Contracts
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User?> GetByUserAndPass(LoginUserDto dto, CancellationToken cancellationToken);

        User GetUserByUserName(string userName);

        void Update(User user);
    }
}
