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
	public async Task<ActionResult<ReadUserDto>> Read(int id)
	{
		var user = await _context.Users.FindAsync(id);

		if(user == null)
		{
			return NotFound();
		}

		return Ok(new ReadUserDto
		{
			Id = user.Id,
			Name = user.Name
		});
	}

	[HttpPost]
	public async Task<IActionResult> Create(CreateUserDto UserRequest)
	{
		var user = new User
		{
			Name = UserRequest.Name,
		};

		_context.Users.Add(user);
		await _context.SaveChangesAsync();

		var response = new ReadUserDto{
			Id = user.Id,
			Name = user.Name
		};
		return CreatedAtAction(nameof(Read), new { id = response.Id }, UserRequest);
	}

	[HttpPut("{id:int}")]
	public async Task<IActionResult> Update(int id, UpdateUserDto UserRequest)
	{
		var user = await _context.Users.FindAsync(id);
		if (user == null)
		{
			return NotFound();
		}

		user.Name = UserRequest.Name;

		try
		{
			await _context.SaveChangesAsync();
		}
		catch(DbUpdateConcurrencyException)
		{
			throw;
		}
		
		return NoContent();		
	}

	[HttpDelete("{id:int}")]
	public async Task<IActionResult> Delete(int id)
	{
		var user = await _context.Users.FindAsync(id);

		if(user == null)
		{
			return NotFound();
		}

		_context.Users.Remove(user);
		await _context.SaveChangesAsync();
		return NoContent();
	}
}
