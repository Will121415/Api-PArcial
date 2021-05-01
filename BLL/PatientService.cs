using System;
using System.Linq;
using DAL;
using Entity;
using Microsoft.EntityFrameworkCore;

namespace BLL
{
    public class PatientService
    {
        private readonly ParcialContext _context;
        public PatientService(ParcialContext context) => _context = context;


        public Response<Patient> Save(Patient patient)
        {
            try
            {
                patient.Status= "Active";
                _context.Patients.Add(patient);
                _context.SaveChanges();
                return new Response<Patient>(patient);

            }
            catch (Exception e)
            {
                /// esta linea es de prueba 
                return new Response<Patient>("Error: " + e);
            }
        }

        public ResponseList<Patient> AllPatient()
        {
            try
            {
                var patients = _context.Patients.Include(p=>p.appointments).ToList();
                return new ResponseList<Patient>(patients);

            }
            catch (Exception e)
            {

                return new ResponseList<Patient>("Error " + e);
            }
        }

        public Response<Patient> Update(Patient patient)
        {
            try
            {
                var oldPatient = _context.Patients.Find(patient.PatientId);
                if (oldPatient == null) return new Response<Patient>("El paciente no se encuentra registrado");
                oldPatient.Name = (patient.Name == oldPatient.Name) ? oldPatient.Name : patient.Name;
                oldPatient.LastName = (patient.LastName == oldPatient.LastName) ? oldPatient.LastName : patient.LastName;
                oldPatient.Photo = (oldPatient.Photo == patient.Photo) ? oldPatient.Photo : patient.Photo;
                oldPatient.Age = (oldPatient.Age == patient.Age) ? oldPatient.Age : patient.Age;
                oldPatient.Address = (oldPatient.Address == patient.Address) ? oldPatient.Address : patient.Address;
                oldPatient.Neighborhood = (oldPatient.Neighborhood == patient.Neighborhood) ? oldPatient.Neighborhood : patient.Neighborhood;
                oldPatient.Phone = (oldPatient.Phone == patient.Photo) ? oldPatient.Phone : patient.Photo;
                oldPatient.City = (oldPatient.City == patient.City) ? oldPatient.City : patient.City;
                oldPatient.Status = (oldPatient.Status == patient.Status) ? oldPatient.Status : patient.Status;
                _context.Patients.Update(oldPatient);
                _context.SaveChanges();
                return new Response<Patient>(oldPatient);

            }
            catch (Exception e)
            {
                return new Response<Patient>("Error: " + e);
            }
        }


        public Response<Patient> Delete(String patientId)
        {
            try
            {
                var allPatient = AllPatient();
                if(allPatient.Object==null) return new Response<Patient>(allPatient.Message);
                var oldPatient = allPatient.Object.Where(P=>P.PatientId==patientId).FirstOrDefault();
                if (oldPatient == null) return new Response<Patient>("El paciente no se encuentra registrado");
                _context.Appointments.RemoveRange(oldPatient.appointments);
                _context.Patients.Remove(oldPatient);
                _context.SaveChanges();
                return new Response<Patient>(oldPatient);

            }
            catch (Exception e)
            {
                return new Response<Patient>("Error: " + e);
            }


        }

    }
}