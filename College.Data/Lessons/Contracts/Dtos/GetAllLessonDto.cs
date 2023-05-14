using College.Entities;
using College.MyApi;

namespace College.Data.Lessons.Contracts.Dtos
{
    public class GetAllLessonDto : BaseDto<GetAllLessonDto, Lesson>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public byte Coefficient { get; set; }
    }
}
