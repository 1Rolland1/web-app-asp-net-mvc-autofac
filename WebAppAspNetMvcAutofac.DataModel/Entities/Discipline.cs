using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Common.Entity;

namespace WebAppAspNetMvcAutofac.DataModel
{
    public class Discipline : EntityBase, IDataContext
    {
        [Required]
        [Display(Name = "Дисциплина", Order = 2)]
        public String Name { get; set; }

        /// <summary>
        /// Цель дисциплины
        /// </summary>    
        [Required]
        [Display(Name = "Цель дисциплины", Order = 200)]
        [UIHint("TextArea")]
        public string DisciplineGoal { get; set; }

        /// <summary>
        /// Задачи дисциплины
        /// </summary>    
        [Required]
        [Display(Name = "Задачи дисциплины", Order = 201)]
        [UIHint("TextArea")]
        public string DisciplineObjectives { get; set; }

        /// <summary>
        /// Основные разделы
        /// </summary>    
        [Required]
        [Display(Name = "Основные разделы", Order = 202)]
        [UIHint("TextArea")]
        public string MainSections { get; set; }        

        ///<summary>
        /// Список 
        /// </summary> 
        [ScaffoldColumn(false)]
        public virtual ICollection<Lesson> Lessons { get; set; }
    }
}