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
            User = new UserInputModel();
            User =  new UserViewModel(userAttention.User);
            
        }

    }
}