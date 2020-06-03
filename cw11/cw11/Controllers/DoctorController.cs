using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cw11.DTOs.Request;
using cw11.Models;
using Microsoft.AspNetCore.Mvc;

namespace cw11.Controllers
{   
    [Route("api/doctor")]
    [ApiController]
    public class DoctorController : Controller
    {

        private readonly DoctorDbContext _context;

        public DoctorController(DoctorDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetDoctor()
        {
            List<Doctor> doctors = new List<Doctor>();

            var _doctorList = (from _context in _context.Doctor
                               select _context).ToList();
            return Ok(doctors);
        }

        [HttpGet("id")]
        public IActionResult GetDoctor(int id)
        {
            var _doctor = from _context in _context.Doctor
                          where _context.IdDoctor == id
                          select _context;

            return Ok(_doctor);
        }

        [HttpPut]
        public IActionResult AddDoctor(DoctorRequest request)
        {
            var doctor = new Doctor();
            var _idDoctor = (from _context in _context.Doctor
                             select _context).Count();
            doctor.IdDoctor = _idDoctor + 1;
            doctor.FirstName = request.FirstName;
            doctor.LastName = request.LastName;
            doctor.Email = request.Email;

            return Ok(doctor);
        }

        [HttpPut("update")]
        public IActionResult UpdateDoctor(DoctorRequest request)
        {
            var db = new DoctorDbContext();

            var d1 = new Doctor
            {
                IdDoctor = request.IdDoctor,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email
            };

            db.Attach(d1);
            db.SaveChanges();

           return Ok(d1);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDoctor(int id)
        {
            var db = new DoctorDbContext();

            var d1 = new Doctor()
            {
                IdDoctor = id
            };

            db.Attach(d1);
            db.Remove(d1);

            db.SaveChanges();

            return Ok(d1);
        }
    }
}