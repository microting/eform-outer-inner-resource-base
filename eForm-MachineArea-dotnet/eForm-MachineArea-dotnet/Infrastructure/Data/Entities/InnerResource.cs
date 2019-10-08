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
    public class InnerResource : BaseEntity
    {
//        public Machine()
//        {
//            this.MachineAreas = new HashSet<MachineArea>();
//        }

        [StringLength(250)]
        public string Name { get; set; }
        
//        public virtual ICollection<MachineArea> MachineAreas { get; set; }

        public async Task Create(OuterInnerResourcePnDbContext dbContext)
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
            Version = 1;
            WorkflowState = Constants.WorkflowStates.Created;

            dbContext.InnerResources.Add(this);
            dbContext.SaveChanges();

            dbContext.InnerResourceVersions.Add(MapVersions(this));
            dbContext.SaveChanges();
        }

        public async Task Update(OuterInnerResourcePnDbContext dbContext)
        {
            InnerResource innerResource = dbContext.InnerResources.FirstOrDefault(x => x.Id == Id);

            if (innerResource == null)
            {
                throw new NullReferenceException($"Could not find Machine with id: {Id}");
            }

            innerResource.Name = Name;
            // TODO: INSERT UPDATE MAPPING

            if (dbContext.ChangeTracker.HasChanges())
            {
                innerResource.UpdatedAt = DateTime.Now;
                innerResource.Version += 1;

                dbContext.InnerResourceVersions.Add(MapVersions(innerResource));
                dbContext.SaveChanges();
            }
        }

        public async Task Delete(OuterInnerResourcePnDbContext dbContext)
        {
            InnerResource innerResource = dbContext.InnerResources.FirstOrDefault(x => x.Id == Id);

            if (innerResource == null)
            {
                throw new NullReferenceException($"Could not find machine with id: {Id}");
            }

            innerResource.WorkflowState = Constants.WorkflowStates.Removed;

            if (dbContext.ChangeTracker.HasChanges())
            {
                innerResource.UpdatedAt = DateTime.Now;
                innerResource.Version += 1;

                dbContext.InnerResourceVersions.Add(MapVersions(innerResource));
                dbContext.SaveChanges();
            }
        }

        private InnerResourceVersion MapVersions(InnerResource innerResource)
        {
            InnerResourceVersion innerResourceVer = new InnerResourceVersion();

            innerResourceVer.Name = innerResource.Name;
            innerResourceVer.InnerResourceId = innerResource.Id;
            innerResourceVer.Version = innerResource.Version;
            innerResourceVer.CreatedAt = innerResource.CreatedAt;
            innerResourceVer.UpdatedAt = innerResource.UpdatedAt;
            innerResourceVer.InnerResourceId = innerResource.Id;


            return innerResourceVer;
        }
    }
}