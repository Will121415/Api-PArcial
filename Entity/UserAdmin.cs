using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class UserAdmin
    {
        [Key]
        public string AdminId {get; set; }
        public User User { get; set; }
    }
}