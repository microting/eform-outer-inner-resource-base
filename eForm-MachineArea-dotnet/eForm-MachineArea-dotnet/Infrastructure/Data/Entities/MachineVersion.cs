using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Microting.eFormMachineAreaBase.Infrastructure.Data.Entities
{
    public class MachineVersion : BaseEntity
    {
        
        [StringLength(250)]
        public string Name { get; set; }
        
        public int Version { get; set; }
        
        [ForeignKey("Machine")]
        public int MachineId { get; set; }
        
        public virtual Machine Machine { get; set; }
    }
}