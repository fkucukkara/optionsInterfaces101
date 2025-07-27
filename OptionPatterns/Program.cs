using Microsoft.Extensions.Options;
using OptionPatterns;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<PositionOptions>(
    builder.Configuration.GetSection(PositionOptions.Position));

var app = builder.Build();

app.MapGet("/option", (ILogger<Program> Logger, IOptions<PositionOptions> options) =>
{
    var result = $"Position Options: {options.Value.Title}, {options.Value.Name}";
    return TypedResults.Ok(result);
});

app.MapGet("/option-snapshot", (ILogger<Program> Logger, IOptionsSnapshot<PositionOptions> options) =>
{
    var result = $"Position Options: {options.Value.Title}, {options.Value.Name}";
    return TypedResults.Ok(result);
});

app.MapGet("/option-monitor", (ILogger<Program> Logger, IOptionsMonitor<PositionOptions> options) =>
{
    options.OnChange((opts, name) =>
    {
        Logger.LogInformation($"Position Options changed: {opts.Title}, {opts.Name}");
    });

    var result = $"Position Options: {options.CurrentValue.Title}, {options.CurrentValue.Name}";
    return TypedResults.Ok(result);
});

app.Run();