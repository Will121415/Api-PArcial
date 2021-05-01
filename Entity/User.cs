using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Entity
{
    public class User
    {
        public string UserId { get; set; }
        public string Password { get; set; }
        public string Status { get; set; }
        public string Role { get; set; }
        
        
        
        
    }
}