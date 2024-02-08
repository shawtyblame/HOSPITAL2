namespace HospitalWEB.ViewModels
{
    public class HospitalizationViewModel
    {
        public DateTime HospitalizationTime { get; set; }
        public DateTime EndTime { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Departament { get; set; }
        public string? Condition { get; set; }
        public string? Target { get; set; }
        public string? Diagnosis { get; set; }
    }
}
