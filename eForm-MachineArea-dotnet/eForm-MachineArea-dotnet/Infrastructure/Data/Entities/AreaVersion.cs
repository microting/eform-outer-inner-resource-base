using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Microting.eFormMachineAreaBase.Infrastructure.Data.Entities
{
    public class AreaVersion : BaseEntity
    {
        [StringLength(250)]
        public string Name { get; set; }
        
        public int Version { get; set; }
        
        [ForeignKey("Area")]
        public int AreaId { get; set; }
        
        public virtual Area Area { get; set; }
        
    }
}