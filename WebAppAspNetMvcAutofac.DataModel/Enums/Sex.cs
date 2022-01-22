using System.ComponentModel.DataAnnotations;

namespace WebAppAspNetMvcAutofac.DataModel
{
    public enum Sex
    {
        [Display(Name = "Женский")]
        Female = 1,

        [Display(Name = "Мужской")]
        Male = 2,
    }
}