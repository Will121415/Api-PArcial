using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class UserAttentionStaff
    {
        [Key]
        public string AttentionId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Type { get; set; }
        public string Photo { get; set; }
        public string ServiceStatus { get; set; }
        public virtual User User { get; set; }
        
    }
}