using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class Patient
    {
        public string PatientId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Photo { get; set; }
        public string Age { get; set; }
        public string Address { get; set; }
        public string Neighborhood { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        public string Status { get; set; }


        //relacion 
        public virtual List<Appointment> appointments { get; set; }  
    }
}