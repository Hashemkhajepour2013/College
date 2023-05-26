using College.Entities.Users;
using College.MyApi;
using System.ComponentModel.DataAnnotations;

namespace College.Data.Users.Professors.Contracts.Dtos
{
    public class AddProfessorDto : BaseDto<AddProfessorDto, Professor>
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        [MaxLength(100)]
        public string DegreeOfEducation { get; set; }

        [Required]
        public ContractType ContractType { get; set; }
    }
}
