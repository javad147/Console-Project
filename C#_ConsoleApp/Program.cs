using Controllers.Controller;
using System;

namespace CourseApp
{
    class Program
    {
        static void Main()
        {
            GroupServices groupServices = new GroupServices();
            GroupController groupController = new GroupController(groupServices);

            StudentService studentService = new StudentService();
            StudentController studentController = new StudentController(studentService);

            UserService userService = new UserService(groupController);
            UserController userController = new UserController(userService);

            userService.MainMenu();
        }
    }
}
