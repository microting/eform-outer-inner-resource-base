using System.ComponentModel.DataAnnotations.Schema;
using Microting.eFormApi.BasePn.Infrastructure.Database.Base;

namespace Microting.eFormMachineAreaBase.Infrastructure.Data.Entities
{
    public class MachineAreaSite : BaseEntity
    {        
        public int MicrotingSdkeFormId { get; set; }
        
        public int Status { get; set; }
        
        [ForeignKey("MachineArea")]
        public int MachineAreaId { get; set; }
        
        public virtual MachineArea MachineArea { get; set; }
        
        public int MicrotingSdkSiteId { get; set; }
        
        public int MicrotingSdkCaseId { get; set; }
    }
}