using IoT.Persistence;
using IoT.Repository.Device;
using IoT.Repository.DeviceTelemetry;
using IoT.Repository.Hubs;
using IoT.Repository.Robots;
using IoT.Repository.RobotTelemRepository;
using IoT.Repository.User;
using IoT.Service.Device;

using IoT.Service.DeviceTelemetry;
using IoT.Service.Hub;

using IoT.Service.Robot;

using IoT.Service.RobotTelemetry;
using IoT.Service.User;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Controllers
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DbContext — Npgsql
builder.Services.AddDbContext<ApplicationDbContext>(opt =>
    opt.UseNpgsql(builder.Configuration.GetConnectionString("Default")));

// Repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IHubsRepository, HubsRepository>();
builder.Services.AddScoped<IDeviceRepository, DeviceRepository>();
builder.Services.AddScoped<IDeviceTelemetry, DevTelemRepository>();
builder.Services.AddScoped<IRobotTelemRepository, RobotTelemRepository>();
builder.Services.AddScoped<IRobotRepository, RobotRepository>();
   

// Services
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IHubService, HubService>();
builder.Services.AddScoped<IDeviceService, DeviceService>();
builder.Services.AddScoped<IDeviceTelemService, DeviceTelemetryService>();
builder.Services.AddScoped<IRobotService, RobotService>();
builder.Services.AddScoped<IRobotTelemetry, RobotTelemetryService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();