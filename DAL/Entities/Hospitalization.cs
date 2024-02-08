using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Hospitalization : EntityBase
    {
        public DateTime? HospitalizationTime { get; set; }
        public DateTime? EndDate { get; set; }
        public int UserInfoId { get; set; }
        [JsonIgnore]
        public UserMainInfo? UserInfo { get; set; } 
        public string? Diagnosis { get; set; }
        public string? Target { get; set; }
        public int DepartmentId {get; set; }
        [JsonIgnore]
        public Department Department { get; set; }
        public int HospitalizationConditionId { get; set; }
        [JsonIgnore]
        public HospitalizationCondition HospitalizationConditions { get; set; }    
        public int HospitalizationStatusId { get; set; }
        [JsonIgnore]
        public HospitalizationStatus? HospitalizationStatus { get; set; }
    }
}
