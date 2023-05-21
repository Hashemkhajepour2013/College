using College.Entities.Users;
using College.MyApi;

namespace College.Data.Users.Students.Contracts.Dtos
{
    public class GetAllStudentDto : BaseDto<GetAllStudentDto, Student>
    {
        public int Id { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserFatherName { get; set; }
        public string UserNationalCode { get; set; }
        public string UserMobile { get; set; }
        public string UserImageName { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime? GraduationDate { get; set; }
        public State State { get; set; }
        public Grade Grade { get; set; }
        public byte ConditionalSemesters { get; set; }
        public byte SemestersTaken { get; set; }
    }
}
