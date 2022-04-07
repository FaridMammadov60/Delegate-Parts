using Delegate_Part2ConsoleApp.Enums;
using Delegate_Part2ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Delegate_Part2ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.OutputEncoding = Encoding.Unicode;
                Console.InputEncoding = Encoding.Unicode;

                #region Create User
                Console.Write("Username daxil edin: ");
                string userName = Console.ReadLine();
                Console.Write("Email daxil edin: ");
                string email = Console.ReadLine();
            L1: Console.Write("Rol enum daxil edin: ");
                string rol = Console.ReadLine();
                if (rol == "Admin" || rol == "Member")
                {
                    goto L2;
                }
                else
                {
                    Console.WriteLine("Enum düzgün daxil edilmeyib yenidən cəhd edin");
                    goto L1;
                }
            L2: Role role = Enum.Parse<Role>(rol);

                User user = new User(userName, email, role);
                user.ShowInfo();
                #endregion
                #region Create Library
                List<Book> books = new List<Book>();
                Library library = new Library()
                {
                    Books = books,
                    BookLimit = 11
                };
            #endregion

            #region Menyu
            M1: Console.WriteLine("1. Add book\n" +
                "2. Get book by id\n" +
                "3. Get all books\n" +
                "4. Delete book by id\n" +
                "5. Edit book name\n" +
                "6. Filtr by page count\n" +
                "0. Quit");
                Console.Write("Enter menyu number: ");

                int men = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("------------------------");
                #endregion

                switch (men)
                {
                    case 0:
                        break;
                    case 1:
                        #region AddBook
                        Console.Clear();
                        if (role == Role.Member)
                        {
                            Console.WriteLine("Sizin kitab əlavə etmək icazəniz yoxdur");
                            goto M1;
                        }
                        Console.Write("Kitabın adın daxil edin: ");
                        string nameBook = Console.ReadLine();
                        Console.Write("Kitabın müəllifin daxil edin: ");
                        string authorNameBook = Console.ReadLine();
                        Console.Write("Kitabın səhifə sayın daxil edin: ");
                        int pageCount = Convert.ToInt32(Console.ReadLine());
                        Book book = new Book(nameBook, authorNameBook, pageCount);
                        library.AddBook(book);
                        #endregion
                        goto M1;
                    case 2:
                        #region GetBookById
                        Console.Clear();
                        Console.Write("Seçmək istenilen ID-ni daxil edin: ");
                        int id = Convert.ToInt32(Console.ReadLine());
                        library.GetBookById(id);
                        Console.WriteLine("___________________");
                        #endregion

                        goto M1;
                    case 3:
                        Console.Clear();
                        library.GetAllBooks();
                        goto M1;
                    case 4:
                        #region DeleteById
                        Console.Clear();
                        if (role == Role.Member)
                        {
                            Console.WriteLine("Sizin kitab silmək icazəniz yoxdur");
                            goto M1;
                        }
                        Console.Write("Silmək istenilen ID-ni daxil edin: ");
                        int id2 = Convert.ToInt32(Console.ReadLine());
                        library.DeleteBookById(id2);

                        #endregion
                        goto M1;
                    case 5:
                        #region EditBookName
                        Console.Clear();
                        if (role == Role.Member)
                        {
                            Console.WriteLine("Sizin kitab edit icazəniz yoxdur");
                            goto M1;
                        }
                        Console.Write("Adı deyişiləcək kitabın ID-sin daxil edin: ");
                        int id3 = Convert.ToInt32(Console.ReadLine());
                        library.EditBookName(id3);
                        #endregion
                        goto M1;
                    case 6:
                        #region FiltrByPageCount
                        Console.Clear();
                        Console.Write("Min page daxil edin: ");
                        int minpage = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Max page daxil edin: ");
                        int maxpage = Convert.ToInt32(Console.ReadLine());
                        library.FiltrByPageCount(minpage, maxpage);

                        #endregion
                        goto M1;
                    default:
                        Console.WriteLine("Menyu nömrəsi düzgün daxil edilməmişdir!!!");
                        goto M1;

                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

        }
    }
}
