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
        private GroupController groupController;
        private StudentController studentController;

        public UserService(GroupController groupController, StudentController studentController)
        {
            this.groupController = groupController;
            this.studentController = studentController;
        }

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
            studentController.Run();
        }

        static void Register()
        {
            Console.WriteLine("Enter Name:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter Surname:");
            string surname = Console.ReadLine();

            Console.WriteLine("Enter Age:");
            int age = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Email:");
            string email = Console.ReadLine();

            Console.WriteLine("Enter Password:");
            string password = Console.ReadLine();

            Console.WriteLine("Confirm Password:");
            string confirmPassword = Console.ReadLine();

            if (password != confirmPassword)
            {
                Console.WriteLine("Password and Confirm Password do not match. Registration failed.");
                return;
            }

            User newUser = new User(name, surname, age, email, password);
            users.Add(newUser);

            Console.WriteLine("Registration successful!");
        }

        static void Login()
        {
            Console.WriteLine("Enter Email:");
            string email = Console.ReadLine();

            Console.WriteLine("Enter Password:");
            string password = Console.ReadLine();

            currentUser = users.Find(u => u.Email == email && u.Password == password);

            if (currentUser == null)
            {
                Console.WriteLine("Invalid email or password. Login failed.");
            }
            else
            {
                Console.WriteLine("Login successful!");
            }
        }

        static void Logout()
        {
            currentUser = null;
            Console.WriteLine("Logout successful!");
            Main();
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

        static void DisplayMenu()
        {
            while (true)
            {
                Console.WriteLine("Please select one option:");
                Console.WriteLine("Group operations: 1-Create, 2-Delete, 3-Edit, 4-GetAll, 5-Search, 6-Sorting");
                Console.WriteLine("Student operations: 7-Create, 8-Delete, 9-Edit, 10-GetAll, 11-Filter, 12-Search");
                Console.WriteLine("Logout: 0");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 0:
                        Logout();
                        return;
                    case 1:
                        CreateGroup();
                        break;
                    case 2:
                        DeleteGroup();
                        break;
                    case 3:
                        EditGroup();
                        break;
                    case 4:
                        GetAllGroups();
                        break;
                    case 5:
                        SearchGroups();
                        break;
                    case 6:
                        SortingGroups();
                        break;
                    case 7:
                        CreateStudent();
                        break;
                    case 8:
                        DeleteStudent();
                        break;
                    case 9:
                        EditStudent();
                        break;
                    case 10:
                        GetAllStudents();
                        break;
                    case 11:
                        FilterStudents();
                        break;
                    case 12:
                        SearchStudents();
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }
    }

}


