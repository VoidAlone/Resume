using Microsoft.AspNetCore.Mvc;
using Resume.DTOs.Identity;
using Resume.Data;

namespace Resume.Controllers.Identity;

[Route("api/Profile")]
[ApiController]
public class ProfileController(AppDbContext context) : ControllerBase {
	private readonly AppDbContext _context = context;

	public async Task<ActionResult<ReadProfileDto>> Read(){}
	public async Task<IActionResult> Create(){}
	public async Task<IActionResult> Update(){}
	public async Task<IActionResult> Delete(){}
}
