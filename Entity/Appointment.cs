using System;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class Appointment
    {
        [Key]
        public string AppointmentId { get; set; }
        public DateTime Date { get; set; }
        public UserAttentionStaff UserAttentionStaff { get; set; }
        public Patient Patient { get; set; }
        
    }
}