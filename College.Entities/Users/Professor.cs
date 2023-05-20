using College.Entities.Common;
using System.ComponentModel.DataAnnotations;

namespace College.Entities.Users
{
    public class Professor : BaseEntity
    {
        public int UserId { get; set; }
        public string DegreeOfEducation { get; set; }

        public ContractType ContractType { get; set; }

        public List<Classroom> Classrooms { get; set; } = new();
    }

    public enum ContractType
    {
        [Display(Name = "پیمانی")]
        Contracting = 1,

        [Display(Name = "شرکتی")]
        corporative = 2
    }
}
