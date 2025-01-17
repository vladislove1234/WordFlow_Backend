using FluentValidation.AspNetCore;
using VeeArc.Application;
using VeeArc.Application.Common.Interfaces;
using VeeArc.Infrastructure;
using VeeArc.WebAPI.Filter;
using VeeArc.WebAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ICurrentUserService, CurrentUserService>();

builder.Services.AddApplication(builder.Configuration);
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddControllers(options =>
{
    options.AllowEmptyInputInBodyModelBinding = true;
    options.Filters.Add<ExceptionFilter>();
});

builder.Services.AddFluentValidationAutoValidation(opt =>
{
    opt.DisableDataAnnotationsValidation = true;
});

builder.Services.AddFluentValidationClientsideAdapters();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
