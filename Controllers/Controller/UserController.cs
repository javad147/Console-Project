using C__ConsoleApp.Models;
using Controllers.Controller;

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
            }

            public void Register()
            {
                Console.WriteLine("Registration");

                users.Add(new User { Name = "John", Surname = "Doe", Age = 25, Email = "john@example.com", Password = "password" });

                Console.WriteLine("Registration successful. Please log in.");
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

                if (currentUser != null)
                {
                    Console.WriteLine("Login successful. Welcome, " + currentUser.Name + "!");
                    DisplayMainMenu();
                    return;
                }

                Console.WriteLine("Invalid email or password. Please try again.");
                incorrectAttempts++;
            }

            Console.WriteLine("You have reached the maximum number of incorrect attempts. Returning to the main menu.");
            MainMenu();
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

            private void DisplayMainMenu()
            {
                Console.WriteLine("Welcome to our application");

                while (true)
                {
                    Console.WriteLine("Please select one option:");
                    Console.WriteLine("1 - Group Operations");
                    Console.WriteLine("2 - Student Operations");
                    Console.WriteLine("3 - Exit");

                    int choice = GetChoice(3);

                    switch (choice)
                    {
                        case 1:
                            groupController.StartApplication();
                            break;
                        case 2:
                            studentController.Run();
                            break;
                        case 3:
                            Environment.Exit(0);
                            break;
                    }
                }
            }



    }
}



