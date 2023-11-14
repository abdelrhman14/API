using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi_Local.Data;
using WebApi_Local.Models;

namespace WebApi_Local.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignUsersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SignUsersController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            try
            {
                var UsersInfo = _context.Sign_Users.ToList();
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
                var kk = (from fac in _context.Sign_Users
                          where fac.UsersId == id
                          select fac).ToList();

                if (kk == null)
                {
                    return NotFound();
                }
                return Ok(kk);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }

        }


        [HttpPost]
        public IActionResult AddUser(Sign_Users sign_user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(sign_user);
                    _context.SaveChangesAsync();
                    return StatusCode(StatusCodes.Status200OK,
                    "Add Successful");

                }
                return Ok(sign_user);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

    }
}
