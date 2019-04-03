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
        
        public int Version { get; set; }

        public async Task Save(MachineAreaPnDbContext _dbContext)
        {
            Machine machine = new Machine
            {
                Name = Name,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Version = 1,
                WorkflowState = Constants.WorkflowStates.Created
            };

            _dbContext.Machines.Add(machine);
            _dbContext.SaveChanges();

            _dbContext.MachineVersions.Add(MapMachineVersion(_dbContext, machine));
            _dbContext.SaveChanges();
            Id = machine.Id;
        }

        public async Task Update(MachineAreaPnDbContext _dbContext)
        {
            Machine machine = _dbContext.Machines.FirstOrDefault(x => x.Id == Id);

            if (machine == null)
            {
                throw new NullReferenceException($"Could not find Machine with id: {Id}");
            }

            machine.Name = Name;
            // TODO: INSERT UPDATE MAPPING

            if (_dbContext.ChangeTracker.HasChanges())
            {
                machine.UpdatedAt = DateTime.Now;
                machine.Version += 1;

                _dbContext.MachineVersions.Add(MapMachineVersion(_dbContext, machine));
                _dbContext.SaveChanges();
            }
        }

        public async Task Delete(MachineAreaPnDbContext _dbContext)
        {
            Machine machine = _dbContext.Machines.FirstOrDefault(x => x.Id == Id);

            if (machine == null)
            {
                throw new NullReferenceException($"Could not find machine with id: {Id}");
            }

            machine.WorkflowState = Constants.WorkflowStates.Removed;

            if (_dbContext.ChangeTracker.HasChanges())
            {
                machine.UpdatedAt = DateTime.Now;
                machine.Version += 1;

                _dbContext.MachineVersions.Add(MapMachineVersion(_dbContext, machine));
                _dbContext.SaveChanges();
            }
        }

        private MachineVersion MapMachineVersion(MachineAreaPnDbContext _dbContext, Machine machine)
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