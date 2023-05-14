using System.ComponentModel.DataAnnotations;

namespace College.Entities.Users
{
    public sealed class Professor : User
    {
        public string DegreeOfEducation { get; set; }

        public ContractType ContractType { get; set; }
    }

    public enum ContractType
    {
        [Display(Name = "پیمانی")]
        Contracting = 1,

        [Display(Name = "شرکتی")]
        corporative = 2
    }
}
