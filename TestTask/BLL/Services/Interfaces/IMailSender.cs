using TestTask.Domain.Models;

namespace TestTask.BLL.Services.Interfaces
{
    /// <summary>
    /// Интерфейс для отправки сообщений
    /// </summary>
    public interface IMailSender
    {
        /// <summary>
        /// Метод для отправки
        /// </summary>
        /// <param name="subject">Тема сообщения</param>
        /// <param name="body">Текст сообщения</param>
        /// <param name="recipient">Получатель сообщения</param>
        /// <returns></returns>
        Mail Send(string subject, string body, string recipient);
    }
}
