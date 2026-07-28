using Microsoft.AspNetCore.Mvc;
using Resume.DTOs.Identity;
using Resume.Models.Identity;
using Resume.Data;
using Resume.Mappings.Identity;

namespace Resume.Controllers.Identity;

[Route("api/account")]
[ApiController]
public class AccountController(AppDbContext context) : ControllerBase
{
	private readonly AppDbContext _context = context;

	[HttpGet("{id}")]
	public async Task<ActionResult<ReadAccountDto>> Read(string id)
	{
		var account = await _context.Accounts.FindAsync(id);

		if (account == null)
		{
			return NotFound();
		}

		return Ok(account.ToReadDto());
	}

	[HttpPost]
	public async Task<ActionResult<ReadAccountDto>> Create(CreateAccountDto accountRequest)
	{
		var model = accountRequest.ToModel();

		_context.Accounts.Add(model);
		await _context.SaveChangesAsync();

		var response = model.ToReadDto();
		return CreatedAtAction(nameof(Read), new { id = response.Id }, response);
	}

	[HttpPut("{id}")]
	public async Task<IActionResult> Update(string id, UpdateAccountDto accountRequest)
	{
		var account = await _context.Accounts.FindAsync(id);
		if (account == null)
		{
			return NotFound();
		}

		accountRequest.ApplyUpdate(account);
		await _context.SaveChangesAsync();

		return NoContent();
	}

	[HttpDelete("{id}")]
	public async Task<IActionResult> Delete(string id)
	{
		var account = await _context.Accounts.FindAsync(id);

		if (account == null)
		{
			return NotFound();
		}

		_context.Accounts.Remove(account);
		await _context.SaveChangesAsync();
		return NoContent();
	}

}
