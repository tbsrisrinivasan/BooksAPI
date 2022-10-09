using BooksAPI.Services;
using BooksAPI.Model;
using BooksAPI.DBLayer;
using BooksAPI.RequestModel;

namespace BooksAPI.Implementation
{
    public class BookServiceClass : BookInterface
    {
        public IConfiguration Config;

        public BookServiceClass(IConfiguration config)
        {
            this.Config = config;
        }
        public BookClass GetBook (int Id)
        {
            string connstr = Config.GetConnectionString("BooksConnectionString");
            DBClass obj = new DBClass();
            BookClass book = obj.GetBook(Id, connstr);

            return book;
        }
         
        public List<BookClass> GetBooks()
        {
            string connstr = Config.GetConnectionString("BooksConnectionString");
            DBClass obj = new DBClass();
            List<BookClass> books = obj.GetBooks(connstr);

            return books;
        }

        public bool InsertBook(BookClassRequestModel request)
        {
            string connstr = Config.GetConnectionString("BooksConnectionString");
            DBClass obj = new DBClass();
            bool book = obj.InsertBook(request, connstr);

            return true;
        }

    }
}
