using College.Entities;
using College.MyApi;

namespace College.Data.Lessons.Contracts.Dtos
{
    public class GetLessonById : BaseDto<GetLessonById, Lesson>
    {
        public string Title { get; set; }
        public byte Coefficient { get; set; }
    }
}
