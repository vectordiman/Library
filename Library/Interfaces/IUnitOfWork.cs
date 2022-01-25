using System.Threading.Tasks;

namespace Library.Interfaces
{
    public interface IUnitOfWork
    {
        IBookRepository BookRepository { get; }

        Task<bool> Complete();

        bool HasChanges();
    }
}