using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalWPF.ViewModels
{
    public class HealingEventViewModel
    {
        public string Name { get; set; }
        public string PatientPhone { get; set; }
        public string DoctorName { get; set; }
        public string DoctorLastName { get; set; }
        public string HealingEventType { get; set; }
        public string Result { get; set; }
        public string Recommendation { get; set; }
        public float Price { get; set; }
    }
}

