

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using eFormShared;
using Microting.eFormApi.BasePn.Infrastructure.Database.Base;

namespace Microting.eFormMachineAreaBase.Infrastructure.Data.Entities
{
    public class MachineAreaSetting : BaseEntity
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public string Value { get; set; }
        
        public int Version { get; set; }


        public void Save(MachineAreaPnDbContext dbContext)
        {

            MachineAreaSetting machineAreaSetting = new MachineAreaSetting();
            if (CreatedAt != null)
            {
                machineAreaSetting.CreatedAt = (DateTime)CreatedAt;
            }

            machineAreaSetting.CreatedByUserId = CreatedByUserId;
            machineAreaSetting.UpdatedByUserId = UpdatedByUserId;
            machineAreaSetting.CreatedAt = DateTime.Now;
            machineAreaSetting.UpdatedAt = DateTime.Now;
            machineAreaSetting.Name = Name;
            machineAreaSetting.Value = Value;
            machineAreaSetting.Version = 1;
            machineAreaSetting.WorkflowState = Constants.WorkflowStates.Created;


            dbContext.MachineAreaSettings.Add(machineAreaSetting);
            dbContext.SaveChanges();

            dbContext.MachineAreaSettingVersions.Add(MapMachineAreaSettingVersion(dbContext, machineAreaSetting));
            dbContext.SaveChanges();
        }

        public void Update(MachineAreaPnDbContext dbContext)
        {

            MachineAreaSetting machineAreaSetting = dbContext.MachineAreaSettings.FirstOrDefault(x => x.Name == Name);

            if (machineAreaSetting == null)
            {
                throw new NullReferenceException($"Could not find TrashInspectionPnSettings with Name: {Name}");
            }

            machineAreaSetting.Value = Value;

            if (dbContext.ChangeTracker.HasChanges())
            {
                machineAreaSetting.UpdatedAt = DateTime.Now;
                machineAreaSetting.UpdatedByUserId = UpdatedByUserId;
                machineAreaSetting.Version += 1;

                dbContext.MachineAreaSettingVersions.Add(MapMachineAreaSettingVersion(dbContext, machineAreaSetting));
                dbContext.SaveChanges();
            }

        }

        public void Delete(MachineAreaPnDbContext dbContext)
        {

            MachineAreaSetting machineAreaSetting = dbContext.MachineAreaSettings.FirstOrDefault(x => x.Name == Name);

            if (machineAreaSetting == null)
            {
                throw new NullReferenceException($"Could not find trashInspectionPnSetting with Name: {Name}");
            }

            machineAreaSetting.WorkflowState = Constants.WorkflowStates.Removed;

            if (dbContext.ChangeTracker.HasChanges())
            {
                machineAreaSetting.UpdatedAt = DateTime.Now;
                machineAreaSetting.UpdatedByUserId = UpdatedByUserId;
                machineAreaSetting.Version += 1;
                dbContext.MachineAreaSettingVersions.Add(MapMachineAreaSettingVersion(dbContext, machineAreaSetting));
                dbContext.SaveChanges();
            }

        }

        private MachineAreaSettingVersion MapMachineAreaSettingVersion(MachineAreaPnDbContext dbContext,
            MachineAreaSetting machineAreaSetting)
        {
            MachineAreaSettingVersion machineAreaSettingVersion = new MachineAreaSettingVersion();

            machineAreaSettingVersion.CreatedAt = machineAreaSetting.CreatedAt;
            machineAreaSettingVersion.CreatedByUserId = machineAreaSetting.CreatedByUserId;
            machineAreaSettingVersion.Name = machineAreaSetting.Name;
            machineAreaSettingVersion.Value = machineAreaSetting.Value;
            machineAreaSettingVersion.UpdatedAt = machineAreaSetting.UpdatedAt;
            machineAreaSettingVersion.UpdatedByUserId = machineAreaSetting.UpdatedByUserId;
            machineAreaSettingVersion.Version = machineAreaSetting.Version;
            machineAreaSettingVersion.WorkflowState = machineAreaSetting.WorkflowState;

            machineAreaSettingVersion.MachineAreaSettingId = machineAreaSetting.Id;

            return machineAreaSettingVersion;
        }

        public string SettingRead(MachineAreaPnDbContext dbContext, Settings name)
        {
            MachineAreaSetting match = dbContext.MachineAreaSettings.Single(x => x.Name == name.ToString());

            if (match.Value == null)
                return "";

            return match.Value;
        }

        public List<string> SettingCheckAll(MachineAreaPnDbContext dbContext)
        {
            List<string> result = new List<string>();

            int countVal = dbContext.MachineAreaSettings.Count(x => x.Value == "");
            int countSet = dbContext.MachineAreaSettings.Count();

            if (countSet == 0)
            {
                result.Add("NO SETTINGS PRESENT, NEEDS PRIMING!");
                return result;
            }

            foreach (var setting in Enum.GetValues(typeof(Settings)))
            {
                try
                {
                    string readSetting = SettingRead(dbContext, (Settings)setting);
                    if (string.IsNullOrEmpty(readSetting))
                        result.Add(setting.ToString() + " has an empty value!");
                }
                catch
                {
                    result.Add("There is no setting for " + setting + "! You need to add one");
                }
            }
            return result;
        }     
    }
}