using College.Entities;
using College.MyApi;
using System.ComponentModel.DataAnnotations;

namespace College.Data.Classrooms.Contracts.Dtos
{
    public class AddClassroomDto : BaseDto<AddClassroomDto, Classroom>, IValidatableObject  
    {
        [Required]
        public int LessonId { get; set; }

        [Required]
        public int ProfessorId { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public byte Capacity { get; set; }

        [Required]
        public int TermId { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(StartDate <= DateTime.UtcNow)
                yield return new ValidationResult("ساعت شروع کلاس قبل از زمان فعلی است.");
            if (EndDate <= StartDate)
                yield return new ValidationResult("ساعت شروع کلاس از ساعت پایان کوچکتر است.");
            if (Capacity > 50)
                yield return new ValidationResult("ظرفیت بیش از حد مجاز است");
        }
    }
}
