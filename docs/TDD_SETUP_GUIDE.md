# TDD Setup Guide for This Resume Project

This project currently has a single ASP.NET Core app in `api/` and no solution file yet. That is totally fine. In .NET, tests usually live in a separate project that references the app project.

## First: what "thin controller" means

You asked about a "thin client," but in the context of ASP.NET and what we were talking about, the more likely term is **thin controller**.

A thin controller:

- accepts the HTTP request
- validates basic request shape
- calls a service to do the real work
- returns the HTTP response

It does **not** try to hold a bunch of business logic itself.

Roughly this:

```csharp
[HttpPost]
public async Task<IActionResult> Create(CreateAccountDto request)
{
    var result = await _accountService.CreateAsync(request);
    return CreatedAtAction(nameof(Read), new { id = result.Id }, result);
}
```

Instead of this:

```csharp
[HttpPost]
public async Task<IActionResult> Create(CreateAccountDto request)
{
    // lots of validation
    // mapping
    // duplication checks
    // domain rules
    // database logic
    // response shaping
}
```

Why this matters for TDD:

- thin controllers are easier to integration test
- services are easier to unit test
- you get faster feedback and less setup pain

## Recommended test setup for this repo

Use two levels of tests:

1. **Unit tests** for service logic and validation rules
2. **Integration tests** for API endpoints and database behavior

For this project, I recommend:

- `xUnit` for the test framework
- `Microsoft.AspNetCore.Mvc.Testing` for API integration tests
- `Microsoft.NET.Test.Sdk` so `dotnet test` can run the tests
- `FluentAssertions` for cleaner assertions
- `Microsoft.EntityFrameworkCore.Sqlite` for realistic in-memory integration testing

Avoid starting with EF Core's `InMemory` provider for behavior-heavy tests. SQLite in-memory behaves more like a real database.

## Should tests be a separate project?

Yes. In .NET, that is the normal setup.

You currently have:

```text
Resume/
|- api/
|  `- Resume.csproj
`- AGENTS.md
```

Recommended next layout:

```text
Resume/
|- api/
|  |- Controllers/
|  |- Data/
|  |- DTOs/
|  |- Models/
|  `- Resume.csproj
|- tests/
|  `- Resume.Api.Tests/
|     |- Integration/
|     |- Unit/
|     |- TestDoubles/
|     `- Resume.Api.Tests.csproj
|- Resume.sln
|- AGENTS.md
`- TDD_SETUP_GUIDE.md
```

You can also skip the `tests/` folder and put `Resume.Api.Tests/` at the root, but `tests/` keeps things tidy.

## Step-by-step setup

## 1. Create a solution file

From the repo root:

```bash
dotnet new sln -n Resume
```

Why:

- makes multiple projects easier to manage
- gives you one command target for builds and tests
- is the usual shape for a growing .NET repo

## 2. Add the existing API project to the solution

```bash
dotnet sln Resume.sln add api/Resume.csproj
```

## 3. Create the test project

```bash
dotnet new xunit -n Resume.Api.Tests -o tests/Resume.Api.Tests
```

## 4. Add the test project to the solution

```bash
dotnet sln Resume.sln add tests/Resume.Api.Tests/Resume.Api.Tests.csproj
```

## 5. Reference the API project from the test project

```bash
dotnet add tests/Resume.Api.Tests/Resume.Api.Tests.csproj reference api/Resume.csproj
```

This lets the tests access your app types.

## 6. Install the test packages

Run these from the repo root:

```bash
dotnet add tests/Resume.Api.Tests/Resume.Api.Tests.csproj package Microsoft.AspNetCore.Mvc.Testing
dotnet add tests/Resume.Api.Tests/Resume.Api.Tests.csproj package FluentAssertions
dotnet add tests/Resume.Api.Tests/Resume.Api.Tests.csproj package Microsoft.EntityFrameworkCore.Sqlite
```

Notes:

