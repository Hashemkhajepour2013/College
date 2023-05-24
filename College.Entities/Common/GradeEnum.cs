using System.ComponentModel.DataAnnotations;

namespace College.Entities.Common
{
    public enum Grade
    {
        [Display(Name = "کاردانی")]
        AssociateDegree = 1,

        [Display(Name = "کارشناسی")]
        BachelorDegree = 2,

        [Display(Name = "کارشناسی ارشد")]
        Masters = 3,

        [Display(Name = "دکتری")]
        PhD = 4
    }
}
