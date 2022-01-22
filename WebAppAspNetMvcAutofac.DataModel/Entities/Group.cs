using Common.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebAppAspNetMvcAutofac.DataModel
{
    public class Group : EntityBase, IDataContext
    {
        /// <summary>
        /// Название группы
        /// </summary>    
        [Required]
        [Display(Name = "Название группы", Order = 5)]
        public string GroupName { get; set; }

        // <summary>
        /// Количество студентов
        /// </summary>    
        [Required]
        [Display(Name = "Количество студентов", Order = 10)]
        public int? NumberOfStudents { get; set; }

        /// <summary>
        /// Предметы
        /// </summary> 
        [ScaffoldColumn(false)]
        public virtual ICollection<Lesson> Lessons { get; set; }
    }
}