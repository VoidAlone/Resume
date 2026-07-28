using Microsoft.AspNetCore.Mvc;
using Resume.DTOs.Identity;
using Resume.Models.Identity;
using Resume.Data;
using Resume.Mappings.Identity;

namespace Resume.Controllers.Identity;

[Route("api/contact")]
[ApiController]
public class ContractController(AppDbContext context) : ControllerBase
{
	private readonly AppDbContext _context = context;

	[HttpGet("{id}")]
	public async Task<ActionResult<ReadContactDto>> Read(string id){
		return NoContent();
	}

	[HttpPost]
	public async Task<ActionResult<ReadContactDto>> Create(CreateContactDto contactRequest){

		return NoContent();
	}

	[HttpPut("{id}")]
	public async Task<ActionResult<ReadContactDto>> Update(string id, UpdateContactDto contactRequest){

		return NoContent();
	}

	private static ReadContactDto MapToReadDto(Contact contact){
		return new ReadContactDto();
	}
}
