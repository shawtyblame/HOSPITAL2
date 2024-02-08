using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class UserMainInfo : EntityBase
    {
        public string? Name { get; set; }
        public string? Lastname { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public long PassportSeries { get; set; }
        public long PassportNumber { get; set; }
        public int GenderId { get; set; }
        [JsonIgnore]
        public Gender? Gender { get; set; }
        public int UserId { get; set; }
        [JsonIgnore]
        public UserCredential User { get; set; }
    }
}
