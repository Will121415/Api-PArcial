using System.Collections.Generic;
using System;
using System.Linq;
using DAL;
using Entity;
using Microsoft.EntityFrameworkCore;

namespace BLL
{
    public class AppointmentService
    {
        private readonly ParcialContext _context;

        String[] Status = {"Atendido", "En Servicio", "No Atendido", "Asignado", "Anulada"};


        public AppointmentService(ParcialContext context )=> _context = context;

        public Response<Appointment> Save(String PtientId, DateTime fecha)
        {
            try
            {
                Appointment newApoit = new Appointment(fecha,Status[2]);
                var patients = _context.Patients.Include(p => p.appointments);
                if(patients==null)  return new Response<Appointment>("No hay pacientes registrados");
                var patient = patients.Where(p=>p.PatientId == PtientId).FirstOrDefault();
                if(patient==null)  return new Response<Appointment>("El Paciente no se escuantra registrado");
                if(patient.appointments == null) patient.appointments = new List<Appointment>();
                patient.appointments.Add(newApoit);
                _context.Patients.Update(patient);
                _context.SaveChanges();
                return new Response<Appointment>(newApoit);

            }
            catch (Exception e)
            {
                /// esta linea es de prueba 
                return new Response<Appointment>("Error: " + e);
            }
        }

        public Response<Appointment> AssignAppointment(String appointmentId,String IduserStaff)
        {
            try
            {
                var staff = _context.UserAttentionStaffs.Find(IduserStaff);
                var appointment = _context.Appointments.Find(appointmentId);

                if(staff==null)  return new Response<Appointment>("El Usuario de atencion no se escuantra registrado");
                if(appointment==null)  return new Response<Appointment>("la cita no se encuntra registrada");
                appointment.UserAttentionStaff = staff;
                appointment.Status= Status[3];
                _context.Appointments.Update(appointment);
                _context.SaveChanges();
                return new Response<Appointment>(appointment);

            }
            catch (Exception e)
            {
                /// esta linea es de prueba 
                return new Response<Appointment>("Error: " + e);
            }
        }

        public Response<Appointment> ChanceState(String appointmentId,int status)
        {
            try
            {
                var appointment = _context.Appointments.Find(appointmentId);
                if(appointment==null)  return new Response<Appointment>("la cita no se encuntra registrada");

                appointment.Status= Status[status];
                _context.Appointments.Update(appointment);

                return new Response<Appointment>(appointment);

            }
            catch (Exception e)
            {
                /// esta linea es de prueba 
                return new Response<Appointment>("Error: " + e);
            }
        }

        public ResponseList<Appointment> AllAppointments()
        {
            try
            {
                var list= _context.Appointments.Include(p=>p.Patient).Include(b=>b.UserAttentionStaff).ToList();
                return new ResponseList<Appointment>(list);

            }
            catch (Exception e)
            {
                /// esta linea es de prueba 
                return new ResponseList<Appointment>("Error: " + e);
            }
        }
        public ResponseList<Appointment> FindByUserNull()
        {
            try
            {
                var allAppointments = AllAppointments();
                if(allAppointments.Object == null) return new ResponseList<Appointment>("No hay registros de citas");
                var list= allAppointments.Object.Where(p=>p.UserAttentionStaff==null).ToList();
                if(list == null) return new ResponseList<Appointment>("Todas las citas registradas tienen asigando un personal de atencion");
                return new ResponseList<Appointment>(list);

            }
            catch (Exception e)
            {
                /// esta linea es de prueba 
                return new ResponseList<Appointment>("Error: " + e);
            }
        }

        public ResponseList<Appointment> FindByUserIsNoNull()
        {
            try
            {
                var allAppointments = AllAppointments();
                if(allAppointments.Object == null) return new ResponseList<Appointment>("No hay registros de citas");
                var list= _context.Appointments.Where(p=>p.UserAttentionStaff!=null).ToList();
                if(list == null) return new ResponseList<Appointment>("Las citas registradas no tienen ningun usuario de atencion asignado");
                
                return new ResponseList<Appointment>(list);

            }
            catch (Exception e)
            {
                /// esta linea es de prueba 
                return new ResponseList<Appointment>("Error: " + e);
            }
        }

        public ResponseList<Appointment> FindByIdUser(String staffid)
        {
            try
            {
                var staff = _context.UserAttentionStaffs.Find(staffid);
                if(staff==null)  return new ResponseList<Appointment>("El Usuario de atencion no se escuantra registrado");
                var list= _context.Appointments.Where(p=>p.UserAttentionStaff.UserAttentionStaffId ==staff.UserAttentionStaffId).ToList();
                return new ResponseList<Appointment>(list);

            }
            catch (Exception e)
            {
                /// esta linea es de prueba 
                return new ResponseList<Appointment>("Error: " + e);
            }
        }



    }
}