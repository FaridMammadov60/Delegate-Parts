using Delegate_Part2ConsoleApp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        public const string Email_Pattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";

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

                if (isEmail(value))
                {
                    _email = value;
                }
                else
                {
                E1: Console.Write("Email düzgün daxil edilməmişdir bir daha cəhd edin: ");
                    string em=Console.ReadLine();
                    if (isEmail(em))
                    {
                        _email = em;
                        return;
                    }
                    goto E1;
                }
                
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
        public bool isEmail( string email)
        {
            Match emailResult = Regex.Match(email, Email_Pattern);
            if (emailResult.Success)
            {
                return true;
            }                
            return false;
        }
        #endregion


    }
}
