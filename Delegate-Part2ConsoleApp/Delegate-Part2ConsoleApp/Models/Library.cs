using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilsLibrary.Exceptions;

namespace Delegate_Part2ConsoleApp.Models
{
    internal class Library : IEntity
    {
        #region Fields
        int _bookLimit;
        List<Book> _books;
        static int _id;
        #endregion

        #region Properties
        public List<Book> Books
        {
            get
            {
                return _books;
            }
            set
            {
                _books = value;
            }
        }
        public int BookLimit 
        {
            get
            {
                return _bookLimit;
            }
            set
            {
                _bookLimit=value;
            }
        }

        public int Id { get; }
        #endregion

        #region Constructor
        public Library()
        {
            _id++;
            Id = _id;
        }
        #endregion

        #region Methods
        public void AddBook(Book book)
        {
            foreach (var item in Books)
            {
                if (book.IsDelete==false && book.Name==item.Name)
                {
                    AlreadyExistsException.Allready();
                    return;
                }
                
            }
            if (Books.Count>BookLimit)
            {
                CapacityLimitException.CapacityLimit();
                return;
            }
            Books.Add(book);
            Console.WriteLine("Kitab uğurla Kitabxanaya əlavə edildi");
            Console.WriteLine("-----------------------------");

        }

        public Book GetBookById(int? id)
        {
            if (id==null)
            {
                NullReferenceException ex = null;
                Console.WriteLine(ex.Message);
            }
            foreach (var item in Books)
            {
                if (id==item.Id && item.IsDelete==false)
                {
                    item.ShowInfo();
                    Console.WriteLine("---------------------");
                    return item;
                }
            }
            return null;
            
        }

        public void GetAllBooks()
        {
            List<Book>booksnew=new List<Book>();
           booksnew.AddRange(Books);
            foreach (var item in booksnew)
            {
                if (item.IsDelete==false)
                {
                    item.ShowInfo();
                    Console.WriteLine("--------------");
                }                
            }
        }

        public bool DeleteBookById(int? id)
        {
            if (id == null)
            {
                NullReferenceException ex = null;
                Console.WriteLine(ex.Message);
            }
            foreach (var item in Books)
            {
                if (id == item.Id && item.IsDelete==false)
                {
                    item.IsDelete = true;
                    Console.WriteLine("Seçilmiş kitab silindi");
                    Console.WriteLine("-------------------------");
                    return item.IsDelete;
                }
            }
            return false;
        }

        public void EditBookName(int? id)
        {
            if (id == null)
            {
                NullReferenceException ex = null;
                Console.WriteLine(ex.Message);
            }
            foreach (var item in Books)
            {
                if (id==item.Id)
                {
                    Console.Write("Kitabın yeni adın qeyd edin: ");
                    item.Name=Console.ReadLine();
                    Console.WriteLine("-------------------------");
                    return;
                }
            }
            NotFoundException.NotFound();
        }

        public void FiltrByPageCount(int minPageCount, int maxPageCount)
        {
            foreach (var item in Books)
            {
                if (item.PageCount>minPageCount&& item.PageCount<maxPageCount&&item.IsDelete==false)
                {
                    item.ShowInfo();
                    Console.WriteLine("---------------------------");
                    return;
                }
            }
            Console.WriteLine("Qeyd edilmiş sehifə aralığında kitab yoxdur");
        }
        #endregion

    }
}
