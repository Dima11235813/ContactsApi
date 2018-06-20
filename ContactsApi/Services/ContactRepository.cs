using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityInfo.API.Entities;
using ContactsApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace ContactsApi.Services
{
    public class ContactRepository : IContactRepository
    {
        private ContactContext _context;

        public ContactRepository(ContactContext context)
        {
            _context = context;
        }

        public void AddContact(Contact contact)
        {
            _context.Contacts.Add(contact);
        }

        public bool ContactExists(int contactId)
        {
            return _context.Contacts.Any(c => c.Id == contactId);
        }


        public void DeleteContact(Contact contact)
        {
            _context.Contacts.Remove(contact);
        }

        public Contact GetContact(int contactId)
        {
            return _context.Contacts.Where(c => c.Id == contactId).FirstOrDefault();
        }

        public Contact GetContactsByEmailOrPhoneNumber(string emailOrPhoneNumber, string query)
        {
            if (emailOrPhoneNumber == "email")
            {
                return _context.Contacts
               .Where(c => c.Email == query).FirstOrDefault();
            }
            else if (emailOrPhoneNumber == "phone")
            {
                return _context.Contacts
               .Where(
               c => c.WorkPhoneNumber.Contains(query) ||
               c.PersonalPhoneNumber.Contains(query)
               ).FirstOrDefault();
            }
            return null;
        }

        public IEnumerable<Contact> GetContactsByStateOrCity(string cityOrState, string query)
        {
                return _context.Contacts.Where(c => c.Address.Contains(query)).ToList();
         }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
