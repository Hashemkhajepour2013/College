using College.Entities;
using College.MyApi;

namespace College.Data.Classrooms.Contracts.Dtos
{
    public class GetAllClassroomDto : BaseDto<GetAllClassroomDto, Classroom>
    {
        public int Id { get; set; }
        public string LessonTitle { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public byte Capacity { get; set; }
        public string TermTitle { get; set; }
    }
}
