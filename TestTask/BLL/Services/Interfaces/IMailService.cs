using TestTask.BLL.Dtos;
using TestTask.Domain.Models;

namespace TestTask.BLL.Services.Interfaces
{
    /// <summary>
    /// Интерфейс сервиса для сущности сообщения
    /// </summary>
    public interface IMailService
    {
        /// <summary>
        /// Метод для получения сообщений
        /// </summary>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Список сообщений</returns>
        Task<Mail[]> GetMailsAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Метод для отправки сообщений
        /// </summary>
        /// <param name="request">ДТО для отправки сообщений</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns></returns>
        Task SendAsync(MailRequest request, CancellationToken cancellationToken);
    }
}
