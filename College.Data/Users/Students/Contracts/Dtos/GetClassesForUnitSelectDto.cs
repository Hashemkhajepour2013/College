using College.Entities;
using College.MyApi;

namespace College.Data.Users.Students.Contracts.Dtos
{
    public class GetClassesForUnitSelectDto : BaseDto<GetClassesForUnitSelectDto, Classroom>
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime ExamDate { get; set; }

        public byte Capacity { get; set; }

        public byte RemainsCapacity { get; set; }

        public string LessonTitle { get; set; }

        public string ProfessorFullName { get; set; }

        public List<string> Prerequisites { get; set; } = new();

    }
}
