using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    interface IPatient
    {
        int PatientId { get; }

        [Required(ErrorMessage = "Name is required")]
        string Name { get; }

        [Required(ErrorMessage = "Surname is required")]
        string Surname { get; }

        DateOnly? DateOfBirth { get; }

        Gender Gender { get; }

        [Required(ErrorMessage = "Address is required")]
        string Address { get; }

        [Required(ErrorMessage = "PhoneNumber is required")]
        [RegularExpression("^7[0-9]{9}$", ErrorMessage = "Phone number must start with '7' and contain 10 digits.")]
        string PhoneNumber { get; }
    }
}
