using College.Data.Classrooms.Contracts.Dtos;

namespace College.Data.Classrooms.Contracts
{
    public interface IClassroomService
    {
        Task Add(AddClassroomDto dto,  CancellationToken cancellationToken);

        Task Delete(int id, CancellationToken cancellationToken);

        Task<List<GetAllClassroomDto>> GetAll(CancellationToken cancellationToken); 

        Task<GetClassroomById?> GetById(int id, CancellationToken cancellationToken); 
    }
}
