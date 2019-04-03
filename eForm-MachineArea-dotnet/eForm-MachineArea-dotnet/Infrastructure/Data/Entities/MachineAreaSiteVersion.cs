using System.ComponentModel.DataAnnotations.Schema;
using Microting.eFormApi.BasePn.Infrastructure.Database.Base;

namespace Microting.eFormMachineAreaBase.Infrastructure.Data.Entities
{
    public class MachineAreaSiteVersion : BaseEntity
    {
        public int MicrotingSdkeFormId { get; set; }
        
        public int Status { get; set; }
        
        public int MachineAreaId { get; set; }
        
        [ForeignKey("MachineAreaSite")]
        public int MachineAreaSiteId { get; set; }
        
        public int MicrotingSdkSiteId { get; set; }
        
        public int MicrotingSdkCaseId { get; set; }
        
    }
}