using System;

/// <summary>
/// Summary description for Class1
/// </summary>
namespace  ContactsApi.Models
{
    public class ContactsDto
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public string ProfileImage { get; set; }
        public string Email { get; set; }
        public string Birthdate { get; set; }
        public string PersonalPhoneNumber { get; set; }
        public string WorkPhoneNumber { get; set; }
        public string Address { get; set; }

    }
}
