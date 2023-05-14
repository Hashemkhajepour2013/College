using Azure.Core;
using College.Data.Users.Contracts.Dtos;
using College.Entities;
using College.Services.JWT.Contracts.Dto;

namespace College.Data.Users.Contracts
{
    public interface IUserService
    {
        Task Add(AddUserDto dto, CancellationToken cancellationToken);

        Task<List<GetAllUserDto>> GetAll(CancellationToken cancellationToken);

        Task Delete(int id, CancellationToken cancellationToken);

        Task Edit(int id, EditUserDto dto, CancellationToken cancellationToken);

        Task<GetByIdUserDto?> GetById(int id, CancellationToken cancellationToken);

        Task<AccessUserToken> Token(LoginUserDto dto, CancellationToken cancellationToken);

        Task UpdateSecurityStamp(string userName);
    }
}
