using CoreBankAPI.CoreDbContext;
using CoreBankAPI.Logic.Interfaces;
using Microsoft.EntityFrameworkCore;
using CoreBankAPI.Logic;
using CoreBankAPI.Logic.Validator;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<CoreDb>(options => options.UseSqlite("Data source=banco.db"));
builder.Services.AddScoped<IUserManager, UserManager>();
builder.Services.AddScoped<IAccountManager, AccountManager>();
builder.Services.AddScoped<ITransacionManager, TransactionManager>();

builder.Services.AddScoped<ValidateRequest>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

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
