using Microsoft.AspNetCore.Mvc;
using Scalar.AspNetCore;
using VirtualClassApp.Application.Abstractions.Repositories.Teachers;
using VirtualClassApp.Persistence;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddPersistenceServices(builder.Configuration);

builder.Services.AddOpenApi();

builder.Services.AddCors(x => x.AddDefaultPolicy(x => x.AllowAnyHeader().AllowAnyMethod().AllowCredentials().SetIsOriginAllowed(x => true)));

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseCors();

app.MapScalarApiReference();

app.UseHttpsRedirection();

app.MapGet("/api/teachers", [HttpGet]
async (ITeacherRepository teacherRepository) =>
{
    var students = await teacherRepository.GetAllAsync(x =>
    {
   
    });

    return Results.Ok(students);
});





app.Run();

