using Microsoft.EntityFrameworkCore;
using TestTask.Domain.Models;

namespace TestTask.DAL
{
    /// <summary>
    /// Конекст БД (MS SQL Server)
    /// </summary>
    public class MailContext: DbContext
    {
        public MailContext(DbContextOptions<MailContext> options)
            :base(options)
        {
            
        }

        /// <summary>
        /// ДБСет сообщений (таблица сообщений)
        /// </summary>
        public DbSet<Mail> Mails { get; set; }
    }
}
