using Delegate_Part2ConsoleApp.Enums;
using System;
using System.Text;

namespace Delegate_Part2ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding=Encoding.Unicode;
            Console.InputEncoding=Encoding.Unicode;
            
            Console.Write("Username daxil edin: ");
            string userName=Console.ReadLine();
            Console.Write("Email daxil edin: ");
            string email =Console.ReadLine();
            Role role = new Role();
           
            User user = new User("Farid", "Faridmammadov60@gmail.com", role);
            user.ShowInfo();
            
        }
    }
}
