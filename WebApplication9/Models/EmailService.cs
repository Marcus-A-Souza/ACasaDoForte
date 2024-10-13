using WebApplication9.Models;
using System.Net.Mail;
using System.Net;
using MDriven.MDrivenServer;
using MimeKit;
using MailKit.Security;

namespace WebApplication9.Models
{
    public class EmailService
    {
        public void SendEmail(string recipientEmail, string subject, string body)
        {
            // Configure o remetente, senha e servidor SMTP
            string fromEmail = "marcussouza1425@hotmail.com"; // Substitua pelo seu e-mail
            string fromPassword = "Marcus142536*"; // Substitua pela senha correta

            var smtpClient = new SmtpClient("smtp.office365.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(fromEmail, fromPassword),
                EnableSsl = true, // SSL habilitado para conexão segura
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress(fromEmail),
                Subject = subject,
                Body = body,
                IsBodyHtml = true, // Caso o corpo do e-mail tenha HTML
            };
            mailMessage.To.Add(recipientEmail);

            try
            {
                smtpClient.Send(mailMessage);
                Console.WriteLine("Email enviado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao enviar e-mail: {ex.Message}");
            }

        }
    }
}
