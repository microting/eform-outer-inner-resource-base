using System.ComponentModel.DataAnnotations.Schema;

namespace Microting.eFormMachineAreaBase.Infrastructure.Data.Entities
{
    public class MachineAreaSiteVersion : BaseEntity
    {
        public int MicrotingEFormSdkId { get; set; }
        
        public int Status { get; set; }
        
        public int Version { get; set; }
        
        public int MachineAreaId { get; set; }
        
        [ForeignKey("MachineAreaSite")]
        public int MachineAreaSiteId { get; set; }
        
    }
}