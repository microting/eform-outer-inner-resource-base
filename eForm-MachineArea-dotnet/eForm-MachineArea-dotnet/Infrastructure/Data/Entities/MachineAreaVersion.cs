using System.ComponentModel.DataAnnotations.Schema;

namespace Microting.eFormMachineAreaBase.Infrastructure.Data.Entities
{
    public class MachineAreaVersion : BaseEntity
    {
        public int MachineId { get; set; }

        public virtual Machine Machine { get; set; }

        public int AreaId { get; set; }

        public virtual Area Area { get; set; }
        
        public int Verseion { get; set; }
        
        [ForeignKey("MachineArea")]
        public int MachineAreaId { get; set; }
        
        public virtual MachineArea MachineArea { get; set; }
    }
}