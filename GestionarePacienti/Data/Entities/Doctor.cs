using GestionarePacienti.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestionarePacienti.Data.Entities
{
    public class Doctor : BaseClass
    {

        [Required(ErrorMessage = "This is a required field")]
        [RegularExpression("^[a-zA-Z ]+$")]
        [MaxLength(150, ErrorMessage = "The field must be under 150 characters!")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "This is a required field")]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        public Specialization Specialization { get; set; }

        public List<AppointmentDetails> Appointments { get; set; }
    }
}
