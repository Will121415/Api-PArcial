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

        public Response<UserAttentionStaff> Delete(string attentionId)
        {
            try
            {
                 var attentionSearch = _context.UserAttentionStaffs.Include(u => u.User)
                                                .Where(uas => uas.AttentionId == attentionId).FirstOrDefault();
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