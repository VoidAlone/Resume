using System.Collections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Resume.DTOs.Identity;
using Resume.Models.Identity;
using Resume.Data;

namespace Resume.Controllers.Identity;

[Route("api/User")]
[ApiController]
public class UserController(AppDbContext context) : ControllerBase{
	private readonly AppDbContext _context = context;

    [HttpGet("{id:int}")]
	public async Task<ActionResult<UserDto>> GetUser(int id){
		var user = await _context.Users.FindAsync(id);

		if(user == null){
			return NotFound();
		}

		return Ok(new UserDto{
			Id = user.Id,
			Name = user.Name
		});
	}
}
