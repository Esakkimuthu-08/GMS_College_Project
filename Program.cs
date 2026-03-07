using Grievence_Management_System_Project.AppDbContext;
using Grievence_Management_System_Project.Repositary;
using Grievence_Management_System_Project.Repositary.Interfaces;
using Grievence_Management_System_Project.Service;
using Grievence_Management_System_Project.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<GrievenceDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    ));
builder.Services.AddScoped<IStaffRepositary, StaffRepositary>();
builder.Services.AddScoped<IStaffService, StaffService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IAuthRepositary, AuthRepositary>();
builder.Services.AddScoped<IApprovalService, ApprovalService>();
builder.Services.AddScoped<IApprovalRepositary, ApprovalRepositary>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IStudentRepositary, StudentRepositary>();
// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// ✅ USE THE SAME POLICY NAME
app.UseCors("AllowAll");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
