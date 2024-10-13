using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using Microsoft.AspNetCore.Mvc;
using WebApplication9.Models;

namespace WebApplication9.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Contato()
        {
            return View();
        }
        public IActionResult Somos()
        {
            return View();
        }
        public IActionResult Estrutura()
        {
            return View();
        }
        // Ação para enviar e-mail
        [HttpPost]
        public IActionResult SendEmail(string name, string email, string phone, string message)
        {
            try
            {
                // Configurações de SMTP (altere para seu provedor de e-mail)
                var smtpClient = new SmtpClient("smtp-mail.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("casadoforte44@gmail.com", "Casadoforte142536"),
                    EnableSsl = true,
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress("casadoforte44@gmail.com"),
                    Subject = "Novo Contato do Site",
                    Body = $"Nome: {name}\nEmail: {email}\nTelefone: {phone}\nMensagem: {message}",
                    IsBodyHtml = false,
                };

                mailMessage.To.Add("casadoforte44@gmail.com");

                smtpClient.Send(mailMessage);

                ViewBag.Message = "E-mail enviado com sucesso!";
            }
            catch (Exception ex)
            {
                ViewBag.Message = $"Erro ao enviar o e-mail: {ex.Message}";
            }

            return View("Contato"); // Retorna para a página de contato com a mensagem
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
