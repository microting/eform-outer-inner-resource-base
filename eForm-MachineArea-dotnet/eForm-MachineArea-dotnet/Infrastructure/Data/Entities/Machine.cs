/*
The MIT License (MIT)
Copyright (c) 2007 - 2019 Microting A/S
Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:
The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.
THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microting.eForm.Infrastructure.Constants;
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

        public async Task Create(MachineAreaPnDbContext dbContext)
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
            Version = 1;
            WorkflowState = Constants.WorkflowStates.Created;

            dbContext.Machines.Add(this);
            dbContext.SaveChanges();

            dbContext.MachineVersions.Add(MapVersions(this));
            dbContext.SaveChanges();
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

                dbContext.MachineVersions.Add(MapVersions(machine));
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

                dbContext.MachineVersions.Add(MapVersions(machine));
                dbContext.SaveChanges();
            }
        }

        private MachineVersion MapVersions(Machine machine)
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