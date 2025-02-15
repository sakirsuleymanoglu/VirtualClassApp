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

builder.Services.AddCors(x => x.AddDefaultPolicy(x => x.AllowAnyHeader().AllowAnyMethod().AllowCredentials().SetIsOriginAllowed(x => true)));

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseCors();

app.MapScalarApiReference();

app.UseHttpsRedirection();

app.MapEndpoints(new CoursesEndpointsMapper(BaseRoutes.Courses));

app.Run();

