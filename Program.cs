using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

var port = Environment.GetEnvironmentVariable("PORT") ?? "3000";
var url = $"http://0.0.0.0:{port}";
var target = Environment.GetEnvironmentVariable("TARGET") ?? "World";

var app = builder.Build();

app.MapGet("/", () => $"Hello {target}!");
app.MapPost("/encrypt", (HttpRequest request) => { return Encryption.RequestHandeler.Encrypt(request); });
app.MapPost("/decrypt", (HttpRequest request) => { return Encryption.RequestHandeler.Decrypt(request); });

app.Run(url);