using System.Text.RegularExpressions;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// POST /clean  { "phone": "(07) 3456-7890" } -> { "cleanedPhone": "0734567890" }
app.MapPost("/clean", (PhonePayload payload) =>
{
    var digits = Regex.Replace(payload?.phone ?? "", "[^0-9]", "");
    return Results.Json(new { cleanedPhone = digits });
});

app.Run();

record PhonePayload(string? phone);
