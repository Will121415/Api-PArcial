using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class UserAdmin
    {
        public string UserAdminId {get; set; }
        public User User { get; set; }
    }
}