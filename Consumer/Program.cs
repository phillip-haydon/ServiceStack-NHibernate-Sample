using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Contacts;

using ServiceStack.ServiceClient.Web;

namespace Consumer
{
    class Program
    {
        private static string _command = string.Empty;
        private static JsonServiceClient _client = new JsonServiceClient("http://localhost:4644");

        static void Main(string[] args)
        {
            while(_command != "exit" || _command != "e")
            {
                switch (_command.ToLower())
                {
                    case "update":
                    {
                        UpdateCommand();
                        break;       
                    }
                    case "insert":
                    {
                        InsertCommand();
                        break;       
                    }

                    default:
                    {
                        UnknownCommand();
                        break;
                    }
                }
            }

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

        private static void UpdateCommand()
        {
            _client.SendOneWay(new ProductUpdate
            {
                Id = Guid.Parse("66312009-23c0-4b6d-8790-a061000e93e3"),
                Name = "UPDATED",
                Description = "MORE UPDATES!!!"
            });

            Console.WriteLine("Please type a command...");
            _command = Console.ReadLine();
        }

        private static void InsertCommand()
        {
            _client.SendOneWay(new ProductInsert
            {
                Name = "Test",
                Description = "Some description..."
            });

            Console.WriteLine("Please type a command...");
            _command = Console.ReadLine();
        }

        private static void UnknownCommand()
        {
            Console.WriteLine("Command Unknown");
            Console.WriteLine("Please type one of the following commands:");
            Console.WriteLine("select");
            Console.WriteLine("insert");
            Console.WriteLine("update");

            _command = Console.ReadLine();
        }
    }
}
