using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate_Part2ConsoleApp.Models
{
    internal class Library : IEntity
    {
        #region Fields
        int _bookLimit;
        List<Book> _books;
        #endregion
        public int Id { get; }
    }
}
