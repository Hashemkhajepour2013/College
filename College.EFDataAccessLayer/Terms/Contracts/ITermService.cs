using College.EFDataAccessLayer.Terms.Contracts.Dtos;

namespace College.EFDataAccessLayer.Terms.Contracts
{
    public interface ITermService
    {
        Task<int> Add(AddTermDto dto, CancellationToken cancellationToken);
    }
}
