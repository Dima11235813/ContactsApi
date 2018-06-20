using CityInfo.API.Entities;
using ContactsApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsApi
{
    public static class ContactExtension
    {
        public static void EnsureSeedDataForContext(this ContactContext context)
        {
            if (context.Contacts.Any())
            {
                //only seed the db if it's empty
                return;
            }

            // init seed data
            var contacts = new List<Contact>()
            {
                new Contact()
                {
                     Name = "Max Power",
                     Birthdate = "01-01-1969",
                     Company = "Power Inc.",
                     Email = "More@Power.com",
                     PersonalPhoneNumber = "1847-555-5555.",
                     ProfileImage  = "https://souldonuts.files.wordpress.com/2011/09/simpsons-max-power-754880.jpg",
                     WorkPhoneNumber  = "1847-123-4567",
                     Address = "123 Fake Street, AnyTown, USA"
                },
                new Contact()
                {
                     Name = "Max Power",
                     Birthdate = "01-01-1969",
                     Company = "Power Inc.",
                     Email = "More@Power.com",
                     PersonalPhoneNumber = "1847-555-5555.",
                     ProfileImage  = "https://souldonuts.files.wordpress.com/2011/09/simpsons-max-power-754880.jpg",
                     WorkPhoneNumber  = "1847-123-4567",
                     Address = "123 Fake Street, AnyTown, USA"
                }
            };

            context.Contacts.AddRange(contacts);
            context.SaveChanges();
        }
    }
}
