using System.Linq.Expressions;
using System.Net.NetworkInformation;

namespace sofia
{
    public class User 
    { 
        private string Login;
        private string Password;
        public User(string login, string password)
        {
            this.Login = login;
           this.Password = password;
        }
        public string GetLogin()
        {
            return Login;
        }
        public string GetPassword()
        {
            return Password;
        }
    }

    internal class Programm
    {
        static List<User> users = new List<User>();
        static void Main(string[] args)
        {
            users.Add(new User("admin", "12345"));
            users.Add(new User("client", "54321"));
            users.Add(new User("student", "123123"));
            int choose;
            while (true)
            {
                Console.WriteLine("Выберите опцию: 1 - авторизация, 2 - регистрация");
                try
                {
                    choose = int.Parse(Console.ReadLine());
                    string log;
                    string pas;
                    switch (choose)
                    {
                        case 1:
                            Console.Write("Введите логин: ");
                            log = Console.ReadLine();
                            Console.Write("Введите пароль: ");
                            pas = Console.ReadLine();
                            Autorization(log, pas);
                            break;
                        case 2:
                            Console.Write("Введите логин: ");
                            log = Console.ReadLine();
                            Console.Write("Введите пароль: ");
                            pas = Console.ReadLine();
                            Registration(log, pas);
                            break;

                        default:
                            Console.WriteLine("Неверные данные");
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Неверный ввод данных" + e.Message);
                }
            }
        }
        private static void Registration(string login, string Password)
        {
            users.Add(new User(login, Password));
        }
        private static void Autorization(string login, string password)
        {
            foreach (var item in users)
            {
                if (item.GetLogin() == login)
                {
                    if (item.GetPassword() == password)
                    {
                        Console.WriteLine("Успешный вход в аккаунт");
                    }
                    else
                    {
                        Console.WriteLine("Неверный пароль");
                    }
                }
                else
                {
                    Console.WriteLine("Такого аккаунта не существует");
                }
            }
        }
    }
        
}
