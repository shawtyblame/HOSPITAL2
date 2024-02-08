using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class RequestVisit : EntityBase
    {
        public DateTime DateTime { get; set; }
        public int VisitorId { get; set; }
        [JsonIgnore]
        public UserMainInfo? Visitor { get; set; }
        public int DoctorId { get; set; }
        [JsonIgnore]
        public UserMainInfo? Doctor { get; set; }
    }
}
