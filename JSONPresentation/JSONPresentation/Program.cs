using System;
using System.Collections.Generic;
using System.Text.Json;

namespace JSONPresentation
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstUser = new User("Petrov", "Petr", 20, 'M', "Amdinistrator");
            var secondUser = new User("Petrova", "Oksana", 21, 'F', "Trainer");

            var users = new List<User>();
            users.Add(firstUser);
            users.Add(secondUser);

            var serializedUser = JsonSerializer.Serialize(firstUser);
            var deserializedUser = JsonSerializer.Deserialize<User>(serializedUser);
            Console.WriteLine($"JSON format\n {serializedUser}");

            WriteOutUser(deserializedUser);

            serializedUser = JsonSerializer.Serialize(users);
            var deserializedUsers = JsonSerializer.Deserialize<List<User>>(serializedUser);
            Console.WriteLine($"JSON format for list of objects\n {serializedUser}");

            WriteOutUsersList(deserializedUsers);
        }

        public static void WriteOutUser(User user)
        {
            Console.WriteLine($"Not a JSON format\n" +
                $"Last name : {user.LastName}\n" +
                $"Name : {user.Name}\n" +
                $"Gender : {user.Gender}\n" +
                $"Age : {user.Age}\n" +
                $"Role : {user.Role}\n");
        }

        public static void WriteOutUsersList(List<User> users)
        {
            foreach (var user in users)
            {
                Console.WriteLine($"Not a JSON format\n" +
                $"Last name : {user.LastName}\n" +
                $"Name : {user.Name}\n" +
                $"Gender : {user.Gender}\n" +
                $"Age : {user.Age}\n" +
                $"Role : {user.Role}");
            }
            
        }
    }
}
