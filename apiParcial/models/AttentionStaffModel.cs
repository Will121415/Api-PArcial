using Entity;

namespace apiParcial.models
{ 
    public class AttentionStaffInputModel
    {
        public string AttentionId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Type { get; set; }
        public string Photo { get; set; }
        public string ServiceStatus { get; set; }
        public UserInputModel User { get; set; }
        
        
    }

    public class AttentionStaffViewModel: AttentionStaffInputModel
    {
        public AttentionStaffViewModel() {}

        public AttentionStaffViewModel(UserAttentionStaff userAttention) 
        {
            AttentionId = userAttention.UserAttentionStaffId;
            Name = userAttention.Name;
            LastName = userAttention.LastName;
            Type = userAttention.Type;
            Photo = userAttention.Photo;
            ServiceStatus = userAttention.ServiceStatus;
<<<<<<< HEAD
            User = (userAttention.User==null)?null: new UserViewModel(userAttention.User);
=======
            User = new UserInputModel();
            User = (userAttention.User != null) ? new UserViewModel(userAttention.User): null;
>>>>>>> 4e84dfb4d1c25916965b27ded746e7e8230e7b3c
            
        }

    }
}