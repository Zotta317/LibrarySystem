using LibrarySystem.Data;
using LibrarySystem.Interface;
using LibrarySystem.Repository;
using LibrarySystem.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IProfileRepository, ProfileRepository>();
builder.Services.AddScoped<IProfileService, ProfileService>();
builder.Services.AddScoped<IBookRecordRepository, BookRecordRepository>();
builder.Services.AddScoped<IBookRecordService, BookRecordService>();
builder.Services.AddScoped<IRemovedBookRepository, RemovedBookRepository>();
builder.Services.AddScoped<IRemovedBookService, RemovedBookService>();

builder.Services.AddDbContext<LibrarySystemDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LibraryDBContext")));
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


app.UseCors(policyName: "AllowAll");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
