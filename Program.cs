using Audit.Core;
using Audit.WebApi;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen();
builder.Services.AddControllers(options => options.AddAuditFilter(config => config.LogAllActions()));
Configuration.Setup().UseFileLogProvider(config => config.FilenamePrefix("auditnet_"));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.MapDefaultControllerRoute();

app.Run();

public class Controller : ControllerBase
{
    [HttpGet("ok-with-cancellation-token")]
    public IActionResult GetOkWithCancellationToken(CancellationToken cancellationToken) => Ok();

    [HttpGet("ok-without-cancellation-token")]
    public IActionResult GetOkWithOutCancellationToken() => Ok();
}
