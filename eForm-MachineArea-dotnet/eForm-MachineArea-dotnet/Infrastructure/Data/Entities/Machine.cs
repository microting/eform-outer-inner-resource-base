using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Microting.eFormMachineAreaBase.Infrastructure.Data.Entities
{
    public class Machine : BaseEntity
    {
        public Machine()
        {
            this.MachineAreas = new HashSet<MachineArea>();
        }

        [StringLength(250)]
        public string Name { get; set; }
        
        public virtual ICollection<MachineArea> MachineAreas { get; set; }
        
        public int Version { get; set; }
    }
}