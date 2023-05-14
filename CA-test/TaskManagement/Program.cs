using System.Collections;
using TaskManagement.Client.Commands;
using TaskManagement.Common.Commands;
using TaskManagement.Database;
using TaskManagement.Database.Models;
using TaskManagement.Database.Repositories;
using TaskManagement.Infrastructure;
using TaskManagement.Services;

namespace TaskManagement
{
    public class Program
    {

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Welcome to C# intro project");
                Console.WriteLine();
                Console.WriteLine("/register");
                Console.WriteLine("/login");
                Console.WriteLine("/update-language");
                Console.WriteLine("/show-blogs-with-comments");
                Console.WriteLine("/exit");
                Console.Write("Pls enter the command:");
                string command = Console.ReadLine()!;
                switch (command)
                {
                    case "/register":
                        CommandRouter.Route<RegisterCommand>();
                        break;
                    case "/login":
                        CommandRouter.Route<LoginCommand>();
                        break;
                    case "/update-language":
                        CommandRouter.Route<UpdateLanguageCommand>();
                        break;
                    case "/show-blogs-with-comments":
                        CommandRouter.Route<ShowBlogswithComments>();
                        break;
                    case "/exit":
                        Console.WriteLine("Bye-bye");
                        return;
                    default:
                        Console.WriteLine("Invalid command, pls try again");
                        break;
                }
            }
        }
    }
}
