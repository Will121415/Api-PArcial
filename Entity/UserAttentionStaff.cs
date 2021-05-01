using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class UserAttentionStaff
    {
        public string UserAttentionStaffId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Type { get; set; }
        public string Photo { get; set; }
        public string ServiceStatus { get; set; }
        public virtual User User { get; set; }

        // relacion 
        public virtual List<Appointment> appointments { get; set; } 
        
    }
}