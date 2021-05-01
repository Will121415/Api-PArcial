using Entity;

namespace apiParcial.models
{
    public class UserInputModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Status { get; set; }
        public string Role { get; set; }

    }

    public class UserViewModel: UserInputModel 
    {
        public UserViewModel() {}

        public UserViewModel(User user)
        {
            UserName = user.UserId;
            Password = user.Password;
            Status = user.Status;
            Role = user.Role;

        }
    }
}