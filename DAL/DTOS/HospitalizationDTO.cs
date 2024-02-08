using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTOS
{
    public class HospitalizationDTO
    {
        public string? PhoneNumber { get; set; }
        public string? Departament { get; set; }
        public string? Condition { get; set; }
        public string? Target { get; set; }
        public string? Diagnosis { get; set; }
    }
}
