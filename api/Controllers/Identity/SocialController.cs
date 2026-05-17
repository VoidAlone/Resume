using Microsoft.AspNetCore.Mvc;
using Resume.Data;
using Resume.DTOs.Identity;
using Resume.Models.Identity;

namespace Resume.Controllers.Identity;

[Route("api/Profile/Socials")]
[ApiController]
public class SocialController(AppDbContext context) : ControllerBase
{

	private readonly AppDbContext _context = context;

	[HttpGet]
	public async Task<ActionResult<ReadSocialDto>> Read(string id)
	{
		var social = await _context.Socials.FindAsync(id);

		if (social == null)
		{
			return NotFound();
		}

		return Ok(new ReadSocialDto
		{
			Id = social.Id,
			Name = social.Name,
			Display = social.Display,
			Url = social.Url
		});
	}

	[HttpPost]
	public async Task<IActionResult> Create(CreateSocialDto request)
	{
		var model = new Social{
			Name = request.Name,
			Display = request.Display,
			Url = request.Url,
		};

		_context.Socials.Add(model);

		await _context.SaveChangesAsync();
		var response = new CreateSocialDto{
			Name = request.Name,
			Display = request.Display,
			Url = request.Url,
		};
		return CreatedAtAction(nameof(Read), new {id = model.Id}, response);
	}

	[HttpPut("{id:int}")]
	public async Task<IActionResult> Update(int id, UpdateSocialDto request)
	{
		var db_item = await _context.Socials.FindAsync(id);
		if(db_item == null){
			return NotFound();
		}

		db_item.Name = request.Name;
		db_item.Display = request.Display;
		db_item.Url = request.Url;

		try{
			await _context.SaveChangesAsync();
		}
		catch{
			throw;
		}
		return NoContent();
	}

	[HttpDelete("{id:int}")]
	public async Task<IActionResult> Delete(int id)
	{
		var db_item = await _context.Socials.FindAsync(id);
		if(db_item == null){
			return NotFound();
		}

		_context.Socials.Remove(db_item);
		await _context.SaveChangesAsync();
		return NoContent();
	}
}
