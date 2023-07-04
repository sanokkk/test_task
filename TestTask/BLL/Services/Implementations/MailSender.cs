using System.Net;
using System.Net.Mail;
using TestTask.BLL.Services.Interfaces;
using TestTask.Domain.Models;

namespace TestTask.BLL.Services.Implementations
{
    /// <summary>
    /// Класс-реализация отправки сообщения
    /// </summary>
    public class MailSender : IMailSender
    {
        private readonly SmtpSettings _settings;
        private readonly ILogger<MailSender> _logger;

        /// <summary>
        /// Инициализация параметров через DI
        /// </summary>
        /// <param name="settings">Конфигурация SMTP-сервера</param>
        /// <param name="logger">Логгер</param>
        public MailSender(SmtpSettings settings, ILogger<MailSender> logger)
        {
            _settings = settings;
            _logger = logger;
        }

        /// <summary>
        /// Метод для отправки сообщения
        /// </summary>
        /// <param name="subject">Тема сообщения</param>
        /// <param name="body">Текст сообщения</param>
        /// <param name="recipient">Получатель</param>
        /// <returns></returns>
        public Mail Send(string subject, string body, string recipient)
        {
            var result = new Mail()
            {
                Body = body,
                Subject = subject,
                Recipient = recipient,
                CreatedAt = DateTime.UtcNow,
            };
            MailAddress from = new MailAddress(_settings.From);
            var to = new MailAddress(recipient);
            try
            {
                using (var msg = new MailMessage(from, to))
                {
                    using (var smtp = new SmtpClient())
                    {
                        smtp.UseDefaultCredentials = _settings.UseDefaultCredentials;
                        smtp.Credentials = new NetworkCredential(from.Address, _settings.Key);
                        msg.Subject = subject;
                        msg.Body = body;
                        smtp.Host = _settings.Server;
                        smtp.Port = _settings.Port;
                        smtp.EnableSsl = _settings.EnableSSl;
                        smtp.DeliveryMethod = _settings.DeliveryMethod;

                        smtp.Send(msg);
                    }
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while sending message: {ex.Message}");
                result.Result = "Failed";
                result.FailedMessage = ex.Message;
                return result;
            }
            result.Result = "OK";
            result.FailedMessage = string.Empty;
            return result;
        }
    }
}
