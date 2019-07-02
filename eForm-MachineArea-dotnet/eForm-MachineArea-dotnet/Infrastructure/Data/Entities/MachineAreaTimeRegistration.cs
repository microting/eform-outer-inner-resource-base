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
using eFormShared;
using Microting.eFormApi.BasePn.Infrastructure.Database.Base;

namespace Microting.eFormMachineAreaBase.Infrastructure.Data.Entities
{
    public class MachineAreaTimeRegistration : BaseEntity
    {
        [ForeignKey("Machine")]
        public int MachineId { get; set; }
        
        public virtual Machine Machine { get; set; }
        
        [ForeignKey("Area")]
        public int AreaId { get; set; }
        
        public virtual Area Area { get; set; }
        
        public DateTime DoneAt { get; set; }
        
        public int SDKCaseId { get; set; }
        
        public int SDKFieldValueId { get; set; }
        
        public int TimeInSeconds { get; set; }
        
        public int TimeInMinutes { get; set; }
        
        public int TimeInHours { get; set; }
        
        public int SDKSiteId { get; set; }

        public async Task Save(MachineAreaPnDbContext dbContext)
        {
            MachineAreaTimeRegistration area = new MachineAreaTimeRegistration
            {
                MachineId = MachineId,
                AreaId = AreaId,
                DoneAt = DoneAt,
                SDKCaseId = SDKCaseId,
                SDKFieldValueId = SDKFieldValueId,
                TimeInSeconds = TimeInSeconds,
                TimeInMinutes = TimeInMinutes,
                TimeInHours = TimeInHours,
                SDKSiteId = SDKSiteId,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Version = 1,
                WorkflowState = Constants.WorkflowStates.Created
            };

            dbContext.MachineAreaTimeRegistrations.Add(area);
            dbContext.SaveChanges();

            dbContext.MachineAreaTimeRegistrationVersions.Add(MapAreaVersion(area));
            dbContext.SaveChanges();
            Id = area.Id;
        }

        public async Task Update(MachineAreaPnDbContext dbContext)
        {
            MachineAreaTimeRegistration machineAreaTimeRegistration = dbContext.MachineAreaTimeRegistrations.FirstOrDefault(x => x.Id == Id);

            if (machineAreaTimeRegistration == null)
            {
                throw new NullReferenceException($"Could not find area with id: {Id}");
            }

            machineAreaTimeRegistration.MachineId = MachineId;
            machineAreaTimeRegistration.AreaId = AreaId;
            machineAreaTimeRegistration.DoneAt = DoneAt;
            machineAreaTimeRegistration.SDKCaseId = SDKCaseId;
            machineAreaTimeRegistration.SDKFieldValueId = SDKFieldValueId;
            machineAreaTimeRegistration.TimeInSeconds = TimeInSeconds;
            machineAreaTimeRegistration.TimeInMinutes = TimeInMinutes;
            machineAreaTimeRegistration.TimeInHours = TimeInHours;
            machineAreaTimeRegistration.SDKSiteId = SDKSiteId;

            if (dbContext.ChangeTracker.HasChanges())
            {
                machineAreaTimeRegistration.UpdatedAt = DateTime.Now;
                machineAreaTimeRegistration.Version += 1;

                dbContext.MachineAreaTimeRegistrationVersions.Add(MapAreaVersion(machineAreaTimeRegistration));
                dbContext.SaveChanges();
            }
        }

        public async Task Delete(MachineAreaPnDbContext dbContext)
        {
            MachineAreaTimeRegistration machineAreaTimeRegistration = dbContext.MachineAreaTimeRegistrations.FirstOrDefault(x => x.Id == Id);

            if (machineAreaTimeRegistration == null)
            {
                throw new NullReferenceException($"Could not find area with id: {Id}");
            }

            machineAreaTimeRegistration.WorkflowState = Constants.WorkflowStates.Removed;

            if (dbContext.ChangeTracker.HasChanges())
            {
                machineAreaTimeRegistration.UpdatedAt = DateTime.Now;
                machineAreaTimeRegistration.Version += 1;

                dbContext.MachineAreaTimeRegistrationVersions.Add(MapAreaVersion(machineAreaTimeRegistration));
                dbContext.SaveChanges();
            }
        }

        private MachineAreaTimeRegistrationVersion MapAreaVersion(MachineAreaTimeRegistration machineAreaTimeRegistration)
        {
            MachineAreaTimeRegistrationVersion machineAreaTimeRegistrationVersion = new MachineAreaTimeRegistrationVersion();


            machineAreaTimeRegistrationVersion.MachineId = machineAreaTimeRegistration.MachineId;
            machineAreaTimeRegistrationVersion.AreaId = machineAreaTimeRegistration.AreaId;
            machineAreaTimeRegistrationVersion.DoneAt = machineAreaTimeRegistration.DoneAt;
            machineAreaTimeRegistrationVersion.SDKCaseId = machineAreaTimeRegistration.SDKCaseId;
            machineAreaTimeRegistrationVersion.SDKFieldValueId = machineAreaTimeRegistration.SDKFieldValueId;
            machineAreaTimeRegistrationVersion.TimeInSeconds = machineAreaTimeRegistration.TimeInSeconds;
            machineAreaTimeRegistrationVersion.TimeInMinutes = machineAreaTimeRegistration.TimeInMinutes;
            machineAreaTimeRegistrationVersion.TimeInHours = machineAreaTimeRegistration.TimeInHours;
            machineAreaTimeRegistrationVersion.SDKSiteId = machineAreaTimeRegistration.SDKSiteId;
            machineAreaTimeRegistrationVersion.Version = machineAreaTimeRegistration.Version;
            machineAreaTimeRegistrationVersion.MachineAreaTimeRegistrationId = machineAreaTimeRegistration.Id;
            machineAreaTimeRegistrationVersion.CreatedAt = machineAreaTimeRegistration.CreatedAt;
            machineAreaTimeRegistrationVersion.UpdatedAt = machineAreaTimeRegistration.UpdatedAt;


            return machineAreaTimeRegistrationVersion;
        }
    }
}