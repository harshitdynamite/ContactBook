using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactsWebApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContactsWebApplication.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ContactController : ControllerBase
    {
        public IContactRepo Contacts { get; set; }
        public ContactController(IContactRepo contacts)
        {
            Contacts = contacts;
        }

        [HttpGet("{id}", Name = "GetContact")]
        public IActionResult GetById(string id)
        {
            var item = Contacts.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpGet]
        public IEnumerable<Contact> GetAll()
        {
            return Contacts.GetAll();
        }

        [HttpPost]
        public IActionResult Create([FromBody] Contact contact)
        {
            if (contact == null)
            {
                return BadRequest();
            }
            Contacts.Add(contact);
            return CreatedAtRoute("GetContact", new { id = contact.Key }, contact);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] Contact contact)
        {
            if (contact == null || contact.Key != id)
            {
                return BadRequest();
            }
            var item = Contacts.Find(id);  
            if (item == null)
            {
                return NotFound();
            }
            Contacts.Update(contact);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            Contacts.Remove(id);
        }

    }
}
