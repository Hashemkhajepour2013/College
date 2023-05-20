using College.Entities.Common;
using System.ComponentModel.DataAnnotations;

namespace College.Entities.Users
{
    public class Student : BaseEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime? GraduationDate { get; set; }
        public State State { get; set; }
        public Grade Grade { get; set; }
        public byte ConditionalSemesters { get; set; }
        public byte SemestersTaken { get; set; }

        public List<StudentClassroom> StudentClassrooms { get; set; } = new();
    }

    public enum State
    {
        [Display(Name = "در حال تحصیل")]
        Studying =1,

        [Display(Name = "فارغ التحصیل شده")]
        Graduated =2,

        [Display(Name = "اخراج شده")]
        Fired =3,

        [Display(Name = "تعویق شده")]
        adjournment=4
    }

    public enum Grade
    {
        [Display(Name = "کاردانی")]
        AssociateDegree =1,

        [Display(Name = "کارشناسی")]
        BachelorDegree = 2,

        [Display(Name = "کارشناسی ارشد")]
        Masters = 3,

        [Display(Name = "دکتری")]
        PhD = 4
    }
}
