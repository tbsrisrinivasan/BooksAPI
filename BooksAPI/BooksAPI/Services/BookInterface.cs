using BooksAPI.Model;
using System.Threading.Tasks;
using BooksAPI.RequestModel;

namespace BooksAPI.Services
{
    public interface BookInterface
    {
        BookClass GetBook (int Id);

        List<BookClass> GetBooks();

        bool InsertBook(BookClassRequestModel request);
    }
}
