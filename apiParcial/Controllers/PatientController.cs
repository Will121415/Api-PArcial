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

namespace api_movil.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly PatientService _Service;


        public PatientController(ParcialContext _context)
        {
            _Service = new PatientService(_context);
        }


        // Post: api/Patient
        [HttpPost]
        public ActionResult<PatientInputModel> Post(PatientInputModel patientInputModel)
        {
            Patient patient = MapearClient(patientInputModel);
            var response = _Service.Save(patient);
            if (response.Error == false) return Ok(response.Object);
            else return BadRequest(response.Message);

        }

        private Patient MapearClient(PatientInputModel patientInputModel)
        {
            var patient = new Patient
            {
                PatientId = patientInputModel.PatientId,
                Name = patientInputModel.Name,
                LastName = patientInputModel.LastName,
                Photo = patientInputModel.Photo,
                Age = patientInputModel.Age,
                Address = patientInputModel.Address,
                Neighborhood = patientInputModel.Neighborhood,
                Phone = patientInputModel.Phone,
                City = patientInputModel.City,

            };


            return patient;
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
            Patient patient = MapearClient(patientInputModel);
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