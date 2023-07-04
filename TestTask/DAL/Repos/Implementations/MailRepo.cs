using Microsoft.EntityFrameworkCore;
using TestTask.DAL.Repos.Interfaces;
using TestTask.Domain.Models;

namespace TestTask.DAL.Repos.Implementations
{
    /// <summary>
    /// Репозиторий для сущности сообщения
    /// </summary>
    public class MailRepo : IMailRepo
    {
        private readonly MailContext _context;
        private readonly ILogger<MailRepo> _logger;

        /// <summary>
        /// Конструктор для DI
        /// </summary>
        /// <param name="context">Контекст БД</param>
        /// <param name="logger">Логгер</param>
        public MailRepo(MailContext context, ILogger<MailRepo> logger)
        {
            _context = context;
            _logger = logger;
        }

        /// <summary>
        /// Метод для добавления сообщения в бд
        /// </summary>
        /// <param name="mail">Сущность сообщения</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>возвращает таску</returns>
        public async Task AddAsync(Mail mail, CancellationToken cancellationToken)
        {
            try
            {
                cancellationToken.ThrowIfCancellationRequested();
                await _context.Mails.AddAsync(mail, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
            }
            catch(OperationCanceledException ex)
            {
                _logger.LogError("Operation was cancelled");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while adding mail: {ex.Message}");
            }
        }

        /// <summary>
        /// Метод для получения всех сообщений из БД
        /// </summary>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Возвращает таску со списком сообщений</returns>
        public async Task<Mail[]> GetMailsAsync(CancellationToken cancellationToken)
        {
            Mail[] result = null;
            try
            {
                cancellationToken.ThrowIfCancellationRequested();
                result = await _context.Mails.AsNoTracking().ToArrayAsync(cancellationToken);
            }
            catch (OperationCanceledException ex)
            {
                _logger.LogError("Operation was cancelled");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while adding mail: {ex.Message}");
            }
            return result;
        }
    }
}
