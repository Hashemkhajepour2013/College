using System.ComponentModel.DataAnnotations;
using College.Entities.Users;
using College.MyApi;

namespace College.Data.Users.Contracts.Dtos
{
    public class EditUserDto: BaseDto<EditUserDto, Student, int>
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
        public string Email { get; set; } = null!;
    }
}
