using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ContactsApi.Entities;
using ContactsApi.Models;
using ContactsApi.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace ContactsApi.Controllers
{
    [Route("api/contacts")]
    public class ContactsController : Controller
    {
        //inject repo into controller
        private IContactRepository _contactRepository;
        public ContactsController(IContactRepository cityInfoRepository)
        {
            _contactRepository = cityInfoRepository;
        }



        //Retrieve​ ​a​ ​contact​ ​record 
        [HttpGet("{id}", Name = "GetContact")]
        public IActionResult GetContacts(int id)
        {
            // find city
            var contactToReturn = _contactRepository.GetContact(id);
            if (contactToReturn == null)
            {
                return NotFound();
            }
            return Ok(contactToReturn);
        }

        //Create​ ​a​ ​contact​ ​record 
        [HttpPost()]
        public IActionResult CreateContact([FromBody] ContactCreationDto newContact)
        {

            if (newContact == null)
            {
                return BadRequest();
            }
            //ModelState.AddModelError("Description", "The provided description should be different from the name.");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //TODO Implement unique email namd combination


            //map properties to entity framwork to pass to save method of contact repo            
            var finalContact = Mapper.Map<Contact>(newContact);

            //call saving method
            _contactRepository.AddContact(finalContact);

            //verify that data layer persisted new contact
            if (!_contactRepository.Save())
            {
                return StatusCode(500, "A problem happened while handling your request.");
            }

            var contactForDataTransmission = Mapper.Map<Models.ContactsDto>(finalContact);

            return CreatedAtRoute("GetContact", new { id = contactForDataTransmission.Id }, contactForDataTransmission);
        }
        
        //Update​ ​a​ ​contact​ ​record - Put 
        [HttpPut("update/{id}")]
        public IActionResult UpdateContact(int id, [FromBody] ContactUpdateDto newContact)
        {
            if (newContact == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_contactRepository.ContactExists(id))
            {
                return NotFound();
            }

            var contactEntity = _contactRepository.GetContact(id);
            if (contactEntity == null)
            {
                return NotFound();
            }

            Mapper.Map(newContact, contactEntity);

            if (!_contactRepository.Save())
            {
                return StatusCode(500, "A problem happened while handling your request.");
            }

            return NoContent();
        }
        
        //Update​ ​a​ ​contact​ ​record - Patch
        [HttpPatch("update/{id}")]
        public IActionResult PartiallyUpdateContact(int id,
            [FromBody] JsonPatchDocument<ContactUpdateDto> patchDoc)
        {
            //if body object isn't present return bad request
            if (patchDoc == null)
            {
                return BadRequest();
            }
            //if contact not found return not found
            if (!_contactRepository.ContactExists(id))
            {
                return NotFound();
            }
            //get the contact entity by it
            var contactsEntity = _contactRepository.GetContact(id);
            if (contactsEntity == null)
            {
                return NotFound();
            }
            //get the patch object by mappint the entity obj to the data transfer object
            var contactToPatch = Mapper.Map<ContactUpdateDto>(contactsEntity);

            //apply the patch to see if the model stays valid
            patchDoc.ApplyTo(contactToPatch, ModelState);
            
            //model validity check
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //use the contact patch to validate the model
            TryValidateModel(contactToPatch);

            //
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Mapper.Map(contactToPatch, contactsEntity);

            if (!_contactRepository.Save())
            {
                return StatusCode(500, "A problem happened while handling your request.");
            }
            //return no content if patch was successful
            return NoContent();
        }

        //Delete​ ​a​ ​contact​ ​record
        [HttpDelete("delete/{contactId}")]
        public IActionResult DeleteContact(int contactId)
        {
            if (!_contactRepository.ContactExists(contactId))
            {
                return NotFound();
            }

            var contactEntity = _contactRepository.GetContact(contactId);
            
            //check to see if they're attempting to delete a non existent contact
            if (contactEntity == null)
            {
                return NotFound();
            }

            //perf delete
            _contactRepository.DeleteContact(contactEntity);

            //save
            if (!_contactRepository.Save())
            {
                return StatusCode(500, "A problem happened while handling your request.");
            }

            return NoContent();
        }

        //Search​ ​for​ ​a​ ​record​ ​by​ ​email​ ​or​ ​phone​ ​number 
        [HttpGet("searchone/{emailOrPhoneNumber}")]
        public IActionResult emailOrPhoneNumber(string emailOrPhoneNumber, string q)
        {
            if(emailOrPhoneNumber != "email" && emailOrPhoneNumber != "phone")
            {
                return BadRequest();

            }
            var contactToReturn = _contactRepository.GetContactsByEmailOrPhoneNumber(emailOrPhoneNumber, q);
            if (contactToReturn == null)
            {
                return NotFound();
            }
            return Ok(contactToReturn);
        }
        //Retrieve​ ​all​ ​records​ ​from​ ​the​ ​same​ ​state​ ​or​ ​city
        //[HttpGet("search")]
        [HttpGet("searchall/{stateOrCity}")]
        public IActionResult stateOrCity(string stateOrCity, string q)
        {
            if (stateOrCity != "city" && stateOrCity != "state")
            {
                return BadRequest();
            }
            var contactToReturn = _contactRepository.GetContactsByStateOrCity(stateOrCity, q);
            if (contactToReturn == null)
            {
                return NotFound();
            }
            return Ok(contactToReturn);
        }
    }
}