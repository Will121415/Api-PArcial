using Entity;

namespace apiParcial.models
{
    public class PatientInputModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Photo { get; set; }
        public string Age { get; set; }
        public string Address { get; set; }
        public string Neighborhood { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }

    }

    public class PatientViewModel : PatientInputModel
    {
        public string PatientId { get; set; }
        public string Status { get; set; }
        public PatientViewModel() { }

        public PatientViewModel(Patient patient)
        {
            PatientId = patient.PatientId;
            Name = patient.Name;
            LastName = patient.LastName;
            Photo = patient.Photo;
            Age = patient.Age;
            Address = patient.Address;
            Neighborhood = patient.Neighborhood;
            Phone = patient.Phone;
            City = patient.City;
            Status = patient.Status;
            
            
        }
    }
}