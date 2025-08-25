# GitHub Copilot Instructions

## Project Overview

This is an educational ASP.NET Core project demonstrating the three Options interfaces: `IOptions<T>`, `IOptionsSnapshot<T>`, and `IOptionsMonitor<T>`. The core purpose is to showcase behavioral differences between these interfaces when configuration changes occur at runtime.

## Architecture & Key Patterns

### Options Pattern Implementation
- **Configuration Model**: `PositionOptions.cs` with const string for section name
- **Registration**: Use `builder.Services.Configure<PositionOptions>(builder.Configuration.GetSection(PositionOptions.Position))`
- **Endpoints**: Three minimal API endpoints demonstrating each interface behavior

### Critical Behavioral Differences
When working with endpoints in `Program.cs`:

- `/option` (IOptions): Uses `.Value` property - singleton, never reloads
- `/option-snapshot` (IOptionsSnapshot): Uses `.Value` property - scoped, reloads per request
- `/option-monitor` (IOptionsMonitor): Uses `.CurrentValue` property - singleton with change notifications

### Configuration Structure
The `appsettings.json` follows this specific pattern:
```json
{
  "Position": {
    "Title": "Engineer",
    "Name": "Fatih KUCUKKARA"
  }
}
```

## Development Workflows

### Testing Configuration Changes
1. Run `dotnet run` from project root (not solution root)
2. Use `OptionPatterns.http` file for testing - contains pre-configured requests
3. Modify `appsettings.json` while app is running to observe reload behavior
4. Application runs on `http://localhost:5132` (configured in `launchSettings.json`)

### Project Structure Convention
- Main project in `OptionPatterns/` subdirectory
- HTTP test file uses `@OptionPatterns_HostAddress` variable
- Solution includes global.json, LICENSE, and README.md as solution items

## Code Conventions

### Options Classes
- Use `const string` for configuration section names (see `PositionOptions.Position`)
- Properties should have `String.Empty` defaults, not null
- Keep options classes simple POCOs without logic

### Minimal API Endpoints
- Include `ILogger<Program>` parameter for consistency
- Use `TypedResults.Ok()` for responses
- Format response strings consistently: `"Position Options: {Title}, {Name}"`
- For IOptionsMonitor, register change callback with logging

### Configuration
- Target .NET 9.0 with `<Nullable>enable</Nullable>`
- Use implicit usings enabled
- No additional NuGet packages required - uses built-in Microsoft.Extensions.Options

## Educational Focus Areas

When modifying this project, maintain the educational clarity:
- Each endpoint should clearly demonstrate one interface behavior
- Keep the code minimal and focused on the core concept
- Preserve the runtime configuration change testing scenario
- Maintain the contrast between `.Value` vs `.CurrentValue` usage patterns

## Common Pitfalls to Avoid

- Don't add complex business logic - this is a demonstration project
- Don't change the endpoint URLs - they're referenced in documentation and tests
- Don't modify the configuration structure without updating all three endpoints
- Remember: IOptionsMonitor requires `.CurrentValue`, others use `.Value`
