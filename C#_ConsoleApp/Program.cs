using System;

namespace CourseApp
{
    class Program
    {
        static void Main()
        {
            UserService userService = new UserService();
            UserController userController = new UserController(userService);

            userService.MainMenu();

            GroupServices groupServices = new GroupServices();
            GroupController groupController = new GroupController(groupServices);

            for (int i = 1; i <= 5; i++)
            {
                Group newGroup = new Group
                {
                    Name = $"Group{i}",
                    Capacity = i * 10
                };

                groupServices.CreateGroup(newGroup);
            }

            groupController.StartApplication();
        }
    }
}