using Service.Helpers.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class UserService
{
    public List<User> Users { get; set; } = new List<User>();
    public void Register()
    {
        Console.Write(Message.UserName);
        string name = Console.ReadLine();

        Console.Write(Message.UserSurname);
        string surname = Console.ReadLine();

        if (!IsValidName(name) || !IsValidName(surname))
        {
            Console.WriteLine(Message.InvalidNameOrSurname);
            return;
        }

        int age;
        while (!TryReadInt(Message.UserAge, out age) || age < 18 || age > 65) ;

        string email = ReadValidInput(Message.UserEmail, IsValidEmail);

        string password = ReadValidInput(Message.UserPassword, s => s.Length >= 8);

        string confirmPassword;
        do
        {
            confirmPassword = ReadValidInput(Message.ConfirmPassword, s => s == password);
            if (confirmPassword != password)
            {
                Console.WriteLine(Message.PasswordDoNotMatch);
            }
        } while (confirmPassword != password);

        User newUser = new User(Users.Count + 1, name, surname, age, email, password);
        Users.Add(newUser);

        Console.WriteLine(Message.RegistrationSuccessful);
    }
    public void Login(ref User currentUser)
    {
        string email = ReadInput(Message.EnterEmail);
        if (email.ToLower() == "exit")
        {
            return;
        }

        string password = ReadInput(Message.EnterPassword);
        if (password.ToLower() == "exit")
        {
            return;
        }

        currentUser = Users.Find(u => u.Email == email && u.Password == password);

        Console.WriteLine(currentUser != null ? Message.LoginSuccessful : Message.InvalidEmailPassword);
    }
    private bool IsValidName(string input) => !string.IsNullOrWhiteSpace(input) && !Regex.IsMatch(input, "[^a-zA-Z]");
    public static bool IsValidEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            return false;

        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }
    private static bool TryReadInt(string message, out int result)
    {
        Console.Write(message);
        return int.TryParse(Console.ReadLine(), out result);
    }
    private string ReadInput(string message)
    {
        Console.Write(message);
        return Console.ReadLine();
    }
    private string ReadValidInput(string message, Func<string, bool> validation)
    {
        string input;
        do
        {
            input = ReadInput(message);
        } while (!validation(input));
        return input;
    }
}
