using apiParcial.models;
using Entity;

namespace apiParcial.Controllers
{
    public class MetodosServices
    {
        public Patient MapearPatient(PatientInputModel patientInputModel)
        {
            var patient = new Patient
            {
                PatientId = patientInputModel.PatientId,
                Name = patientInputModel.Name,
                LastName = patientInputModel.LastName,
                Photo = patientInputModel.Photo,
                Age = patientInputModel.Age,
                Address = patientInputModel.Address,
                Neighborhood = patientInputModel.Neighborhood,
                Phone = patientInputModel.Phone,
                City = patientInputModel.City,

            };


            return patient;
        }
    }
}