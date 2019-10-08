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
using Microting.eFormApi.BasePn.Infrastructure.Database.Base;

namespace Microting.eFormOuterInnerResourceBase.Infrastructure.Data.Entities
{
    public class OuterResource : BaseEntity
    {
        public OuterResource()
        {
            this.OuterInnerResources = new HashSet<OuterInnerResource>();
        }

        [StringLength(250)]
        public string Name { get; set; }
        
        public virtual ICollection<OuterInnerResource> OuterInnerResources { get; set; }

        public async Task Create(OuterInnerResourcePnDbContext dbContext)
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
            Version = 1;
            WorkflowState = eForm.Infrastructure.Constants.Constants.WorkflowStates.Created;

            dbContext.OuterResources.Add(this);
            dbContext.SaveChanges();

            dbContext.OuterResourceVersions.Add(MapVersions(this));
            dbContext.SaveChanges();
        }

        public async Task Update(OuterInnerResourcePnDbContext dbContext)
        {
            OuterResource outerResource = dbContext.OuterResources.FirstOrDefault(x => x.Id == Id);

            if (outerResource == null)
            {
                throw new NullReferenceException($"Could not find area with id: {Id}");
            }

            outerResource.Name = Name;

            if (dbContext.ChangeTracker.HasChanges())
            {
                outerResource.UpdatedAt = DateTime.Now;
                outerResource.Version += 1;

                dbContext.OuterResourceVersions.Add(MapVersions(outerResource));
                dbContext.SaveChanges();
            }
        }

        public async Task Delete(OuterInnerResourcePnDbContext dbContext)
        {
            OuterResource outerResource = dbContext.OuterResources.FirstOrDefault(x => x.Id == Id);

            if (outerResource == null)
            {
                throw new NullReferenceException($"Could not find area with id: {Id}");
            }

            outerResource.WorkflowState = eForm.Infrastructure.Constants.Constants.WorkflowStates.Removed;

            if (dbContext.ChangeTracker.HasChanges())
            {
                outerResource.UpdatedAt = DateTime.Now;
                outerResource.Version += 1;

                dbContext.OuterResourceVersions.Add(MapVersions(outerResource));
                dbContext.SaveChanges();
            }
        }

        private OuterResourceVersion MapVersions(OuterResource outerResource)
        {
            OuterResourceVersion outerResourceVer = new OuterResourceVersion();

            outerResourceVer.Name = outerResource.Name;
            outerResourceVer.Version = outerResource.Version;
            outerResourceVer.OuterResourceId = outerResource.Id;
            outerResourceVer.CreatedAt = outerResource.CreatedAt;
            outerResourceVer.UpdatedAt = outerResource.UpdatedAt;


            return outerResourceVer;
        }
    }
}