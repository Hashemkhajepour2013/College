using College.Entities;
using College.Services.JWT.Contracts.Dto;

namespace College.Services.JWT.Contracts
{
    public interface IJwtService
    {
        Task<AccessUserToken> Generate(User user);
    }
}
