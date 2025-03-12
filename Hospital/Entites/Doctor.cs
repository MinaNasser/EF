using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Entites
{
    public class Doctor
    {
        public int DoctorID { get; set; }
        public string Name { get; set; }
        public decimal salary { get; set; }
        public string Speciality { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public virtual ICollection<Client> Clients { get; set; }

    }
}
