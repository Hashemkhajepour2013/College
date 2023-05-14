using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using College.Entities;
using College.MyApi;

namespace College.Data.Users.Contracts.Dtos
{
    public class AddUserDto : BaseDto<AddUserDto, User, int>
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

        public string RoleName { get; set; }
    }
}
