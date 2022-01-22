using Common.Entity;
using System;
using System.ComponentModel.DataAnnotations;

namespace WebAppAspNetMvcAutofac.DataModel
{
    public class TeacherImage : IEntityBase, IDataContext
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }

        [Required]
        public byte[] Data { get; set; }

        [StringLength(100)]
        public string ContentType { get; set; }
        public DateTime? DateChanged { get; set; }
        public string FileName { get; set; }
    }
}