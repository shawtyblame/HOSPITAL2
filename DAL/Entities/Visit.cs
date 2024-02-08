using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Visit : EntityBase
    {
        public int MedicalCardId { get; set; }
        [JsonIgnore]
        public MedicalCard MedicalCard { get; set; }
        public string? Recommaendation { get; set; }
        public string? Notes { get; set; }
        public int DoctorId {  get; set; }
        [JsonIgnore]
        public UserMainInfo Doctor { get; set; }
        public int RequestVisitId { get; set; }
        [JsonIgnore]
        public RequestVisit RequestVisit { get; set; }
    }
}
