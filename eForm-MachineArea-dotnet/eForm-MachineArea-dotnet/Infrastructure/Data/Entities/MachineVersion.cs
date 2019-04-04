using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microting.eFormApi.BasePn.Infrastructure.Database.Base;

namespace Microting.eFormMachineAreaBase.Infrastructure.Data.Entities
{
    public class MachineVersion : BaseEntity
    {
        [StringLength(250)]
        public string Name { get; set; }
        
        [ForeignKey("Machine")]
        public int MachineId { get; set; }
        
        public virtual Machine Machine { get; set; }
    }
}