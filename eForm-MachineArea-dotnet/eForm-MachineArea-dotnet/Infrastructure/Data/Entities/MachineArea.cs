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
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microting.eForm.Infrastructure.Constants;
using Microting.eFormApi.BasePn.Infrastructure.Database.Base;

namespace Microting.eFormMachineAreaBase.Infrastructure.Data.Entities
{
    public class MachineArea : BaseEntity
    {
//        public MachineArea()
//        {
//            this.MachineAreaSites = new HashSet<MachineAreaSite>();
//        }
        
        [ForeignKey("Machine")]
        public int MachineId { get; set; }

//        public virtual Machine Machine { get; set; }

        [ForeignKey("Area")]
        public int AreaId { get; set; }

//        public virtual Area Area { get; set; }
        
//        public virtual ICollection<MachineAreaSite> MachineAreaSites { get; set; }
        
        public async Task Create(MachineAreaPnDbContext dbContext)
        {

            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
            Version = 1;
            WorkflowState = Constants.WorkflowStates.Created;

            dbContext.MachineAreas.Add(this);
            dbContext.SaveChanges();

            dbContext.MachineAreaVersions.Add(MapVersions(this));
            dbContext.SaveChanges();
            
        }

        public async Task Update(MachineAreaPnDbContext dbContext)
        {
            MachineArea machineArea = dbContext.MachineAreas.FirstOrDefault(x => x.Id == Id);

            if (machineArea == null)
            {
                throw new NullReferenceException($"Could not find machineArea with id: {Id}");
            }

            machineArea.AreaId = AreaId;
            machineArea.MachineId = MachineId;

            if (dbContext.ChangeTracker.HasChanges())
            {
                machineArea.UpdatedAt = DateTime.Now;
                machineArea.Version += 1;

                dbContext.MachineAreaVersions.Add(MapVersions(machineArea));
                dbContext.SaveChanges();
            }
        }

        public async Task Delete(MachineAreaPnDbContext dbContext)
        {
            MachineArea machineArea = dbContext.MachineAreas.FirstOrDefault(x => x.Id == Id);

            if (machineArea == null)
            {
                throw new NullReferenceException($"Could not find machineArea with id: {Id}");
            }

            machineArea.WorkflowState = Constants.WorkflowStates.Removed;

            if (dbContext.ChangeTracker.HasChanges())
            {
                machineArea.UpdatedAt = DateTime.Now;
                machineArea.Version += 1;

                dbContext.MachineAreaVersions.Add(MapVersions(machineArea));
                dbContext.SaveChanges();
            }
        }

        private MachineAreaVersion MapVersions(MachineArea machineArea)
        {
            MachineAreaVersion machineAreaVersionVer = new MachineAreaVersion();

            machineAreaVersionVer.AreaId = machineArea.AreaId;
            machineAreaVersionVer.MachineId = machineArea.MachineId;
            machineAreaVersionVer.Version = machineArea.Version;
            machineAreaVersionVer.CreatedAt = machineArea.CreatedAt;
            machineAreaVersionVer.UpdatedAt = machineArea.UpdatedAt;
            machineAreaVersionVer.MachineAreaId = machineArea.Id;


            return machineAreaVersionVer;
        }
    }
}