using TestTask.BLL.Dtos;
using TestTask.BLL.Services.Interfaces;
using TestTask.DAL.Repos.Interfaces;
using TestTask.Domain.Models;

namespace TestTask.BLL.Services.Implementations
{
    /// <summary>
    /// Сервис для отправки сообщения
    /// </summary>
    public class MailService : IMailService
    {
        private readonly IMailRepo _mailRepo;
        private readonly IMailSender _mailSender;
        private readonly ILogger<MailService> _logger;

        /// <summary>
        /// Конструктор для реализации зависимостей через DI
        /// </summary>
        /// <param name="mailRepo">Репозиторий для сущности сообщения</param>
        /// <param name="logger">Логгер</param>
        /// <param name="mailSender">Интерфейс, который отправляется сообщения</param>
        public MailService(IMailRepo mailRepo, ILogger<MailService> logger, IMailSender mailSender)
        {
            _mailRepo = mailRepo;
            _logger = logger;
            _mailSender = mailSender;
        }

        /// <summary>
        /// Метод для получения всех писем
        /// </summary>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Список всех писем</returns>
        public async Task<Mail[]> GetMailsAsync(CancellationToken cancellationToken)
        {
            Mail[] response = null;
            try
            {
                cancellationToken.ThrowIfCancellationRequested();
                response = (await _mailRepo.GetMailsAsync(cancellationToken))!;
            }
            catch (OperationCanceledException ex)
            {
                _logger.LogError("Operation was canceled");
            }
            catch(NullReferenceException ex)
            {
                _logger.LogError("Mail list was null");
                return Enumerable.Empty<Mail>().ToArray();
            }
            return response;
        }

        /// <summary>
        /// Метод для отправки сообщения
        /// </summary>
        /// <param name="request">ДТО для отправки сообщения</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>возвращает таску</returns>
        public async Task SendAsync(MailRequest request, 
            CancellationToken cancellationToken)
        {
            try
            {
                cancellationToken.ThrowIfCancellationRequested();
                foreach (var recipient in request.Recipients)
                {
                    var mail = _mailSender.Send(request.Subject, request.Body, recipient);
                    await _mailRepo.AddAsync(mail, cancellationToken);
                }
            }
            catch(OperationCanceledException ex)
            {
                _logger.LogError("Operation was cancelled");
            }
        }
    }
}
