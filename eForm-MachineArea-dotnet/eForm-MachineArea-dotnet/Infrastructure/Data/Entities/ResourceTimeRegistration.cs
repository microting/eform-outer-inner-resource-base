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
using Microting.eForm.Infrastructure.Constants;
using Microting.eFormApi.BasePn.Infrastructure.Database.Base;

namespace Microting.eFormMachineAreaBase.Infrastructure.Data.Entities
{
    public class ResourceTimeRegistration : BaseEntity
    {
        [ForeignKey("Machine")]
        public int InnerResourceId { get; set; }
        
//        public virtual Machine Machine { get; set; }
        
        [ForeignKey("Area")]
        public int OuterResourceId { get; set; }
        
//        public virtual Area Area { get; set; }
        
        public DateTime DoneAt { get; set; }
        
        public int SDKCaseId { get; set; }
        
        public int SDKFieldValueId { get; set; }
        
        public int TimeInSeconds { get; set; }
        
        public int TimeInMinutes { get; set; }
        
        public int TimeInHours { get; set; }
        
        public int SDKSiteId { get; set; }

        public async Task Create(MachineAreaPnDbContext dbContext)
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
            Version = 1;
            WorkflowState = Constants.WorkflowStates.Created;
     
            dbContext.ResourceTimeRegistrations.Add(this);
            dbContext.SaveChanges();

            dbContext.ResourceTimeRegistrationVersions.Add(MapVersions(this));
            dbContext.SaveChanges();
        }

        public async Task Update(MachineAreaPnDbContext dbContext)
        {
            ResourceTimeRegistration resourceTimeRegistration = dbContext.ResourceTimeRegistrations.FirstOrDefault(x => x.Id == Id);

            if (resourceTimeRegistration == null)
            {
                throw new NullReferenceException($"Could not find area with id: {Id}");
            }

            resourceTimeRegistration.InnerResourceId = InnerResourceId;
            resourceTimeRegistration.OuterResourceId = OuterResourceId;
            resourceTimeRegistration.DoneAt = DoneAt;
            resourceTimeRegistration.SDKCaseId = SDKCaseId;
            resourceTimeRegistration.SDKFieldValueId = SDKFieldValueId;
            resourceTimeRegistration.TimeInSeconds = TimeInSeconds;
            resourceTimeRegistration.TimeInMinutes = TimeInMinutes;
            resourceTimeRegistration.TimeInHours = TimeInHours;
            resourceTimeRegistration.SDKSiteId = SDKSiteId;

            if (dbContext.ChangeTracker.HasChanges())
            {
                resourceTimeRegistration.UpdatedAt = DateTime.Now;
                resourceTimeRegistration.Version += 1;

                dbContext.ResourceTimeRegistrationVersions.Add(MapVersions(resourceTimeRegistration));
                dbContext.SaveChanges();
            }
        }

        public async Task Delete(MachineAreaPnDbContext dbContext)
        {
            ResourceTimeRegistration resourceTimeRegistration = dbContext.ResourceTimeRegistrations.FirstOrDefault(x => x.Id == Id);

            if (resourceTimeRegistration == null)
            {
                throw new NullReferenceException($"Could not find area with id: {Id}");
            }

            resourceTimeRegistration.WorkflowState = Constants.WorkflowStates.Removed;

            if (dbContext.ChangeTracker.HasChanges())
            {
                resourceTimeRegistration.UpdatedAt = DateTime.Now;
                resourceTimeRegistration.Version += 1;

                dbContext.ResourceTimeRegistrationVersions.Add(MapVersions(resourceTimeRegistration));
                dbContext.SaveChanges();
            }
        }

        private ResourceTimeRegistrationVersion MapVersions(ResourceTimeRegistration resourceTimeRegistration)
        {
            ResourceTimeRegistrationVersion resourceTimeRegistrationVersion = new ResourceTimeRegistrationVersion();


            resourceTimeRegistrationVersion.InnerResourceId = resourceTimeRegistration.InnerResourceId;
            resourceTimeRegistrationVersion.OuterResourceId = resourceTimeRegistration.OuterResourceId;
            resourceTimeRegistrationVersion.DoneAt = resourceTimeRegistration.DoneAt;
            resourceTimeRegistrationVersion.SDKCaseId = resourceTimeRegistration.SDKCaseId;
            resourceTimeRegistrationVersion.SDKFieldValueId = resourceTimeRegistration.SDKFieldValueId;
            resourceTimeRegistrationVersion.TimeInSeconds = resourceTimeRegistration.TimeInSeconds;
            resourceTimeRegistrationVersion.TimeInMinutes = resourceTimeRegistration.TimeInMinutes;
            resourceTimeRegistrationVersion.TimeInHours = resourceTimeRegistration.TimeInHours;
            resourceTimeRegistrationVersion.SDKSiteId = resourceTimeRegistration.SDKSiteId;
            resourceTimeRegistrationVersion.Version = resourceTimeRegistration.Version;
            resourceTimeRegistrationVersion.MachineAreaTimeRegistrationId = resourceTimeRegistration.Id;
            resourceTimeRegistrationVersion.CreatedAt = resourceTimeRegistration.CreatedAt;
            resourceTimeRegistrationVersion.UpdatedAt = resourceTimeRegistration.UpdatedAt;


            return resourceTimeRegistrationVersion;
        }
    }
}