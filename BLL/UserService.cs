using System;
using System.Linq;
using DAL;
using Entity;

namespace BLL
{
    public class UserService
    {
        private readonly ParcialContext _context;
        public UserService(ParcialContext context)=> _context = context;

        public Response<User> Login(string userName, string password) {
            try {
                User isUser =
                     _context.Users.FirstOrDefault(t => t.UserId == userName && t.Password == password && t.Status == "Active");

                return (isUser != null) ? new Response<User>(isUser) : new Response<User>("EL usuario NO esta registrado...!");

            } catch(Exception e) {
                return new Response<User>("Error: " + e);
            } 
        }

    }
}