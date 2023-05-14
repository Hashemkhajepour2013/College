using College.Entities;
using College.MyApi;

namespace College.Data.Classrooms.Contracts.Dtos
{
    public class GetClassroomById : BaseDto<GetClassroomById, Classroom>
    {
        public string LessonTitle { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public byte Capacity { get; set; }
        public string TermTitle { get; set; }
    }
}
