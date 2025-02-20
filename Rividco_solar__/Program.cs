using Microsoft.EntityFrameworkCore;
using Rividco_solar__.Dbcontext;
using Rividco_solar__.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<AppDbcontext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 31)) 
    ));

builder.Services.AddScoped<ICustomerServices , CustomerServices>();
builder.Services.AddScoped<IProjectitemservices, ProjectitemServices>();
builder.Services.AddScoped<IProjectServices, ProjectServices>();
builder.Services.AddScoped<IVendorServices, VendorServices>();
builder.Services.AddScoped<IVendoritemServices, VendoritemServices>();
builder.Services.AddScoped<IVendorServices, VendorServices>();
builder.Services.AddScoped<ISystemuserServices, SystemuserServices>();
builder.Services.AddScoped<IProjectCIAservices, ProjectCIAServices>();
builder.Services.AddScoped<IProjecttestservices,ProjectTestServices>();



builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp", policy =>
    {
        policy.WithOrigins("http://localhost:5173") // React app origin
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
app.UseCors("AllowReactApp");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
