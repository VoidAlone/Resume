using Microsoft.AspNetCore.Mvc;
using Resume.DTOs.Identity;
using Resume.Data;
using Microsoft.EntityFrameworkCore;
using Resume.Mappings.Identity;

namespace Resume.Controllers.Identity;

[Route("api/Profile")]
[ApiController]
public class ProfileController(AppDbContext context) : ControllerBase
{
	private readonly AppDbContext _context = context;

	[HttpGet("{id:int}")]
	public async Task<ActionResult<ReadProfileDto>> Read(int id)
	{
		var db_item = await _context.Profiles.FindAsync(id);

		if (db_item == null)
		{
			return NotFound();
		}

		return Ok(db_item.ToReadDto());
	}

	[HttpPost]
	public async Task<IActionResult> Create(CreateProfileDto request)
	{
		//create new model object from dto
		var model = request.ToModel();

		//add to database
		//save changes
		_context.Profiles.Add(model);
		await _context.SaveChangesAsync();
		//create readdto object and return it with metadata 
		var response = model.ToReadDto();
		return CreatedAtAction(nameof(Read), new { id = model.Id }, response);
	}

	[HttpPut("{id:int}")]
	public async Task<IActionResult> Update(int id, UpdateProfileDto request)
	{
		var model = await _context.Profiles.FindAsync(id);

		if(model == null){
			return NotFound();
		}

		request.ApplyUpdate(model);

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
		var model = await _context.Profiles.FindAsync(id);
		if(model == null){
			return NotFound();
		}
		_context.Remove(model);
		await _context.SaveChangesAsync();
		return NoContent();
	}
}
