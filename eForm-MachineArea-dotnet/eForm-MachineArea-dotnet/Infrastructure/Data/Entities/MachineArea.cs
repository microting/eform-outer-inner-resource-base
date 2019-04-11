using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using eFormShared;
using Microting.eFormApi.BasePn.Infrastructure.Database.Base;

namespace Microting.eFormMachineAreaBase.Infrastructure.Data.Entities
{
    public class MachineArea : BaseEntity
    {
        public MachineArea()
        {
            this.MachineAreaSites = new HashSet<MachineAreaSite>();
        }
        
        [ForeignKey("Machine")]
        public int MachineId { get; set; }

        public virtual Machine Machine { get; set; }

        [ForeignKey("Area")]
        public int AreaId { get; set; }

        public virtual Area Area { get; set; }
        
        public virtual ICollection<MachineAreaSite> MachineAreaSites { get; set; }
        
        public async Task Save(MachineAreaPnDbContext dbContext)
        {
            MachineArea machineArea = new MachineArea
            {
                MachineId = MachineId,
                AreaId = AreaId,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Version = 1,
                WorkflowState = Constants.WorkflowStates.Created
            };

            dbContext.MachineAreas.Add(machineArea);
            dbContext.SaveChanges();

            dbContext.MachineAreaVersions.Add(MapMachineAreaVersion(machineArea));
            dbContext.SaveChanges();
            
            Id = machineArea.Id;
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

                dbContext.MachineAreaVersions.Add(MapMachineAreaVersion(machineArea));
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

                dbContext.MachineAreaVersions.Add(MapMachineAreaVersion(machineArea));
                dbContext.SaveChanges();
            }
        }

        private MachineAreaVersion MapMachineAreaVersion(MachineArea machineArea)
        {
            MachineAreaVersion machineAreaVersionVer = new MachineAreaVersion();

            machineAreaVersionVer.AreaId = machineArea.AreaId;
            machineAreaVersionVer.MachineId = machineArea.MachineId;
            machineAreaVersionVer.Version = machineArea.Version;
            machineAreaVersionVer.CreatedAt = machineArea.CreatedAt;
            machineAreaVersionVer.UpdatedAt = machineArea.UpdatedAt;
            machineAreaVersionVer.MachineId = machineArea.Id;


            return machineAreaVersionVer;
        }
    }
}