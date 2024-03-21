using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class PatientModel : IPatient
    {
        public int PatientId { get; private set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; private set; }

        [Required(ErrorMessage = "Surname is required")]
        public string Surname { get; private set; }

        public DateOnly? DateOfBirth { get; private set; }

        public Gender Gender { get; private set; }

        [Required(ErrorMessage = "Address is required")]
        public string Address { get; private set; }

        private string _phoneNumber;

        [Required(ErrorMessage = "PhoneNumber is required")]
        [RegularExpression("^7[0-9]{9}$", ErrorMessage = "Phone number must start with '7' and contain 10 digits.")]
        public string PhoneNumber
        {
            get => _phoneNumber;
            private set
            {
                if (!string.IsNullOrEmpty(value) && value.StartsWith("7") && value.Length == 10)
                    _phoneNumber = value;
                else
                    throw new ArgumentException("Invalid phone number format.");
            }
        }
        public PatientModel() { }
    }
}
