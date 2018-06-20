using ContactsApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsApi.Services
{
    public interface IContactRepository
    {

        bool ContactExists(int contactId);
        //Get contacts by city or state
        IEnumerable<Contact> GetContactsByStateOrCity(string cityOrState, string query);
        //Get single contact by email or phone
        Contact GetContactsByEmailOrPhoneNumber(string emailOrPhone, string query);
        //Get single contact
        Contact GetContact(int contactId);
        //Get all contacts
        List<Contact> GetAllContacts();
        //create 1 contact
        void AddContact(Contact contact);
        //remove l contact
        void DeleteContact(Contact contact);
        //update contact
        bool Save();
    }
}
