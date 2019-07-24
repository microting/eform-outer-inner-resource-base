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
    public class Area : BaseEntity
    {
        public Area()
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

            dbContext.Areas.Add(this);
            dbContext.SaveChanges();

            dbContext.AreaVersions.Add(MapVersions(this));
            dbContext.SaveChanges();
        }

        public async Task Update(MachineAreaPnDbContext dbContext)
        {
            Area area = dbContext.Areas.FirstOrDefault(x => x.Id == Id);

            if (area == null)
            {
                throw new NullReferenceException($"Could not find area with id: {Id}");
            }

            area.Name = Name;

            if (dbContext.ChangeTracker.HasChanges())
            {
                area.UpdatedAt = DateTime.Now;
                area.Version += 1;

                dbContext.AreaVersions.Add(MapVersions(area));
                dbContext.SaveChanges();
            }
        }

        public async Task Delete(MachineAreaPnDbContext dbContext)
        {
            Area area = dbContext.Areas.FirstOrDefault(x => x.Id == Id);

            if (area == null)
            {
                throw new NullReferenceException($"Could not find area with id: {Id}");
            }

            area.WorkflowState = Constants.WorkflowStates.Removed;

            if (dbContext.ChangeTracker.HasChanges())
            {
                area.UpdatedAt = DateTime.Now;
                area.Version += 1;

                dbContext.AreaVersions.Add(MapVersions(area));
                dbContext.SaveChanges();
            }
        }

        private AreaVersion MapVersions(Area area)
        {
            AreaVersion areaVer = new AreaVersion();

            areaVer.Name = area.Name;
            areaVer.Version = area.Version;
            areaVer.AreaId = area.Id;
            areaVer.CreatedAt = area.CreatedAt;
            areaVer.UpdatedAt = area.UpdatedAt;


            return areaVer;
        }
    }
}