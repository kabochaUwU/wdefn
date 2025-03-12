using Newtonsoft.Json;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Security.Cryptography.X509Certificates;

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
        int choose;
        while (true)
        {
            Console.WriteLine("Choose: 1 - Autorization, 2 - Registration");
            try
            {
                choose = int.Parse(Console.ReadLine());
                string log;
                string pas;
                switch (choose)
                {
                    case 1:
                        Console.Write("Login: ");
                        log = Console.ReadLine();
                        Console.Write("Password: ");
                        pas = "";
                        ConsoleKeyInfo key;
                        do
                        {
                            key = Console.ReadKey(true);
                            if (key.Key != ConsoleKey.Enter & key.Key != ConsoleKey.Backspace)
                            {
                                pas = pas + key.KeyChar;
                                Console.Write("*");
                            }
                            if (key.Key == ConsoleKey.Backspace & pas.Length != 0)
                            {
                                pas = pas.Substring(0, pas.Length - 1);
                                Console.Write("\b \b");
                            }
                        } while (key.Key != ConsoleKey.Enter);
                        Console.WriteLine("");
                        Autorization(log, pas);
                        break;
                    case 2:
                        Console.Write("Login: ");
                        log = Console.ReadLine();
                        Console.Write("Password: ");
                        pas = Console.ReadLine();
                        Registration(log, pas);
                        break;
                    default:
                        Console.WriteLine("Wrong data");
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Wrong data input: " + e.Message);
            }
            Console.WriteLine("Press any key to continue . . .");
            Console.ReadKey();
            Console.Clear();
        }
    }
    private static void Registration(string login, string Password)
    {
        users.Add(new User(login, Password));
        Console.WriteLine();
        Save();
    }
    private static void Autorization(string login, string password)
    {
        bool exists = false;
        foreach (var item in users)
        {
            if (item.GetLogin() == login)
            {
                if (item.GetPassword() == password)
                {
                    Console.WriteLine("Success");
                    exists = true;
                    break;
                }
                else
                {
            Console.WriteLine("Wrong password");
                    exists = true;
                    break;
                }
            }
        }
        if (exists == false)
        {
            Console.WriteLine("Account doesn't exist");
        }
    }
    private static void Save()
    {
        string path = @"B:\TestDirectory\database.json";
        var database = new
        {
            data = users
        };
        if (File.Exists(path) == false)
        {
            File.Create(path);
        }
        string json = JsonConvert.SerializeObject(users, Formatting.Indented);
        StreamWriter streamWriter = new StreamWriter(path);
        streamWriter.Write(json);
        streamWriter.Close();
    }
}
