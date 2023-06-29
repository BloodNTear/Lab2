using DataLayer.Implement;
using DataLayer.Interface;
using DataLayer.Models;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using Microsoft.OpenApi.Models;
using Odata.JWT;
using Repository.Entities;
using System.Runtime.CompilerServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddOData(
    odata => odata.Select().Filter().Expand().OrderBy().AddRouteComponents("odata", GetEDM()));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
	options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
	{
		Type = SecuritySchemeType.Http,
		Scheme = "bearer",
		BearerFormat = "JWT",
		In = ParameterLocation.Header,
		Description = "Enter the JWT token obtained from the login endpoint",
		Name = "Authorization"
	});
	options.AddSecurityRequirement(new OpenApiSecurityRequirement
		{
			{
				new OpenApiSecurityScheme
				{
					Reference = new OpenApiReference
					{
						Type = ReferenceType.SecurityScheme,
						Id = "Bearer"
					}
				},
				Array.Empty<string>()
			}
		});
});

builder.Services.AddDbContext<DataLayer.DatabaseContext>();

builder.Services.AddScoped<IJWTService, JWTService>();
builder.Services.AddHttpContextAccessor();


builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IPressRepository, PressRepository>();
builder.Services.AddScoped<IAddressRepository, AddressRepository>();



var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>

                      {
                          policy.WithOrigins("https://localhost:7171").AllowAnyHeader().WithExposedHeaders("Authorization").AllowAnyMethod();
                      });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(MyAllowSpecificOrigins);

app.MapControllers();

app.Run();

static IEdmModel GetEDM()
{
    ODataConventionModelBuilder builder = new();
    builder.EntitySet<Book>("Book");
    builder.EntitySet<User>("Account");
    builder.EntitySet<Press>("Press");
    builder.EntitySet<Address>("Address");

    return builder.GetEdmModel();
}
