using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.Net;
using TestTask;
using TestTask.BLL.Services.Implementations;
using TestTask.BLL.Services.Interfaces;
using TestTask.DAL;
using TestTask.DAL.Repos.Implementations;
using TestTask.DAL.Repos.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<MailContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("MSSQL")));

//Репозитории
builder.Services.AddScoped<IMailRepo, MailRepo>();

//Сервисы
builder.Services.AddScoped<IMailService, MailService>();
builder.Services.AddScoped<IMailSender, MailSender>();

var smtpSetting = builder.Configuration.GetSection("Mail").Get<SmtpSettings>();
builder.Services.AddSingleton(smtpSetting);

var app = builder.Build();



app.MapControllers();


app.Run();
