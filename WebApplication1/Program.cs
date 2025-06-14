using Microsoft.IdentityModel.Protocols.Configuration;
using Microsoft.OpenApi.Models;
using SampleApp.Endpoints.Api.CustomDecorators;
using SampleApp.Infrastructure.Data.EF.Command;
using SampleApp.Infrastructure.Data.EF.Query;
using Zamin.Core.ApplicationServices.Queries;
using Zamin.Extensions.DependencyInjection;

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

builder.Services.AddEfStudentQueryRepository();

builder.Services.AddSingleton<QueryDispatcherDecorator, CustomQueryDecorator>();
builder.Services.AddZaminApiCore("Zamin", "ZaminTemplate");
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddZaminParrotTranslator(builder.Configuration, "ParrotTranslator");
builder.Services.AddZaminMicrosoftSerializer();
builder.Services.AddZaminWebUserInfoService(builder.Configuration, "WebUserInfo", true);
builder.Services.AddZaminInMemoryCaching();
builder.Services.AddZaminAutoMapperProfiles(builder.Configuration, "AutoMapper");

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo() { Title = "Sample App"});
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapGet("", () => "SampleApp is working.");

app.UseSwagger();
app.UseSwaggerUI();

app.Run();
