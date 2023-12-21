﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StackOverflowWebApi.Models;

namespace StackOverflowWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(AppDbContext context) : ControllerBase
    {
        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await context.Users.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(Guid id)
        {
            var user = await context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // GET: api/Users/byName/username
        [HttpGet("byName/{username}")]
        public async Task<ActionResult<User>> GetUser(string username)
        {
            var user = await context.Users.FirstOrDefaultAsync(x => x.Email == username);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpGet("getId/{username}")]
        public async Task<ActionResult<Guid?>> GetId(string username)
        {
            var user = await context.Users.FirstOrDefaultAsync(x => x.Email == username);

            return user?.Id;
        }


        // PUT: api/Users/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(Guid id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            //password changed
            var prevPassword = context.Users.FirstOrDefault(u => u.Id == id)?.PasswordHash;
            if (user.PasswordHash != prevPassword)
            {
                user.PasswordHash = AuthController.HashPassword(user.PasswordHash);
            }

            //_context.Entry(user).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Users
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            if (context.Users.Any(u=> u.Email == user.Email))
            {
                return Forbid();
            }

            user.PasswordHash = AuthController.HashPassword(user.PasswordHash);
            context.Users.Add(user);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(Guid id)
        {
            var user = await context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            context.Users.Remove(user);
            await context.SaveChangesAsync();

            return user;
        }

        private bool UserExists(Guid id)
        {
            return context.Users.Any(e => e.Id == id);
        }
    }
}
