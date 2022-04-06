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
        int _id;
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
                if (book.IsDeleted()==false && book.Name==item.Name)
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
           
        }


        #endregion

    }
}
