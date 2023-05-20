using College.Entities.Users;
using College.MyApi;
using System.ComponentModel.DataAnnotations;

namespace College.Data.Users.Students.Contracts.Dtos
{
    public class AddStudentDto : BaseDto<AddStudentDto, User>, IValidatableObject
    {
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; } = null!;

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; } = null!;

        [Required]
        [MaxLength(100)]
        public string FatherName { get; set; } = null!;

        [Required]
        [MaxLength(10)]
        public string NationalCode { get; set; } = null!;

        [Required]
        [MaxLength(11)]
        public string Mobile { get; set; } = null!;

        [Required]
        [MaxLength(50)]
        public string UserName { get; set; } = null!;

        [Required]
        [MaxLength(50)]
        public string Password { get; set; } = null!;

        [Required]
        [MaxLength(50)]
        public string Email { get; set; } = null!;

        public string UsernameOfMaker { get; set; }

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
