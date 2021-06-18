using System.Linq;
using System.Collections.Generic;
using BLL;
using DAL;
using Entity;
using Microsoft.AspNetCore.Mvc;
using apiParcial.models;
namespace apiParcial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttentionStaffController: ControllerBase
    {
        private readonly UserAttentionStaffService _staffService;

        public AttentionStaffController(ParcialContext context)
        {
            _staffService = new UserAttentionStaffService(context);
        }

        [HttpPost]
        public ActionResult<AttentionStaffViewModel> Post(AttentionStaffInputModel staffModel)
        {
            UserAttentionStaff attentionStaff = MapAttentionStaff(staffModel);
            var response = _staffService.Save(attentionStaff);

            if (response.Error) return BadRequest(response.Message);
            return Ok(response.Object);

        }

        private UserAttentionStaff MapAttentionStaff(AttentionStaffInputModel staffModel)
        {
            UserAttentionStaff attentionStaff = new UserAttentionStaff();
            
            attentionStaff.UserAttentionStaffId = staffModel.AttentionId;
            attentionStaff.Name = staffModel.Name;
            attentionStaff.LastName = staffModel.LastName;
            attentionStaff.Type = staffModel.Type;
            attentionStaff.Photo = staffModel.Photo;
            attentionStaff.ServiceStatus = staffModel.ServiceStatus;
            attentionStaff.User =  MapUser(staffModel.User);

            return attentionStaff;
        }

        private User MapUser(UserInputModel userInput)
        {
            User user = new User();
            user.UserId = userInput.UserName;
            user.Password = userInput.Password;
            user.Status = userInput.Status;
            user.Role = userInput.Role;

            return user;
        }

        [HttpGet]
        public ActionResult<IEnumerable<AttentionStaffViewModel>> AllUserAttentionStaff()
        {
            var response = _staffService.AllUserAttention();

            if (response.Object == null) return BadRequest(response.Message);

            var attentionStaff = response.Object.Select(uas => new AttentionStaffViewModel(uas));

            return Ok(attentionStaff);

        }

        [HttpPut("{attentionId}")] 
        public ActionResult<AttentionStaffViewModel> Modify(string attentionId)
        {
            var response =  _staffService.ChangeStatus(attentionId);

            if (response.Error) return BadRequest(response.Message);

            return Ok(response.Object);
        }

        [HttpPut]
        public ActionResult<AttentionStaffViewModel> Modify(AttentionStaffInputModel staffModel)
        {
            UserAttentionStaff attentionStaff = MapAttentionStaff(staffModel);

            var response = _staffService.Update(attentionStaff);
            if (response.Error == false) return Ok(response.Object);
            else return BadRequest(response.Message);

        }

        [HttpDelete("{attentionId}")]
        public ActionResult<AttentionStaffViewModel> Delete(string attentionId)
        {
            var response =  _staffService.Delete(attentionId);

            if (response.Object == null) return BadRequest(response.Message);

            return Ok(response.Object);
        }
        
    }
}