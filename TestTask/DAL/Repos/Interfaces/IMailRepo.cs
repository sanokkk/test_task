using TestTask.Domain.Models;

namespace TestTask.DAL.Repos.Interfaces
{
    public interface IMailRepo
    {
        Task AddAsync(Mail mail, CancellationToken cancellationToken);

        Task<Mail[]> GetMailsAsync(CancellationToken cancellationToken);
    }
}
