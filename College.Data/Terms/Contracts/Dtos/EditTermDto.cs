using College.Entities;
using College.MyApi;
using System.ComponentModel.DataAnnotations;

namespace College.Data.Terms.Contracts.Dtos
{
    public class EditTermDto: BaseDto<EditTermDto, Term>
    {
        [Required][MaxLength(100)] public string Title { get; set; } = null!;

        [Required] public byte UnitCount { get; set; }
    }
}
