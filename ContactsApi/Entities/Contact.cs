using ContactsApi.Models.Address;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContactsApi.Entities
{
    public class Contact
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(70)]//https://stackoverflow.com/questions/30485/what-is-a-reasonable-length-limit-on-person-name-fields#30509
        public string Name { get; set; }

        [MaxLength(70)]
        public string Company { get; set; }

        public string ProfileImage { get; set; }

        [Required]
        public string Email { get; set; }

        public string Birthdate { get; set; }

        public string PersonalPhoneNumber { get; set; }

        [Required]
        public string WorkPhoneNumber { get; set; }

        public string Address { get; set; }
    }
}