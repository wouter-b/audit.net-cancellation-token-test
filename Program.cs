using Audit.WebApi;
using Microsoft.AspNetCore.Mvc;

Audit.Core.Configuration.Setup().UseFileLogProvider(cfg => cfg.FilenamePrefix("auditnet_"));

var builder = WebApplication.CreateBuilder();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers(cfg => cfg.AddAuditFilter(select => select.LogAllActions()));

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
