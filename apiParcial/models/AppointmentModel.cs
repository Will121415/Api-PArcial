using System;
using Entity;

namespace apiParcial.models
{
    public class AppointmentInputModel
    {

        public DateTime Date { get; set; }
        public String PatientId { get; set; }
        
    }

    public class AppointmentViewModel : AppointmentInputModel
    {
        public int AppointmentId { get; set; }
        public PatientViewModel Patient { get; set; }
        
        public AttentionStaffViewModel UserAttentionStaff { get; set; }
        public string Status { get; set; }

        public AppointmentViewModel() { }

        public AppointmentViewModel(Appointment appointment)
        {
            Date = appointment.Date;
            UserAttentionStaff =(appointment.UserAttentionStaff==null)?null: new AttentionStaffViewModel(appointment.UserAttentionStaff);
            Patient = (appointment.Patient==null)?null: new PatientViewModel(appointment.Patient);
            AppointmentId = appointment.AppointmentId;
            Status = appointment.Status;


        }

    }
}