using C__ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CourseApp
{
    public class UserService
    {
        private List<User> users = new List<User>();
        private User currentUser;

        public void MainMenu()
        {
            Console.WriteLine("Welcome to our application");

            while (true)
            {
                Console.WriteLine("Please select one option:");
                Console.WriteLine("1 - Register");
                Console.WriteLine("2 - Login");
                Console.WriteLine("3 - Exit");

                int choice = GetChoice(3);

                switch (choice)
                {
                    case 1:
                        Register();
                        break;
                    case 2:
                        Login();
                        break;
                    case 3:
                        Environment.Exit(0);
                        break;
                }
            }
        }

        public void Register()
        {
            Console.WriteLine("Registration");

            int incorrectAttempts = 0;

            while (incorrectAttempts < 3)
            {
                Console.Write("Name: ");
                string name = Console.ReadLine();

                Console.Write("Surname: ");
                string surname = Console.ReadLine();

                Console.Write("Age: ");
                int age;
                while (!int.TryParse(Console.ReadLine(), out age) || age <= 0)
                {
                    Console.WriteLine("Invalid age. Please enter a positive integer.");
                }

                Console.Write("Email: ");
                string email = Console.ReadLine();

                if (!email.Contains("@"))
                {
                    Console.WriteLine("Invalid email format. Registration failed.");
                    incorrectAttempts++;
                    continue;
                }

                Console.Write("Password: ");
                string password = Console.ReadLine();

                Console.Write("Confirm Password: ");
                string confirmPassword = Console.ReadLine();

                if (password != confirmPassword)
                {
                    Console.WriteLine("Passwords do not match. Registration failed.");
                    incorrectAttempts++;
                    continue;
                }

                if (users.Any(u => u.Email == email))
                {
                    Console.WriteLine("User with the same email already exists. Registration failed.");
                    incorrectAttempts++;
                    continue;
                }

                users.Add(new User { Name = name, Surname = surname, Age = age, Email = email, Password = password });

                Console.WriteLine("Registration successful. Please select one option:");
                Console.WriteLine("1 - Login");
                Console.WriteLine("2 - Register");

                int choice = GetChoice(2);

                switch (choice)
                {
                    case 1:
                        Login();
                        break;
                    case 2:
                        Register();
                        break;
                }
            }

            Console.WriteLine("You have reached the maximum number of incorrect attempts. Returning to the main menu.");
        }

        public void Login()
        {
            Console.WriteLine("Login");

            int incorrectAttempts = 0;

            while (incorrectAttempts < 3)
            {
                Console.Write("Email: ");
                string email = Console.ReadLine();

                Console.Write("Password: ");
                string password = Console.ReadLine();

                currentUser = users.FirstOrDefault(u => u.Email == email && u.Password == password);

                if (currentUser == null)
                {
                    Console.WriteLine("Invalid email or password. Login failed.");
                    incorrectAttempts++;
                    continue;
                }

                Console.WriteLine("Login successful. Welcome, " + currentUser.Name + "!");

                MainMenu();
                return;
            }

            Console.WriteLine("You have reached the maximum number of incorrect attempts. Returning to the main menu.");
        }

        private int GetChoice(int maxChoice)
        {
            int choice;

            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > maxChoice)
            {
                Console.WriteLine($"Invalid choice. Please enter a number between 1 and {maxChoice}.");
            }

            return choice;
        }
    }
}