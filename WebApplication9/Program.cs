using WebApplication9.Models;
using System.Net.Mail;
using System.Net;

var builder = WebApplication.CreateBuilder(args);
var smtpClient = new SmtpClient("smtp.hotmail.com", 587);
smtpClient.EnableSsl = true;
smtpClient.Credentials = new NetworkCredential("casadoforte44@gmail.com", "Casadoforte142536");

var mailMessage = new MailMessage();
mailMessage.To.Add("casadoforte44@gmail.com");
mailMessage.Subject = "Assunto do e-mail";
mailMessage.Body = "Corpo do e-mail";

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Adicione o código aqui
app.MapControllerRoute(
    name: "ValidarCPF",
    pattern: "ValidarCPF/{cpf}",
    defaults: new { controller = "Home", action = "ValidarCPF" });

app.MapControllerRoute(
    name: "CPF",
    pattern: "{controller=CPFController}/{action=Index}/{id?}");

app.UseAuthorization();

app.Run();