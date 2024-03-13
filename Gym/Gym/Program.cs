using Gym;
using Gym.Core;
using Gym.Core.Models;
using Gym.Core.ServicesModels;
using Gym.Data.DataContext;
using Gym.Data.DataRepository;
using Gym.Servies.ServiesRepository;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers();
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddScoped<DataContext, DataContext>();


var policy = "policy";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: policy, policy =>
    {
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
}
    );


builder.Services.AddScoped<IStaffService, StaffServies>();
builder.Services.AddScoped<IStaff, StaffRepository>();

builder.Services.AddScoped<IEquipmentService, EquipmentServies>();
builder.Services.AddScoped<IEquipment, EquipmenRepository>();

builder.Services.AddScoped<ISubscriberService, SubscriberServies>();
builder.Services.AddScoped<ISubscriber, SubscriberRepository>();
builder.Services.AddDbContext<GymData>();
builder.Services.AddAutoMapper(typeof(MappingProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors(policy);


app.MapControllers();

app.Run();
