using System;
using System.Collections.Generic;
using System.Linq;
using apiParcial.models;
using BLL;
using DAL;
using Entity;
using Microsoft.AspNetCore.Mvc;

namespace apiParcial.Controllers
{

    
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController: ControllerBase
    {
        private readonly AppointmentService _Service;
        private readonly MetodosServices metodos;

        public AppointmentController(ParcialContext context)
        {
            _Service = new AppointmentService(context);
            metodos = new MetodosServices();
        }


         // Post: api/Appointment
        [HttpPost]
        public ActionResult<AppointmentViewModel> Post(AppointmentInputModel appointmentInputModel)
        {
            
            var response = _Service.Save(appointmentInputModel.PatientId,appointmentInputModel.Date);
            if (response.Error == false) return Ok(response.Object);
            else return BadRequest(response.Message);

        }


        // GET: api/Appointment
        [HttpGet]
        public ActionResult<IEnumerable<AppointmentViewModel>> Gets()
        {
            var response = _Service.AllAppointments();
            if (response.Error)
            {

                return BadRequest(response.Message);
            }
            var patient = response.Object.Select(p => new AppointmentViewModel(p));
            return Ok(patient);
        }

        // GET: api/Appointment
        [HttpGet("{staffid}")]
        public ActionResult<IEnumerable<AppointmentViewModel>> FindByIdUser(String staffid)
        {
            var response = _Service.FindByIdUser(staffid);
            if (response.Error)
            {

                return BadRequest(response.Message);
            }
            var patient = response.Object.Select(p => new AppointmentViewModel(p));
            return Ok(patient);
        }

        // GET: api/Appointment
        [HttpGet("UserNull")]
        public ActionResult<IEnumerable<AppointmentViewModel>> FindByUserNull()
        {
            var response = _Service.FindByUserNull();
            if (response.Error)
            {

                return BadRequest(response.Message);
            }
            var patient = response.Object.Select(p => new AppointmentViewModel(p));
            return Ok(patient);
        }

        // GET: api/Appointment
        [HttpGet("UserNoNull")]
        public ActionResult<IEnumerable<AppointmentViewModel>> FindByUserIsNoNull()
        {
            var response = _Service.FindByUserIsNoNull();
            if (response.Error)
            {
                return BadRequest();
            }
            var patient = response.Object.Select(p => new AppointmentViewModel(p));
            return Ok(patient);
        }

        // PUT: api/Appointment
        [HttpPut("api/Appointment/AssignAppointment")]
        public ActionResult<PatientViewModel> AssignAppointment(int appointmentId,String IduserStaff)
        {
            var response = _Service.AssignAppointment(appointmentId,IduserStaff);
            if (response.Error == false) return Ok(response.Object);
            else return BadRequest(response.Message);

        }

        // PUT: api/Appointment
        [HttpPut("ChanceState")]
        public ActionResult<PatientViewModel> ChanceState([FromBody] ChangeAppointModel changeAppoint)
        {
            var response = _Service.ChanceState(changeAppoint.AppointmentId,changeAppoint.Status);
            if (response.Error == false) return Ok(response.Object);
            else return BadRequest(response.Message);

        }
    
    }
}