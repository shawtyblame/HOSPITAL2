using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class MedicalCard : EntityBase
    {
        public DateTime StartDate { get; set; }
        public long?  Number { get; set; }
        public int UserMainInfoId { get; set; }
        [JsonIgnore]
        public UserMainInfo? UserMainInfo { get; set; }
    }
}
