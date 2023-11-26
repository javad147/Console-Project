using Service.Enums;
using System;
using System.Reflection.Emit;

class Program
{
    static UserService userService = new UserService();
    static UserController userController = new UserController(userService);

    static GroupService groupService = new GroupService();
    static GroupController groupController = new GroupController(groupService);

    static StudentService studentService = new StudentService(groupService.Groups);
    static StudentController studentController = new StudentController(studentService);

    static User currentUser;

    static void Main()
    {
        Console.WriteLine("1. Register\n2. Login\n");
        int choice = Convert.ToInt32(Console.ReadLine());

        if (choice == 1)
        {
            userController.Register();
            Main();
        }
        else if (choice == 2)
        {
            userController.Login(ref currentUser);

            if (currentUser != null)
            {
                Console.WriteLine("Welcome to our application");
                DisplayMenu();
            }
            else
            {
                Main();
            }


        }
    }

    static void DisplayMenu()
    {
        while (true)
        {
            Console.WriteLine("Please select one option:");
            Console.WriteLine("Group operations: 1-Create, 2-Delete, 3-Edit, 4-GetAll, 5-Search, 6-Sorting 13-GetById | Student operations : 7-Create, 8-Delete, 9-Edit, 10-GetAll, 11-Search, 12-Filter, 14-GetById");
           

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case (int) OperationType.LogOut :
                    Logout();
                    return;
                case (int)OperationType.Create:
                    groupController.CreateGroup();
                    break;
                case (int) OperationType.Delete:
                    groupController.DeleteGroup();
                    break;
                case (int) OperationType.Edit:
                    groupController.EditGroup();
                    break;
                case (int) OperationType.GetAll:
                    groupController.GetAllGroups();
                    break;
                case (int) OperationType.Search:
                    groupController.SearchGroups();
                    break;
                case (int) OperationType.Sort:
                    groupController.SortingGroups();
                    break;
                case (int)OperationType.CreateStudent:
                    studentController.CreateStudent();
                    break;
                case (int)OperationType.DeleteStudent:
                    studentController.DeleteStudent();
                    break;
                case (int)OperationType.EditStudent:
                    studentController.EditStudent();
                    break;
                case (int)OperationType.GetAllStudent:
                    studentController.GetAllStudents();
                    break;
                case (int)OperationType.FilterStudent:
                    studentController.FilterStudents();
                    break;
                case (int) OperationType.SearchStudent:
                    studentController.SearchStudents();
                    break;
                case (int)OperationType.GetByIdGroup:
                    groupController.GetById();
                    break;
                case (int)OperationType.GetByIdStudent:
                    studentService.GetById();
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }

    static void Logout()
    {
        currentUser = null;
        Console.WriteLine("Logout successful!");
        Main();
    }
}
