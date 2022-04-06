using Delegate_Part2ConsoleApp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate_Part2ConsoleApp
{
    internal class User : IEntity
    {
       
        #region Fields
        string _userName;
        string _email;
        Role _role;
        static int _id;
        #endregion
        
        #region Properties
        public string UserName
        {
            get
            {
                return _userName;
            }
            set
            {
                _userName = value;
            }
        }
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
            }
        }
        public Role Role
        {
            get
            {
                return _role;
            }
            set
            {
                _role = value;
            }
        }

        public int Id { get; }
        #endregion

        #region Constructor
        public User(string username, string email, Role role)
        {
            this.UserName = username;
            this.Email = email;
            this.Role = role;
            _id++;
            Id = _id;
            
        }
        #endregion

        #region Method
        public void ShowInfo()
        {
            Console.WriteLine($"Username: {UserName}\n" +
                $"User email: {Email}\n" +
                $"User role: {Role}\n" +
                $"User ID: {Id}");
        }

        #endregion


    }
}
