using Contactly.Data;
using Contactly.Models;
using Contactly.Models.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Contactly.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly ContactlyDbContext _dbContext;

        public ContactController(ContactlyDbContext context)
        {
            this._dbContext = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var contacts = _dbContext.contacts.ToList();
            return Ok(contacts);
        }

        [HttpPost]
        public IActionResult Create(CreateContactDto createDtoContact)
        {
            var contact = new Contact
            {
                Id = Guid.NewGuid(),
                Name = createDtoContact.Name,
                Email = createDtoContact.Email,
                Phone = createDtoContact.Phone,
                Favorite = createDtoContact.Favorite,
            };

            _dbContext.contacts.Add(contact);
            _dbContext.SaveChanges();

            return Ok(contact);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult Delete([FromRoute] Guid id)
        {
            var contact = _dbContext.contacts.Find(id);

            if(contact is null)
            {
                return NotFound("Contact doesn't exist");
            }
            _dbContext.contacts.Remove(contact);
            _dbContext.SaveChanges();

            return Ok(contact);
        }
    }
}
