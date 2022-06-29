using Meetup;
using Meetup.BLL.Entities;
using Meetup.BLL.Interfaces;
using Meetup.BLL.Services;
using Meetup.DLL.Contexts;
using Meetup.DLL.Repositories;
using Meetup.DLL.UnitOfWork;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddDbContext<MeetingContext>(options => options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Meetup;Trusted_Connection=True;MultipleActiveResultSets=true;"));
builder.Services.AddScoped<IRepository<Meeting>, MeetingRepository>();
builder.Services.AddScoped<IService<Meeting>, MeetingService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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
