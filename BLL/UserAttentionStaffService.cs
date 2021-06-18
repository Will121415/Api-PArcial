using System;
using System.Linq;
using DAL;
using Entity;
using Microsoft.EntityFrameworkCore;
namespace BLL
{
    public class UserAttentionStaffService
    {
        private readonly ParcialContext _context;
        public UserAttentionStaffService(ParcialContext context)
          => _context = context;

        public Response<UserAttentionStaff> Save(UserAttentionStaff attentionStaff) 
        {   
            try
            {
                _context.UserAttentionStaffs.Add(attentionStaff);
                _context.SaveChanges();
                return new Response<UserAttentionStaff>(attentionStaff);

            } catch (Exception e)
            {
                return new Response<UserAttentionStaff>($"Error del aplicacion: {e.Message}");
            }
        }

        public ResponseList<UserAttentionStaff> AllUserAttention()
        {  
            try
            {
                var attentions = _context.UserAttentionStaffs.Include(u => u.User).ToList();
                return new ResponseList<UserAttentionStaff>(attentions);
            } catch (Exception e ) 
            {
                return new ResponseList<UserAttentionStaff>($"Error del aplicacion: {e.Message}");
            }
        }

        public Response<UserAttentionStaff> ChangeStatus(string attentionId)
        {
            try
            {
                var oldAttentionStaff =  _context.UserAttentionStaffs.Find(attentionId);
                if (oldAttentionStaff != null) {
                    string status = oldAttentionStaff.ServiceStatus;

                    oldAttentionStaff.ServiceStatus = (status == "available") ? "occupied": "available";
                    _context.UserAttentionStaffs.Update(oldAttentionStaff);
                    _context.SaveChanges(); 
                }
                return new Response<UserAttentionStaff>(oldAttentionStaff);

            } catch (Exception e) {
                return new Response<UserAttentionStaff>($"Error del aplicacion: {e.Message}");
            }
        }

        public Response<UserAttentionStaff> Update(UserAttentionStaff staff)
        {
            try
            {
                var oldStaff = _context.UserAttentionStaffs.Find(staff.UserAttentionStaffId);
                if (oldStaff == null) return new Response<UserAttentionStaff>("El personal de atencion no se encuentra registrado");

                oldStaff.UserAttentionStaffId = (staff.UserAttentionStaffId == oldStaff.UserAttentionStaffId) ? oldStaff.UserAttentionStaffId : staff.UserAttentionStaffId;
                oldStaff.Name = (staff.Name == oldStaff.Name) ? oldStaff.Name : staff.Name;
                oldStaff.LastName = (staff.LastName == oldStaff.LastName) ? oldStaff.LastName: staff.LastName;
                oldStaff.Photo = (oldStaff.Photo == staff.Photo) ? oldStaff.Photo : staff.Photo;
                oldStaff.Type = (oldStaff.Type == staff.Type) ? oldStaff.Type : staff.Type;
                oldStaff.ServiceStatus = (oldStaff.ServiceStatus == staff.ServiceStatus) ? oldStaff.ServiceStatus : staff.ServiceStatus;

                var oldUser = staff.User;
                oldUser.UserId = (oldUser.UserId == staff.User.UserId) ? oldUser.UserId : staff.User.UserId;
                oldUser.Role = (oldUser.Role == staff.User.Role) ? oldUser.Role : staff.User.Role;
                oldUser.Password = (oldUser.Password == staff.User.Password) ? oldUser.Password  : staff.User.Password;
                oldUser.Status = (oldUser.Status == staff.User.Status) ? oldUser.Status : staff.User.Status;

                _context.UserAttentionStaffs.Update(oldStaff);
                _context.Users.Update(oldUser);
                _context.SaveChanges();
                return new Response<UserAttentionStaff>(oldStaff);

            }
            catch (Exception e )
            {
                return new Response<UserAttentionStaff>("Error: " + e);
            }
        }

        public Response<UserAttentionStaff> Delete(string attentionId)
        {
            try
            {
                 var attentionSearch = _context.UserAttentionStaffs.Include(u => u.User)
                                                .Where(uas => uas.UserAttentionStaffId == attentionId).FirstOrDefault();
                // var attentionSearch = _context.UserAttentionStaffs.Find(attentionId);
                if (attentionSearch != null) {
                    _context.UserAttentionStaffs.Remove(attentionSearch);
                    _context.Users.Remove(attentionSearch.User);
                    _context.SaveChanges();
                }
                return new Response<UserAttentionStaff>(attentionSearch);

            } catch (Exception e) 
            {
                return new Response<UserAttentionStaff>($"Error del aplicacion: {e.Message}");
            }
        }
        


        
        
    }
}