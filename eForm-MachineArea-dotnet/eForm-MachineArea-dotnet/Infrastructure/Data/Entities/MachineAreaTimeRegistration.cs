using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Microting.eFormMachineAreaBase.Infrastructure.Data.Entities
{
    public class MachineAreaTimeRegistration : BaseEntity
    {
        public int MachineId { get; set; }
        public virtual Machine Machine { get; set; }
        public int AreaId { get; set; }
        public virtual Area Area { get; set; }
        public DateTime DoneAt { get; set; }
        public int SDKCaseId { get; set; }
        public int SDKFieldValueId { get; set; }
        public int TimeInSeconds { get; set; }

    }
}