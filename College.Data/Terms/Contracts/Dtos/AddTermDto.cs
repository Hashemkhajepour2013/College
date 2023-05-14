using System.ComponentModel.DataAnnotations;
using College.Entities;
using College.MyApi;

namespace College.Data.Terms.Contracts.Dtos;

public class AddTermDto : BaseDto<AddTermDto, Term, int>
{
    [Required] [MaxLength(100)] public string Title { get; set; } = null!;

    [Required] public byte UnitCount { get; set; }
}