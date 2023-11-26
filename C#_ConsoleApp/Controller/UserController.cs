using System;

public class UserController
{
    private UserService userService;

    public UserController(UserService userService)
    {
        this.userService = userService;
    }

    public void Register()
    {
        userService.Register();
    }

    public void Login(ref User currentUser)
    {
        userService.Login(ref currentUser);
    }
}
