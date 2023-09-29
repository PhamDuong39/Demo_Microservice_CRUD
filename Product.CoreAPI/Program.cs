using Product.CoreAPI.RegisterModules;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Register Services

builder.Services.RegisterServices();

#endregion


#region Register SeriLog

Log.Information("Starting up");
var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", false, true)
    .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", true,
        true)
    .Build();

SerilogRegister.Initialize(configuration);

#endregion

#region Register CORS


builder.Services.AddCors(option =>
{
    option.AddPolicy("Default", corsPolicyBuilder =>
        corsPolicyBuilder
            .WithOrigins()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

#endregion


builder.Host.UseSerilog();

var app = builder.Build();

app.UseCors();

app.UseSerilogRequestLogging();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
