using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApi_Local.Data;
using WebApi_Local.Models;

namespace WebApi_Local.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsersController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            try
            {
                var UsersInfo = _context.Users.ToList();
                if (UsersInfo == null)
                {
                    return NotFound();
                }
                return Ok(UsersInfo);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
        [HttpGet("{id:int}")]
        public IActionResult GetUser(int? id)
        {
            try
            {
                var User = _context.Users.Find(id);
                if (User == null)
                {
                    return NotFound();
                }
                return Ok(User);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }

        }

        [HttpPost]
        public IActionResult AddUser(Users user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(user);
                    _context.SaveChangesAsync();
                    return StatusCode(StatusCodes.Status200OK,
                    "Add Successful");

                }
                return Ok(User);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

    }
}
