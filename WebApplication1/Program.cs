using Microsoft.IdentityModel.Protocols.Configuration;
using SampleApp.Infrastructure.Data.EF.Command;
using SampleApp.Infrastructure.Data.EF.Query;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

string queryConnectionString = builder.Configuration.GetConnectionString("SampleAppQuery")
    ?? throw new InvalidConfigurationException("SampleAppQuery connection string is not provided!");

builder.Services.AddSampleAppQueryDbContext(queryConnectionString);

string commandConnectionString = builder.Configuration.GetConnectionString("SampleAppCommand")
    ?? throw new InvalidConfigurationException("SampleAppCommand connection string is not provided!");

builder.Services.AddSampleAppCommandDbContext(commandConnectionString);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
