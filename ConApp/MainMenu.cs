using BusinessLayer;
using DomainLayer;
using DomainLayer.Enums;
using System;

namespace ConApp
{
    public class MainMenu
    {
        private Authentication _authentication;
        private UserModule _userModule;
        public MainMenu()
        {
            _authentication = new Authentication();
            _userModule = new UserModule();
        }

        // Menu is the starting menu of the console application
        internal void Menu()
        {
            do
            {
                Console.Write("\n" + StringLiterals._mainMenu);
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        Login();
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        Register();
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        return;
                    default:
                        Console.WriteLine(StringLiterals._invalidField);
                        break;
                }
            }while(true);
        }

        // login method takes email and password and validates them
        // if login details are true then it goes to HomeMenu
        private void Login()
        {
            Console.WriteLine("\n" + StringLiterals._email);
            string email = Console.ReadLine();
            if (!Validations.ValidateEmail(email))
            {
                Console.WriteLine(StringLiterals._invalidField);
                return;
            }
            Console.WriteLine(StringLiterals._password);
            Console.ForegroundColor = ConsoleColor.Black;
            string password = Console.ReadLine();
            Console.ResetColor();
            if (!Validations.ValidatePassword(password))
            {
                Console.WriteLine(StringLiterals._invalidField);
            }
            else if (_authentication.Login(email, password))
            {
                HomeMenu();
            }
            else
            {
                Console.WriteLine(StringLiterals._invalidCredentials);
            }
        }

        //HomeMenu takes input from user and shows them appropriate users
        private void HomeMenu()
        {
            int choice;
            do
            {
                Console.Write("\n" + StringLiterals._homeMenu);
                choice = Convert.ToInt32(Console.ReadKey().KeyChar.ToString());
                if (choice == 1 || choice == 2 || choice == 3)
                {
                    _userModule.GetUserDetails((UserRoleChoiceEnum)choice);
                }
                else if (choice == 4)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\n" + StringLiterals._invalidField);
                }
            } while (choice != 4);
        }

        //register takes values from user and registers the values
        private void Register()
        {
            do
            {
                Console.Write("\n" + StringLiterals._firstName);
                string firstName = Console.ReadLine();
                if(!Validations.ValidateName(firstName))
                {
                    Console.WriteLine(StringLiterals._invalidField);
                    continue;
                }
                Console.Write(StringLiterals._lastName);
                string lastName = Console.ReadLine();
                if (!Validations.ValidateName(lastName))
                {
                    Console.WriteLine(StringLiterals._invalidField);
                    continue;
                }
                bool isStudent;
                Console.WriteLine(StringLiterals._userType);
                ConsoleKey choice = Console.ReadKey().Key;
                if (choice == ConsoleKey.Y)
                {
                    isStudent = true;
                }
                else if (choice == ConsoleKey.N)
                {
                    isStudent = false;
                }
                else
                {
                    Console.WriteLine("\n" + StringLiterals._invalidField);
                    continue;
                }
                Console.Write("\n" + StringLiterals._email);
                string email = Console.ReadLine();
                if (!Validations.ValidateEmail(email))
                {
                    Console.WriteLine(StringLiterals._invalidField);
                    continue;
                }
                Console.Write(StringLiterals._password);
                Console.ForegroundColor = ConsoleColor.Black;
                string password = Console.ReadLine();
                Console.ResetColor();
                if (!Validations.ValidatePassword(password))
                {
                    Console.WriteLine(StringLiterals._invalidField);
                    continue;
                }
                if (_authentication.Register(email, password, firstName, lastName, isStudent))
                {
                    Console.WriteLine(StringLiterals._registerSuccess);
                    break;
                }
                else
                {
                    Console.WriteLine(StringLiterals._registerFailed);
                }
            } while (true);
        }
    }
}
