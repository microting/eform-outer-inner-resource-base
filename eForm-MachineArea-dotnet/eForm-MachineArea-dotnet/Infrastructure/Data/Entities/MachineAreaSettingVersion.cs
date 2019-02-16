using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Microting.eFormMachineAreaBase.Infrastructure.Data.Entities
{
    public class MachineAreaSettingVersion : BaseEntity
    {        
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public string Value { get; set; }

        [ForeignKey("MachineAreaSetting")]
        public int MachineAreaSettingId { get; set; }
        
        public int Version { get; set; }
    }
}