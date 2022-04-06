using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate_Part2ConsoleApp.Models
{
    internal class Book : IEntity
    {
        #region Fields
        string _name;
        string _authorName;
        int _pageCount;
        bool _isDelete;
        int _id;
        #endregion

        #region Properties
        public string Name 
        {
            get
            {
                return _name;   
            }
            set
            {
                _name = value;
            }
        }
        public string AuthorName
        {
            get
            {
                return _authorName;
            }
            set
            {
                _authorName = value;
            }
        }
        public int PageCount 
        { 
            get
            {
                return _pageCount;
            } 
            set
            {
                _pageCount=value;
            }
        }
        public int Id { get; }

        public bool IsDelete 
        { 
            get
            {
                return _isDelete;
            }
            set
            {
               _isDelete=value;
            }
        }

        #endregion

        #region Constructor
        public Book(string name, string authorname, int pagecount)
        {
            this.Name = name;
            this.AuthorName = authorname;
            this.PageCount = pagecount;
            _id++;
            Id = _id;
        }
        #endregion

        #region Method      
        public void ShowInfo()
        {
            Console.WriteLine($"Book name: {Name}\n" +
                $"Book authorname: {AuthorName}\n" +
                $"Book pagecount: {PageCount}\n" +
                $"Book ID: {Id}");
        }
        #endregion

    }
}
