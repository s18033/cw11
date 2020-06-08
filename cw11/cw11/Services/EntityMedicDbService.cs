using cw11.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cw11.Services
{
    public class EntityMedicDbService : IMedicDbService
    {

        private MedicDbContext MedicDbContext;
        public EntityMedicDbService(MedicDbContext medcont)
        {
            MedicDbContext = medcont;
        }
        public Doctor AddDoctor(Doctor doctor)
        {

            var newDoctor = new Doctor
            {
                FirstName = doctor.FirstName, 
                LastName = doctor.LastName,
                Email = doctor.Email
            };
            MedicDbContext.Add(newDoctor);
            MedicDbContext.SaveChanges();
            return newDoctor;
        }

        public Doctor DeleteDoctor(int doctorId)
        {
            var doctor = MedicDbContext.Doctors.FirstOrDefault(d => d.IdDoctor == doctorId);
            if (doctor == null)
            {
                return null;
            }
            MedicDbContext.Doctors.Remove(doctor);
            MedicDbContext.SaveChanges();
            return doctor;
        }

        public IEnumerable<Doctor> GetDoctors()
        {
            return MedicDbContext.Doctors.ToList();
        }

        public Doctor GetDoctorById(int id)
        {
            return MedicDbContext.Doctors.FirstOrDefault(d => d.IdDoctor == id);
        }

        public Doctor ModifyDoctor(int id, Doctor doctor)
        {
            var modifiedDoctor = MedicDbContext.Doctors.FirstOrDefault(d => d.IdDoctor == id);
            if (doctor == null)
            {
                return null;
            }
            modifiedDoctor.LastName = doctor.LastName;
            modifiedDoctor.FirstName = doctor.FirstName;
            modifiedDoctor.Email = doctor.Email;
            MedicDbContext.SaveChanges(); 
            return modifiedDoctor;
        }
    }
}
