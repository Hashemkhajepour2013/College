using System.ComponentModel.DataAnnotations;

namespace College.EFDataAccessLayer.Terms.Contracts.Dtos
{
    public class AddTermDto
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; } = null!;

        [Required]
        [Range(12, 22)]
        public byte UnitCount { get; set; }
    }
}
