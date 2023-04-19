using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fixxo_Web_Api.Filters;
using Fixxo_Web_Api.Models.DTO;
using Fixxo_Web_Api.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fixxo_Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [UseApiKey]
    public class ContactsController : ControllerBase
    {
        private readonly ContactRepository _contactRepo;

        public ContactsController(ContactRepository contactRepo)
        {
            _contactRepo = contactRepo;
        }

        [HttpPost]
        public async Task<IActionResult> Create(ContactModel model)
        {
            if (ModelState.IsValid)
            {
                return Created("", await _contactRepo.CreateAsync(model));
            }

            return BadRequest();
        }
    }
}
