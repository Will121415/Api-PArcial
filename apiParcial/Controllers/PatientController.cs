using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using BLL;
using DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using apiParcial.models;
using apiParcial.Controllers;

namespace api_movil.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly PatientService _Service;
        private readonly MetodosServices metodos;


        public PatientController(ParcialContext _context)
        {
            _Service = new PatientService(_context);
            metodos = new MetodosServices();
        }


        // Post: api/Patient
        [HttpPost]
        public ActionResult<PatientViewModel> Post(PatientInputModel patientInputModel)
        {
            Patient patient = metodos.MapearPatient(patientInputModel);
            var response = _Service.Save(patient);
            if (response.Error == false) return Ok(response.Object);
            else return BadRequest(response.Message);

        }



        // GET: api/Patient
        [HttpGet]
        public ActionResult<IEnumerable<PatientInputModel>> Gets()
        {
            var response = _Service.AllPatient();
            if (response.Error)
            {

                return BadRequest(response.Message);
            }
            var patient = response.Object.Select(p => new PatientViewModel(p));
            return Ok(patient);
        }

        // PUT: api/Patient/Modify
        [HttpPut]
        public ActionResult<PatientViewModel> Modify(PatientInputModel patientInputModel)
        {
            Patient patient = metodos.MapearPatient(patientInputModel);
            patient.Status= patientInputModel.Status;
            var response = _Service.Update(patient);
            if (response.Error == false) return Ok(response.Object);
            else return BadRequest(response.Message);

        }

        // PUT: api/Patient/Delete
        [HttpDelete("{patientId}")]
        public ActionResult<PatientInputModel> Delete(String patientId)
        {
            var response = _Service.Delete(patientId);
            if (response.Error == false) return Ok(response.Object);
            else return BadRequest(response.Message);

        }






    }
}