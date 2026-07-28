using Microsoft.AspNetCore.Mvc;
using Resume.Data;
using Resume.DTOs.Identity;
using Resume.Models.Identity;
using Resume.Mappings.Identity;

namespace Resume.Controllers.Identity;

[Route("api/Profile/Socials")]
[ApiController]
public class SocialController(AppDbContext context) : ControllerBase
{

	private readonly AppDbContext _context = context;

	[HttpGet("{id:int}")]
	public async Task<ActionResult<ReadSocialDto>> Read(int id)
	{
		var social = await _context.Socials.FindAsync(id);

		if (social == null)
		{
			return NotFound();
		}

		return Ok(social.ToReadDto());
	}

	[HttpPost]
	public async Task<IActionResult> Create(CreateSocialDto request)
	{
		var model = request.ToModel();

		_context.Socials.Add(model);

		await _context.SaveChangesAsync();
		var response = model.ToReadDto();
		return CreatedAtAction(nameof(Read), new { id = model.Id }, response);
	}

	[HttpPut("{id:int}")]
	public async Task<IActionResult> Update(int id, UpdateSocialDto request)
	{
		var db_item = await _context.Socials.FindAsync(id);
		if (db_item == null)
		{
			return NotFound();
		}

		request.ApplyUpdate(db_item);

		try
		{
			await _context.SaveChangesAsync();
		}
		catch
		{
			throw;
		}
		return NoContent();
	}

	[HttpDelete("{id:int}")]
	public async Task<IActionResult> Delete(int id)
	{
		var db_item = await _context.Socials.FindAsync(id);
		if (db_item == null)
		{
			return NotFound();
		}

		_context.Socials.Remove(db_item);
		await _context.SaveChangesAsync();
		return NoContent();
	}
}
