using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
AddSwaggerDoc(builder.Services);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(o =>
{
    o.AddPolicy("CorsPolicy",
        builder => builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors("CorsPolicy");
app.UseAuthentication();
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Rideshare.WebApi v1"));
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

void AddSwaggerDoc(IServiceCollection services)
{
    services.AddSwaggerGen(c => {
        c.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "Samuel Chatapp API",
            Version = "v1",
            Description = "Samuel Chatapp API Services",
            Contact = new OpenApiContact
            {
                Name = "Samuel Abatneh",
                Email = "samuelabatneh21@gmail.com"
            },
        });
        c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Name = "Authorization",
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Description = "JWT Authorization header using the Bearer scheme."
        });

        c.AddSecurityRequirement(new OpenApiSecurityRequirement
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
                new string[] {}
            }
        });
    });
}