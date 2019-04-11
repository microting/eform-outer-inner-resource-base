using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using eFormShared;
using Microting.eFormApi.BasePn.Infrastructure.Database.Base;

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

        public async Task Save(MachineAreaPnDbContext dbContext)
        {
            Machine machine = new Machine
            {
                Name = Name,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Version = 1,
                WorkflowState = Constants.WorkflowStates.Created
            };

            dbContext.Machines.Add(machine);
            dbContext.SaveChanges();

            dbContext.MachineVersions.Add(MapMachineVersion(machine));
            dbContext.SaveChanges();
            Id = machine.Id;
        }

        public async Task Update(MachineAreaPnDbContext dbContext)
        {
            Machine machine = dbContext.Machines.FirstOrDefault(x => x.Id == Id);

            if (machine == null)
            {
                throw new NullReferenceException($"Could not find Machine with id: {Id}");
            }

            machine.Name = Name;
            // TODO: INSERT UPDATE MAPPING

            if (dbContext.ChangeTracker.HasChanges())
            {
                machine.UpdatedAt = DateTime.Now;
                machine.Version += 1;

                dbContext.MachineVersions.Add(MapMachineVersion(machine));
                dbContext.SaveChanges();
            }
        }

        public async Task Delete(MachineAreaPnDbContext dbContext)
        {
            Machine machine = dbContext.Machines.FirstOrDefault(x => x.Id == Id);

            if (machine == null)
            {
                throw new NullReferenceException($"Could not find machine with id: {Id}");
            }

            machine.WorkflowState = Constants.WorkflowStates.Removed;

            if (dbContext.ChangeTracker.HasChanges())
            {
                machine.UpdatedAt = DateTime.Now;
                machine.Version += 1;

                dbContext.MachineVersions.Add(MapMachineVersion(machine));
                dbContext.SaveChanges();
            }
        }

        private MachineVersion MapMachineVersion(Machine machine)
        {
            MachineVersion machineVer = new MachineVersion();

            machineVer.Name = machine.Name;
            machineVer.Machine = machine;
            machineVer.Version = machine.Version;
            machineVer.CreatedAt = machine.CreatedAt;
            machineVer.UpdatedAt = machine.UpdatedAt;
            machineVer.MachineId = machine.Id;


            return machineVer;
        }
    }
}