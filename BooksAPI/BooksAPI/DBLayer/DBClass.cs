using BooksAPI.Model;
using System.Data.SqlTypes;
using System.Data.Sql;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using BooksAPI.RequestModel;


namespace BooksAPI.DBLayer
{
    public class DBClass 
    {
        public DBClass()
        {
            //this.Config = config;
            //this.Connectionstring = this.Config.GetConnectionString("BooksConnectionString");
        }

        public IConfiguration Config ;

        public string Connectionstring  ;

        public BookClass GetBook(int? id, string Connectionstring)
        {
            BookClass book = new BookClass();
            string connstring = Config.GetConnectionString("BooksConnectionString");

            using (SqlConnection con = new SqlConnection(Connectionstring))
            {
                string sqlQuery = "SELECT * FROM Book WHERE BookId= " + id;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                con.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        book.Id = Convert.ToInt32(rdr["BookId"]);
                        book.Name = rdr["Name"].ToString();
                        book.AuthorName = rdr["AuthorName"].ToString();
                    }
                }

               
            }
            return book;
        }

        public List<BookClass> GetBooks(string Connectionstring)
        {
            List<BookClass> BooksList = new List<BookClass>();
            
            string connstring = Config.GetConnectionString("BooksConnectionString");

            using (SqlConnection con = new SqlConnection(Connectionstring))
            {
                string sqlQuery = "SELECT * FROM Book";
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                con.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        BookClass book = new BookClass();
                        book.Id = Convert.ToInt32(rdr["BookId"]);
                        book.Name = rdr["Name"].ToString();
                        book.AuthorName = rdr["AuthorName"].ToString();

                        BooksList.Add(book);
                    }
                }


            }
            return BooksList;
        }

        public bool InsertBook(BookClassRequestModel request, string Connectionstring)
        {
            string BookName = request.Name;
            string AuthorName = request.AuthorName;
            string id = Guid.NewGuid().ToString("N");
            List<BookClass> BooksList = new List<BookClass>();
            BookClass book = new BookClass();
            string connstring = Config.GetConnectionString("BooksConnectionString");

            using (SqlConnection con = new SqlConnection(Connectionstring))
            {
                string sqlQuery = "INSERT INTO Book VALUES('" + id + "','" + BookName + "','" + AuthorName+ "')";
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            return true;
        }

    }
}
