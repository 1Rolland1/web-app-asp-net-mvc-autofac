
using System.Web.Mvc;

namespace Common.Entity
{
    public class EntityBase : IEntityBase
    {
        /// <summary>
        /// Id
        /// </summary> 
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
    }
}