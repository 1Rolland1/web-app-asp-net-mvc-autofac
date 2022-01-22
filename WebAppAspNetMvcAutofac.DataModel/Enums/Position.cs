using System.ComponentModel.DataAnnotations;

namespace WebAppAspNetMvcAutofac.DataModel
{
	public enum Position
	{
		[Display(Name = "Профессор")]
		Professor = 1,

		[Display(Name = "Старший преподаватель")]
		SeniorLecturer = 2,

		[Display(Name = "Доцент")]
		AssistantProfessor = 3,
	}
}