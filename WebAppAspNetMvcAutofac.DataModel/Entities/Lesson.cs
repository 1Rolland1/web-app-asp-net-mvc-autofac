using Common.Attributes;
using Common.Entity;
using Common.Extensions;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web.Mvc;

namespace WebAppAspNetMvcAutofac.DataModel
{
    public class Lesson : EntityBase, IDataContext
    {
        /// <summary>
        /// Номер пары в расписании
        /// </summary>    
        [Required]
        [Display(Name = "№", Order = 5)]
        public  int Number { get; set; }

        /// <summary>
        /// Преподаватель
        /// </summary> 
        [ScaffoldColumn(false)]
        public int TeacherId { get; set; }
        [ScaffoldColumn(false)]
        public virtual Teacher Teacher { get; set; }

        [Display(Name = "Преподаватель", Order = 50)]
        [UIHint("DropDownList")]
        [TargetProperty("TeacherId")]
        [NotMapped]
        public IEnumerable<SelectListItem> TeacherDictionary
        {
            get
            {
                var db = new TimetableContext();
                var query = db.Teachers;

                if (query != null)
                {
                    var dictionary = new List<SelectListItem>();
                    dictionary.AddRange(query.OrderBy(d => d.Name).ToSelectList(c => c.Id, c => c.Name, c => c.Id == TeacherId));
                    return dictionary;
                }

                return new List<SelectListItem> { new SelectListItem { Text = "", Value = "" } };
            }
        }

        /// <summary>
        /// Дисциплина
        /// </summary> 
        [ScaffoldColumn(false)]
        public int DisciplineId { get; set; }
        [ScaffoldColumn(false)]
        public virtual Discipline Discipline { get; set; }
        [Display(Name = "Дисциплина", Order = 2)]
        [UIHint("RadioList")]
        [TargetProperty("DisciplineId")]
        [NotMapped]
        public IEnumerable<SelectListItem> DisciplineDictionary
        {
            get
            {
                var db = new TimetableContext();
                var query = db.Disciplines;

                if (query != null)
                {
                    var dictionary = new List<SelectListItem>();
                    dictionary.AddRange(query.OrderBy(d => d.Name).ToSelectList(c => c.Id, c => c.Name, c => c.Id == DisciplineId));
                    return dictionary;
                }

                return new List<SelectListItem> { new SelectListItem { Text = "", Value = "" } };
            }
        }

        /// <summary>
        /// Группа, у которой будет пара
        /// </summary> 
        [ScaffoldColumn(false)]
        public virtual ICollection<Group> Groups { get; set; }

        [ScaffoldColumn(false)]
        public List<int> GroupIds { get; set; }

        [Display(Name = "Группы", Order = 70)]
        [UIHint("MultipleDropDownList")]
        [TargetProperty("GroupIds")]
        [NotMapped]
        public IEnumerable<SelectListItem> GroupDictionary
        {
            get
            {
                var db = new TimetableContext();
                var query = db.Groups;

                if (query != null)
                {
                    var Ids = query.Where(s => s.Lessons.Any(ss => ss.Id == Id)).Select(s => s.Id).ToList();
                    var dictionary = new List<SelectListItem>();
                    dictionary.AddRange(query.ToSelectList(c => c.Id, c => $"{c.GroupName}", c => Ids.Contains(c.Id)));
                    return dictionary;
                }

                return new List<SelectListItem> { new SelectListItem { Text = "", Value = "" } };
            }
        }
    }
}