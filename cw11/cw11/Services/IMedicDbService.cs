using cw11.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cw11.Services
{
    public interface IMedicDbService
    {
        public IEnumerable<Doctor> GetDoctors();
        public Doctor GetDoctorById(int doctorId);
        public Doctor AddDoctor(Doctor doctor);
        public Doctor DeleteDoctor(int doctorId);
        public Doctor ModifyDoctor(int doctorId, Doctor doctor);
    }
}
