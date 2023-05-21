using College.Data.Users.Students.Contracts.Dtos;

namespace College.Data.Users.Students.Contracts
{
    public interface IStudentService
    {
        Task Add(AddStudentDto dto, CancellationToken cancellationToken);

        Task<GetStudentByIdDto?> GetById(int id, CancellationToken cancellationToken);
    }
}
