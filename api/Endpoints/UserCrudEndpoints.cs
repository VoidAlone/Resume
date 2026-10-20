using System.Security.Claims;
using Resume.Models.ResumeModels;
using Resume.Services;

namespace Resume.Endpoints;

//The UserCrudEndpoints class is responsible for creating a generic
//set of crud operations for the models. This is going to follow the minimal
//api style
public static class UserCrudEndpoints
{
	public static IEndpointRouteBuilder MapUserCrudRoutes(
			this IEndpointRouteBuilder app)
	{
		app.MapGroup("/api/certificates")
			.MapUserCrudEndpoints<Certificate>();

		app.MapGroup("/api/contacts")
			.MapUserCrudEndpoints<Contact>();

		app.MapGroup("/api/courses")
			.MapUserCrudEndpoints<Course>();

		app.MapGroup("/api/education")
			.MapUserCrudEndpoints<Education>();

		app.MapGroup("/api/experiences")
			.MapUserCrudEndpoints<Experience>();

		app.MapGroup("/api/profiles")
			.MapUserCrudEndpoints<Profile>();

		app.MapGroup("/api/projects")
			.MapUserCrudEndpoints<Project>();

		app.MapGroup("/api/skills")
			.MapUserCrudEndpoints<Skill>();

		app.MapGroup("/api/socials")
			.MapUserCrudEndpoints<Social>();

		return app;
	}

	public static RouteGroupBuilder MapUserCrudEndpoints<T>(
			this RouteGroupBuilder group)
		where T : UserOwnedEntity
	{
		group.MapGet("/", GetAllAsync<T>);
		group.MapGet("/{id:int}", GetByIdAsync<T>)
			.WithName(GetByIdRouteName<T>());
		group.MapPost("/", CreateAsync<T>);
		group.MapPut("/{id:int}", UpdateAsync<T>);
		group.MapDelete("/{id:int}", DeleteAsync<T>);

		return group.RequireAuthorization();
	}

	// Each entity is registered once, so its type gives the GET route a unique name.
	private static string GetByIdRouteName<T>() => $"{typeof(T).Name}.GetById";

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

	public static async Task<IResult> GetByIdAsync<T>(
			int id,
			ClaimsPrincipal user,
			ICrudService<T> service,
			CancellationToken cancellationToken
			)
		where T : UserOwnedEntity
	{
		var userId = user.FindFirstValue(ClaimTypes.NameIdentifier);

		if (userId is null)
			return Results.Unauthorized();

		var entity = await service.GetByIdAsync(
				id,
				userId,
				cancellationToken
				);

		return entity is null
			? Results.NotFound()
		   	: Results.Ok(entity);
	}

	public static async Task<IResult> CreateAsync<T>(
			T entity,
			ClaimsPrincipal user,
			ICrudService<T> service,
			CancellationToken cancellationToken
			) where T : UserOwnedEntity
	{
		var userId = user.FindFirstValue(ClaimTypes.NameIdentifier);

		if (userId is null)
			return Results.Unauthorized();

		var created = await service.CreateAsync(entity, userId, cancellationToken);

		return Results.CreatedAtRoute(
			routeName: GetByIdRouteName<T>(),
			routeValues: new { id = created.Id },
			value: created);
	}

	public static async Task<IResult> UpdateAsync<T>(
			int id,
			T entity,
			ClaimsPrincipal user,
			ICrudService<T> service,
			CancellationToken cancellationToken
			) where T : UserOwnedEntity
	{
		var userId = user.FindFirstValue(ClaimTypes.NameIdentifier);

		if (userId is null)
			return Results.Unauthorized();

		var updated = await service.UpdateAsync(
				id,
				entity,
				userId,
				cancellationToken);

		return updated is null
			? Results.NotFound()
			: Results.Ok(updated);
	}

	public static async Task<IResult> DeleteAsync<T>(
			int id,
			ClaimsPrincipal user,
			ICrudService<T> service,
			CancellationToken cancellationToken
			) where T : UserOwnedEntity
	{
		var userId = user.FindFirstValue(ClaimTypes.NameIdentifier);
		if (userId is null)
			return Results.Unauthorized();

		var deleted = await service.DeleteAsync(id, userId, cancellationToken);

		return deleted
			? Results.NoContent()
			: Results.NotFound();
	}
}
