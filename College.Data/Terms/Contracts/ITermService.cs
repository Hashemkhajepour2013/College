using College.Data.Terms.Contracts.Dtos;

namespace College.Data.Terms.Contracts
{
    public interface ITermService
    {
        Task Add(AddTermDto dto, CancellationToken cancellationToken);

        Task Edit(int id, EditTermDto dto, CancellationToken cancellationToken);

        Task Delete(int id, CancellationToken cancellationToken);

        Task<GetTermByIdDto> GetById(int id, CancellationToken cancellationToken);
    }
}
