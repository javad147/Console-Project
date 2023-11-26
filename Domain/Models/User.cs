public class User : BaseEntity
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public int Age { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public User(int id, string name, string surname, int age, string email, string password)
    {
        ID = id;
        Name = name;
        Surname = surname;
        Age = age;
        Email = email.ToLower();
        Password = password;
    }
}
