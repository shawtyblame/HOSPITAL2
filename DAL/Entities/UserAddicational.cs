using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class UserAddicational : EntityBase
    {
        public DateTime DateOfBirth { get; set; }
        public string? Address { get; set; }
        public string? WorkPlace { get; set; }
        public long? InsurancePolicyNumber { get; set; }
        public DateTime InsurancePolicyDateEnd {  get; set; }
        public int UserMainInfoId { get; set; }
        [JsonIgnore]
        public UserMainInfo? UserMainInfo { get; set; }
    }
}
