using College.Entities;
using College.MyApi;

namespace College.Data.Lessons.Contracts.Dtos
{
    public class EditLessonDto : BaseDto<EditLessonDto, Lesson>
    {
        public string Title { get; set; }
        public byte Coefficient { get; set; }
    }
}
