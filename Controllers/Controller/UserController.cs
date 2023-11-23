namespace CourseApp
{
    public class UserController
    {
        private UserService userService;

        public UserController(UserService userService)
        {
            this.userService = userService;
        }

        public void ProcessMenuOption(int option)
        {
            switch (option)
            {
                case 1:
                    userService.Register();
                    break;
                case 2:
                    userService.Login();
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}