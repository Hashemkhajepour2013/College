using College.Data.Lessons.Contracts.Dtos;

namespace College.Data.Lessons.Contracts
{
    public interface ILessonService
    {
        Task Add(AddLessonDto dto, CancellationToken cancellationToken);

        Task Edit(int id, EditLessonDto dto, CancellationToken cancellationToken);

        Task Delete(int id, CancellationToken cancellationToken);

        Task<GetLessonById> GetById(int id, CancellationToken cancellationToken);

        Task<List<GetAllLessonDto>> GetAll(CancellationToken cancellationToken);
    }
}
