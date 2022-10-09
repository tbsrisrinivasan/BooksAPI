using Microsoft.AspNetCore.Mvc;
using BooksAPI.Services;
using BooksAPI.Model;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
using BooksAPI.RequestModel;

namespace BooksAPI.Controllers
{
    [ApiController]
    [Route("Book")]
    public class BookController : Controller
    {
        private BookInterface IBook;
        public BookController(BookInterface Ibook)
        {
            this.IBook = Ibook;
        }

        [HttpGet("GetBook")]
        public BookClass GetBook(int Id)
        {
            try
            {
                var bookdetails = IBook.GetBook(Id);

                return bookdetails;
            }
            catch (Exception ex)
            {
                return null;
            }
            

        }

        [HttpGet("GetBooks")]
        public List<BookClass> GetBooks()
        {
            try
            {
                var bookdetails = IBook.GetBooks();

                return bookdetails;
            }
            catch (Exception ex)
            {
                return null;
            }


        }

        [HttpPost("InsertBook")]
        public bool InsertBook(BookClassRequestModel request)
        {
            try
            {
                var bookdetails = IBook.InsertBook(request);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }


        }
    }
}