- `xUnit`, `Microsoft.NET.Test.Sdk`, and the xUnit runner usually come with the template
- `Microsoft.AspNetCore.Mvc.Testing` gives you `WebApplicationFactory`
- `FluentAssertions` is optional, but it makes tests much nicer to read
- `Microsoft.EntityFrameworkCore.Sqlite` is useful when your integration tests need a real EF-backed database in memory

## 7. Run the starter tests

```bash
dotnet test Resume.sln
```

You should see the default xUnit sample test pass.

## Suggested project structure inside the test project

```text
tests/Resume.Api.Tests/
|- Integration/
|  |- AccountControllerTests.cs
|  `- CustomWebApplicationFactory.cs
|- Unit/
|  `- AccountServiceTests.cs
|- TestDoubles/
|  `- BuildersOrSeedData.cs
`- Resume.Api.Tests.csproj
```

Suggested purpose:

- `Integration/`: endpoint tests that run the API in memory
- `Unit/`: service and business rule tests
- `TestDoubles/`: reusable test data setup helpers

## First milestone: add one integration test

Start with a tiny, confidence-building test:

- `GET /api/Account/999999` returns `404`

That is a great first TDD win because:

- it is easy to understand
- it tests a real endpoint
- it proves the test project is wired correctly
- it gives you the red/green loop fast

## Example integration test shape

This is not copy-paste ready yet because your app will need a small amount of test host setup, but this is the general pattern:

```csharp
public class AccountControllerTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public AccountControllerTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task Get_missing_account_returns_404()
    {
        var response = await _client.GetAsync("/api/Account/999999");

        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }
}
```

## Important note about `Program`

For `WebApplicationFactory<Program>` to work cleanly, many ASP.NET Core apps need this at the bottom of `api/Program.cs`:

```csharp
public partial class Program { }
```

That small line makes the generated `Program` type easier for the test host to discover.

## Recommended TDD workflow for you

Do not try to TDD every single line. That gets annoying fast.

Instead, use this rhythm:

1. pick one user-visible behavior
2. write one failing test
3. make it pass with the smallest change possible
4. refactor only after green
5. repeat

Good first targets in this repo:

- missing account returns `404`
- creating an account returns `201`
- deleting an account returns `204`
- invalid request returns a client error once you add validation

## When to use unit tests vs integration tests

Use **integration tests** when you want to verify:

- routing
- model binding
- controller behavior
- EF Core interaction
- HTTP status codes and response shapes

Use **unit tests** when you want to verify:

- business rules
- validation rules beyond attribute-level checks
- data transformation or mapping logic
- service behavior independent of HTTP

Rule of thumb:

- controller endpoint contract -> integration test
- non-trivial decision-making logic -> unit test

## A realistic first evolution of the codebase

Right now `api/Controllers/Identity/AccountController.cs` talks directly to `AppDbContext`. That is okay for getting started, but if the logic grows, TDD gets nicer if you move logic into a service.

Example future shape:

```text
api/
|- Controllers/
|- Services/
|  `- AccountService.cs
|- Data/
|- DTOs/
`- Models/
```

Then your test split becomes more natural:

- integration tests for `AccountController`
- unit tests for `AccountService`

## What I would do next if I were you

1. create `Resume.sln`
2. create `tests/Resume.Api.Tests`
3. install the packages listed above
4. make one integration test pass
5. only then add more structure

That keeps the setup small and gets you to green checkmarks quickly.

## Tiny glossary

- **solution**: a top-level `.sln` file that groups multiple .NET projects
- **project**: a `.csproj` file, like your current `api/Resume.csproj`
- **test project**: a separate `.csproj` dedicated to tests
- **integration test**: tests the app working across multiple parts together
- **unit test**: tests one small unit of logic in isolation
- **WebApplicationFactory**: helper for spinning up an ASP.NET Core app in tests

## Short version

Yes, tests should be a separate project.

If you want the easiest path with the best feedback loop, start with:

- `xUnit`
- `Microsoft.AspNetCore.Mvc.Testing`
- `FluentAssertions`
- one integration test for `AccountController`

Then grow into service-level unit tests as your logic gets richer.
