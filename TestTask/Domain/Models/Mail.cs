using Microsoft.VisualBasic;

namespace TestTask.Domain.Models
{
    /// <summary>
    /// Модель сообщения лоя БД
    /// </summary>
    public class Mail
    {
        /// <summary>
        /// Айди
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Текст сообщения
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// Тема сообщения
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Получатель
        /// </summary>
        public string Recipient { get; set; }

        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Результат отправки
        /// </summary>
        public string Result { get; set; }

        /// <summary>
        /// Ошибка при отправке
        /// </summary>
        public string FailedMessage { get; set; }
    }
}
