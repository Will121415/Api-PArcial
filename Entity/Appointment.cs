using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    public class Appointment
    {

        public int AppointmentId { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }

        //relacion
        public Patient Patient { get; set; }
        public UserAttentionStaff UserAttentionStaff { get; set; }
        

        public Appointment(DateTime date , String status)
        {
            Date = date;
            Status = status;
            
        }
        
    }
}