using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pantry.Data;
using Pantry.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Pantry.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public UsersController(ApplicationDBContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: api/<User>
        [HttpGet]
        [Authorize]
        public async Task<List<IdentityUser>> Get()
        {
            return await _userManager.Users.ToListAsync();
        }

        // GET api/<User>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<User>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<User>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // PUT api/<User>/MyProfile
        [HttpPut]
        [Route("MyProfile")]
        public async Task<IActionResult> Put([FromBody] UserData UserData)
        {
            ClaimsPrincipal User = this.User;
            var currentUser = await _userManager.FindByNameAsync(User.Identity.Name);
            currentUser.Email = UserData.Email;
            currentUser.PhoneNumber = UserData.PhoneNumber;
            await _userManager.UpdateAsync(currentUser);
            _context.SaveChanges();
            return Ok(new
            {
                Message = "User Changes Saved"
            });
        }

        // DELETE api/<User>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
