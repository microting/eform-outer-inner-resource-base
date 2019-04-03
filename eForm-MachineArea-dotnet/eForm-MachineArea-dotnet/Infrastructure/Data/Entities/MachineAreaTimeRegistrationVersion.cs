using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microting.eFormApi.BasePn.Infrastructure.Database.Base;

namespace Microting.eFormMachineAreaBase.Infrastructure.Data.Entities
{
    public class MachineAreaTimeRegistrationVersion : BaseEntity
    {
        
        public int MachineId { get; set; }
        
        public virtual Machine Machine { get; set; }
        
        public int AreaId { get; set; }
        
        public virtual Area Area { get; set; }
        
        public DateTime DoneAt { get; set; }
        
        public int SDKCaseId { get; set; }
        
        public int SDKFieldValueId { get; set; }
        
        public int TimeInSeconds { get; set; }
        
        public int TimeInMinutes { get; set; }
        
        public int TimeInHours { get; set; }
        
        public int SDKSiteId { get; set; }
        
        [ForeignKey("MachineAreaTimeRegistration")]
        public int MachineAreaTimeRegistrationId { get; set; }
        
        public virtual MachineAreaTimeRegistration MachineAreaTimeRegistration { get; set; }
    }
}