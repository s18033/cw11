using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cw11.Models;
using cw11.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace cw11.Controllers
{
    [ApiController]
    [Route("api/medic")]
    public class MedicController : ControllerBase
    {
        public IMedicDbService _service;

        public MedicController(IMedicDbService service)
        {
            _service = service;
        }

        [HttpGet("{id:int}")]
        public IActionResult GetDoctorById(int id)
        {
            var data = _service.GetDoctorById(id);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        [HttpGet]
        public IActionResult GetDoctors()
        {
            var data = _service.GetDoctors();
            return Ok(data);
        }
        [HttpPost]
        public IActionResult AddDoctor(Doctor doctor)
        {
            var data = _service.AddDoctor(doctor);
            return Ok(data);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDoctor(int id)
        {
            var data = _service.DeleteDoctor(id);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        [HttpPut("{id}")]
        public IActionResult ModifyDoctor(int id, Doctor doc)
        {
            var data = _service.ModifyDoctor(id, doc);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }
    }
}