namespace TestTask.BLL.Dtos
{
    /// <summary>
    /// Модель для отправки сообщения
    /// </summary>
    public class MailRequest
    {
        /// <summary>
        /// Тема сообщения
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Текст сообщения
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// Получатели сообщения
        /// </summary>
        public string[] Recipients { get; set; }
    }
}
