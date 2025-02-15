using Scalar.AspNetCore;
using VirtualClassApp.Application;
using VirtualClassApp.Persistence;
using VirtualClassApp.WebAPI.Constants;
using VirtualClassApp.WebAPI.EndpointsMappings.Courses;
using VirtualClassApp.WebAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices(builder.Configuration);

builder.Services.AddOpenApi();

builder.Services.AddAppCors();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseCors();

app.MapScalarApiReference();

app.UseHttpsRedirection();

app.MapEndpoints(
    new CoursesEndpointsMapper(BaseRoutes.Courses),
    new UsersEndpointsMapper(BaseRoutes.Users)
    );

app.Run();

