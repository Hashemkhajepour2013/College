using College.Entities.Users;
using College.MyApi;
using System.ComponentModel.DataAnnotations;

namespace College.Data.Users.Students.Contracts.Dtos
{
    public class AddStudentDto : BaseDto<AddStudentDto, Student>, IValidatableObject
    {
        public int UserId { get; set; }

        public DateTime EntryDate { get; set; }
        public DateTime GraduationDate { get; set; }
        public State State { get; set; }
        public Grade Grade { get; set; }
        public byte ConditionalSemesters { get; set; }
        public byte SemestersTaken { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (EntryDate <= DateTime.UtcNow)
                yield return new ValidationResult("زمان ورود دانشجو قبل از زمانی فعلی است.");
            if (GraduationDate <= EntryDate)
                yield return new ValidationResult("تاریخ ورود از تاریخ خروج جلو تر است.");
        }
    }
}
