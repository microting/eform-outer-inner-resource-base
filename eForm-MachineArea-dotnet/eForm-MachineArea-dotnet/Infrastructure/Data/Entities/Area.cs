using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using eFormShared;
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

        public async Task Save(MachineAreaPnDbContext dbContext)
        {
            Area area = new Area
            {
                Name = Name,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Version = 1,
                WorkflowState = Constants.WorkflowStates.Created
            };

            dbContext.Areas.Add(area);
            dbContext.SaveChanges();

            dbContext.AreaVersions.Add(MapAreaVersion(area));
            dbContext.SaveChanges();
            Id = area.Id;
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

                dbContext.AreaVersions.Add(MapAreaVersion(area));
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

                dbContext.AreaVersions.Add(MapAreaVersion(area));
                dbContext.SaveChanges();
            }
        }

        private AreaVersion MapAreaVersion(Area area)
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