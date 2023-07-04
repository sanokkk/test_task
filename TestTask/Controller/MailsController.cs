using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;
using TestTask.BLL.Dtos;
using TestTask.BLL.Services.Interfaces;

namespace TestTask.Controller
{
    /// <summary>
    /// Контроллер для сообщений
    /// </summary>
    [ApiController]
    [Route("api/mails")]
    public class MailsController: ControllerBase
    {
        private readonly IMailService _mailService;
        /// <summary>
        /// Конструктор для инициализации сервисов через DI
        /// </summary>
        /// <param name="mailService">Сервис для сущности сообщения</param>
        public MailsController(IMailService mailService)
        {
            _mailService = mailService;
        }

        /// <summary>
        /// Эндпоинт для получения сообщений - GET
        /// </summary>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>ОК - 200 со списком сообщений</returns>
        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            var response = await _mailService.GetMailsAsync(cancellationToken);
            return Ok(response);
        }

        /// <summary>
        /// Метод для отправки сообщения - POST
        /// </summary>
        /// <param name="request">ДТО для отправки</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>ОК - загрузка сообщений в БД</returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]MailRequest request, 
            CancellationToken cancellationToken)
        {
            await _mailService.SendAsync(request, cancellationToken);
            return Ok();
        }
    }
}
