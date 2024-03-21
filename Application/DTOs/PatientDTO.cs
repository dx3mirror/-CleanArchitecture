using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class PatientDTO
    {
        public int PatientId { get; set; }
        public string Name { get; set; }

        public string Surname { get; set; }

        public DateOnly? DateOfBirth { get; set; }

        public string Gender { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }
    }
}
