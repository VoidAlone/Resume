using System.Security.Claims;
using Resume.Models.ResumeModels;
using Resume.Services;

namespace Resume.Endpoints;

//The UserCrudEndpoints class is responsible for creating a generic
//set of crud operations for the models. This is going to follow the simple 
//api style 
public static class UserCrudEndpoints
{

	public static RouteGroupBuilder MapUserCrudEndpoints<T>(
			this RouteGroupBuilder group)
		where T : UserOwnedEntity
	{
		group.MapGet("/", GetAllAsync<T>);
		return group;
	}

	public static async Task<IResult> GetAllAsync<T>(
			ClaimsPrincipal user,
			ICrudService<T> service,
			CancellationToken cancellationToken)
		where T : UserOwnedEntity
	{
		var userId = user.FindFirstValue(ClaimTypes.NameIdentifier);

		if (userId is null)
			return Results.Unauthorized();

		var entities = await service.GetAllAsync(
				userId,
				cancellationToken
				);

		return Results.Ok(entities);
	}
}
