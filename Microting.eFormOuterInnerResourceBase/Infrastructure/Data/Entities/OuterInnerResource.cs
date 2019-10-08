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
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microting.eFormApi.BasePn.Infrastructure.Database.Base;

namespace Microting.eFormOuterInnerResourceBase.Infrastructure.Data.Entities
{
    public class OuterInnerResource : BaseEntity
    {
//        public MachineArea()
//        {
//            this.MachineAreaSites = new HashSet<MachineAreaSite>();
//        }
        
        [ForeignKey("Machine")]
        public int InnerResourceId { get; set; }

//        public virtual Machine Machine { get; set; }

        [ForeignKey("Area")]
        public int OuterResourceId { get; set; }

//        public virtual Area Area { get; set; }
        
//        public virtual ICollection<MachineAreaSite> MachineAreaSites { get; set; }
        
        public async Task Create(OuterInnerResourcePnDbContext dbContext)
        {

            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
            Version = 1;
            WorkflowState = eForm.Infrastructure.Constants.Constants.WorkflowStates.Created;

            dbContext.OuterInnerResources.Add(this);
            dbContext.SaveChanges();

            dbContext.OuterInnerResourceVersions.Add(MapVersions(this));
            dbContext.SaveChanges();
            
        }

        public async Task Update(OuterInnerResourcePnDbContext dbContext)
        {
            OuterInnerResource outerInnerResource = dbContext.OuterInnerResources.FirstOrDefault(x => x.Id == Id);

            if (outerInnerResource == null)
            {
                throw new NullReferenceException($"Could not find machineArea with id: {Id}");
            }

            outerInnerResource.OuterResourceId = OuterResourceId;
            outerInnerResource.InnerResourceId = InnerResourceId;

            if (dbContext.ChangeTracker.HasChanges())
            {
                outerInnerResource.UpdatedAt = DateTime.Now;
                outerInnerResource.Version += 1;

                dbContext.OuterInnerResourceVersions.Add(MapVersions(outerInnerResource));
                dbContext.SaveChanges();
            }
        }

        public async Task Delete(OuterInnerResourcePnDbContext dbContext)
        {
            OuterInnerResource outerInnerResource = dbContext.OuterInnerResources.FirstOrDefault(x => x.Id == Id);

            if (outerInnerResource == null)
            {
                throw new NullReferenceException($"Could not find machineArea with id: {Id}");
            }

            outerInnerResource.WorkflowState = eForm.Infrastructure.Constants.Constants.WorkflowStates.Removed;

            if (dbContext.ChangeTracker.HasChanges())
            {
                outerInnerResource.UpdatedAt = DateTime.Now;
                outerInnerResource.Version += 1;

                dbContext.OuterInnerResourceVersions.Add(MapVersions(outerInnerResource));
                dbContext.SaveChanges();
            }
        }

        private OuterInnerResourceVersion MapVersions(OuterInnerResource outerInnerResource)
        {
            OuterInnerResourceVersion outerInnerResourceVersionVer = new OuterInnerResourceVersion();

            outerInnerResourceVersionVer.OuterResourceId = outerInnerResource.OuterResourceId;
            outerInnerResourceVersionVer.InnerResourceId = outerInnerResource.InnerResourceId;
            outerInnerResourceVersionVer.Version = outerInnerResource.Version;
            outerInnerResourceVersionVer.CreatedAt = outerInnerResource.CreatedAt;
            outerInnerResourceVersionVer.UpdatedAt = outerInnerResource.UpdatedAt;
            outerInnerResourceVersionVer.OuterInnerResourceId = outerInnerResource.Id;


            return outerInnerResourceVersionVer;
        }
    }
}