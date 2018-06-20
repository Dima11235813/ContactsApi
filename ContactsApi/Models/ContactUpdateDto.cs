using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsApi.Models
{
    public class ContactUpdateDto
    {
        [Required(ErrorMessage = "You should provide a name value.")]
        [MaxLength(70)]//https://stackoverflow.com/questions/30485/what-is-a-reasonable-length-limit-on-person-name-fields#30509
        public string Name { get; set; }

        [MaxLength(70)]
        public string Company { get; set; }

        public string ProfileImage { get; set; }

        [Required(ErrorMessage = "You must provide a valid email.")]

        public string Email { get; set; }

        public string Birthdate { get; set; }

        public string PersonalPhoneNumber { get; set; }

        [Required(ErrorMessage = "You must provide a work number.")]
        public string WorkPhoneNumber { get; set; }

        public string Address { get; set; }

    }
}
