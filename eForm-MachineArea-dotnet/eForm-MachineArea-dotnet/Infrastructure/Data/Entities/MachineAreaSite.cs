using System.ComponentModel.DataAnnotations.Schema;

namespace Microting.eFormMachineAreaBase.Infrastructure.Data.Entities
{
    public class MachineAreaSite : BaseEntity
    {        
        public int MicrotingEFormSdkId { get; set; }
        
        public int Status { get; set; }
        
        public int Version { get; set; }
        
        [ForeignKey("MachineArea")]
        public int MachineAreaId { get; set; }
        
        public virtual MachineArea MachineArea { get; set; }
        
        public int MicrotingSdkSiteId { get; set; }
    }
}