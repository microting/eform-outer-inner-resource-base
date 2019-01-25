namespace Microting.eFormMachineAreaBase.Infrastructure.Data.Entities
{
    public class MachineArea : BaseEntity
    {
        public int MachineId { get; set; }
        public virtual Machine Machine { get; set; }
        public int AreaId { get; set; }
        public virtual Area Area { get; set; }
        public int MicrotingeFormSdkId { get; set; }
    }
}