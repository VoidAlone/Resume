using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Resume.DTOs.Identity;
using Resume.Models.Identity;
using Resume.Data;

namespace Resume.Controllers.Identity;

[Route("api/Account")]
[ApiController]
public class AccountController(AppDbContext context) : ControllerBase{
	private readonly AppDbContext _context = context;

    [HttpGet]
	public async Task<ActionResult<ReadAccountDto>> Read(string id)
	{
		var account = await _context.Accounts.FindAsync(id);

		if(account == null)
		{
			return NotFound();
		}

		return Ok(new ReadAccountDto
		{
			Id = account.Id,
			UserName = account.UserName,
			Email = account.Email
		});
	}

	[HttpPost]
	public async Task<IActionResult> Create(CreateAccountDto AccountRequest)
	{
		var account = new Account
		{
			UserName = AccountRequest.UserName,
		};

		_context.Accounts.Add(account);
		await _context.SaveChangesAsync();

		var response = new ReadAccountDto{
			Id = account.Id,
			UserName = account.UserName
		};
		return CreatedAtAction(nameof(Read), new { id = response.Id }, AccountRequest);
	}

	[HttpPut("{id:int}")]
	public async Task<IActionResult> Update(int id, UpdateAccountDto AccountRequest)
	{
		var account = await _context.Accounts.FindAsync(id);
		if (account == null)
		{
			return NotFound();
		}

		account.UserName= AccountRequest.UserName;

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
		var account = await _context.Accounts.FindAsync(id);

		if(account == null)
		{
			return NotFound();
		}

		_context.Accounts.Remove(account);
		await _context.SaveChangesAsync();
		return NoContent();
	}
}
