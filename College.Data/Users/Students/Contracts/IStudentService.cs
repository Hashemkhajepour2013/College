using College.Data.Users.Students.Contracts.Dtos;

namespace College.Data.Users.Students.Contracts
{
    public interface IStudentService
    {
        Task Add(AddStudentDto dto, CancellationToken cancellationToken);

        Task<GetStudentByIdDto?> GetById(int id, CancellationToken cancellationToken);

        Task<List<GetAllStudentDto>> GetAll(CancellationToken cancellationToken);

        Task<List<GetClassesForUnitSelectDto>> GetClassesForUnitSelect(int id, CancellationToken cancellationToken);
    }
}
