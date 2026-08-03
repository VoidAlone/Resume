using Microsoft.AspNetCore.Mvc;
using Resume.DTOs.Identity;
using Resume.Data;
using Microsoft.EntityFrameworkCore;

namespace Resume.Controllers.Identity;

[Route("api/Profile")]
[ApiController]
public class ProfileController(AppDbContext context) : ControllerBase
{
	private readonly AppDbContext _context = context;

	[HttpGet]
	public async Task<ActionResult<ReadProfileDto>> Read(string id)
	{
		var db_item = await _context.Profiles.FindAsync(id);

		if (db_item == null)
		{
			return NotFound();
		}

		return Ok(new ReadProfileDto
		{
			Id = db_item.Id,
			Name = db_item.Name,
		});
	}

	[HttpPost]
	public async Task<IActionResult> Create(CreateProfileDto request)
	{
		//create new model object from dto
		var model = new Models.Identity.Profile
		{
			Name = request.Name,
		};

		//add to database
		//save changes
		_context.Profiles.Add(model);
		await _context.SaveChangesAsync();
		//create readdto object and return it with metadata 
		var response = new CreateProfileDto
		{
			Name = request.Name,
		};
		return CreatedAtAction(nameof(Read), new { id = model.Id }, response);
	}

	[HttpPut("{id:int}")]
	public async Task<IActionResult> Update(int id, UpdateProfileDto request)
	{
		var model = await _context.Profiles.FindAsync(id);

		if(model == null){
			return NotFound();
		}

		model.Name = request.Name;

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
	public async Task<IActionResult> Delete()
	{
		return NoContent();
	}
}
