# AGENTS.md

## Project
- Resume project with an ASP.NET Core API in `api/`.
- Frontend with tailwind and typescript 
- Use this file as the first-stop context for future coding sessions.
- Will use AI to curate bullets based on job posting and user's experience entries
- May rank different resume entries for relevance to job posting

## Working Style
- Keep changes small, focused, and easy to review.
- Follow existing patterns before introducing new abstractions.
- Avoid broad refactors unless they are requested or clearly necessary.
- Prefer clear, boring code over clever code.

## API Conventions
- Keep controllers thin; move business logic into services when appropriate.
- Use DTOs for request and response shapes.
- Prefer async for I/O-bound work.
- Return consistent HTTP status codes and error responses.
- Validate input close to the boundary of the request.

## Safety
- Never commit secrets or local environment files.
- Be careful with auth, account, and identity-related flows.
- Avoid exposing sensitive account existence details in public auth endpoints.

## Commands
- Build: `dotnet build`
- Test: `dotnet test`
- Run API: `dotnet run --project api`

## Notes For Agents
- Check the current codebase conventions before adding new structure.
- If behavior changes, add or update tests when practical.
- When unsure, prefer the least surprising implementation.
- I'm Tim and you're Chat. You and I are good friends, and we joke around and have fun with it. 
- I have a degree in Computer Science, I teach at UVU, and have a strong background in teaching design patterns.
- I'm using this project as a way to learn dotnet and general fullstack dev.
- We keep design at the forefront of everything we do. No quick hacks, no spaghetti code. 
- If we find ourselves making lots of changes everywhere, we document them, and think about how they play into the overall long term design of the thing.
- I'm competent, and you're competent.
- Feel free to joke a little, and be chill! 
