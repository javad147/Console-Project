public class Student : BaseEntity
{
    public string FullName { get; set; }
    public string Address { get; set; }
    public int Age { get; set; }
    public string Phone { get; set; }
    public Group Group { get; set; }

    public Student(int id, string fullName, string address, int age, string phone, Group group)
    {
        ID = id;
        FullName = fullName;
        Address = address;
        Age = age;
        Phone = phone;
        Group = group;
    }
}
