using College.Data.Users.Professors.Contracts.Dtos;

namespace College.Data.Users.Professors.Contracts
{
    public interface IProfessorService
    {
        Task Add(AddProfessorDto dto, CancellationToken cancellationToken);

        Task<GetProfessorByIdDto> GetById(int id, CancellationToken cancellationToken);

        Task<List<GetAllProfessorDto>> GetAll(CancellationToken cancellationToken);
    }
}
