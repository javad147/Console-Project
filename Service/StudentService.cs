using Service.Helpers.Constant;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text.RegularExpressions;

public class StudentService
{
    private List<Student> Students { get; } = new List<Student>();
    private List<Group> Groups { get; }
    public StudentService(List<Group> groups)
    {
        Groups = groups;
    }
    public void CreateStudent()
    {
        Console.WriteLine(Message.FullName);
        string fullName = Console.ReadLine();

        Console.WriteLine(Message.StudentAddress);
        string address = Console.ReadLine();

        int age = GetValidAge();

        string phone = GetValidPhoneNumber();

        int groupId = GetValidGroupId();

        Group studentGroup = Groups.Find(m => m.ID == groupId);

        if (studentGroup != null)
        {
            if (studentGroup.Capacity > Students.Count(m => m.Group == studentGroup))
            {
                Student newStudent = new Student(Students.Count + 1, fullName, address, age, phone, studentGroup);
                Students.Add(newStudent);

                Console.WriteLine(Message.StudentCreated);
            }
            else
            {
                Console.WriteLine(Message.CapacityFull);
            }
        }
        else
        {
            Console.WriteLine(Message.GroupNotFound);
        }
    }
    public void DeleteStudent()
    {
        Console.WriteLine(Message.DeleteFullName);
        string studentName = Console.ReadLine();

        Student studentToDelete = Students.Find(s => s.FullName == studentName);

        if (studentToDelete != null)
        {
            Students.Remove(studentToDelete);
            Console.WriteLine(Message.StudentDeleted);
        }
        else
        {
            Console.WriteLine(Message.StudentNotFound);
        }
    }
    public void EditStudent()
    {
        Console.WriteLine(Message.FullNameEdit);
        string studentName = Console.ReadLine();

        Student studentToEdit = Students.Find(s => s.FullName == studentName);

        if (studentToEdit != null)
        {
            Console.WriteLine(Message.FullNameEnter);
            studentToEdit.FullName = GetValidFullName();

            Console.WriteLine(Message.AddressAdd);
            studentToEdit.Address = Console.ReadLine();

            int newAge = GetValidAge();
            studentToEdit.Age = newAge;

            Console.WriteLine(Message.AddPhone);
            studentToEdit.Phone = GetValidPhoneNumber();

            Console.WriteLine(Message.GroupIDStudent);
            int newGroupId = GetValidGroupId();
            Group newStudentGroup = Groups.Find(g => g.ID == newGroupId);

            if (newStudentGroup != null)
            {
                studentToEdit.Group = newStudentGroup;
                Console.WriteLine(Message.StudentEdit);
            }
            else
            {
                Console.WriteLine(Message.NewGroupNotFound);
            }
        }
        else
        {
            Console.WriteLine(Message.NotFoundStudent);
        }
    }
    public void GetAllStudents()
    {
        List<Student> sortedStudents = Students.OrderBy(s => s.ID).ToList();

        foreach (var student in sortedStudents)
        {
            Console.WriteLine($"Student ID: {student.ID}, Full Name: {student.FullName}, Address: {student.Address}, Age: {student.Age}, Phone: {FormatPhoneNumber(student.Phone)}, Group: {student.Group.Name}");
        }
    }
    public void FilterStudents()
    {
        Console.WriteLine(Message.GroupIdFilter);
        int groupId = GetValidGroupId();

        Group studentGroup = Groups.Find(g => g.ID == groupId);

        if (studentGroup != null)
        {
            List<Student> filteredStudents = Students.Where(s => s.Group == studentGroup).OrderBy(s => s.Age).ToList();

            if (filteredStudents.Any())
            {
                foreach (var student in filteredStudents)
                {
                    Console.WriteLine($"Student ID: {student.ID}, Full Name: {student.FullName}, Address: {student.Address}, Age: {student.Age}, Phone: {FormatPhoneNumber(student.Phone)}, Group: {student.Group.Name}");
                }
            }
            else
            {
                Console.WriteLine(Message.NotFoundStudentGroup);
            }
        }
        else
        {
            Console.WriteLine(Message.GroupNotFounfStuFilter);
        }
    }
    public void SearchStudents()
    {
        Console.WriteLine(Message.FullNameSearch);
        string studentName = Console.ReadLine();

        List<Student> searchResults = Students
            .Where(s => s.FullName.StartsWith(studentName, StringComparison.OrdinalIgnoreCase))
            .OrderBy(s => s.Age)
            .ToList();

        if (searchResults.Any())
        {
            foreach (var student in searchResults)
            {
                Console.WriteLine($"Student ID: {student.ID}, Full Name: {student.FullName}, Address: {student.Address}, Age: {student.Age}, Phone: {FormatPhoneNumber(student.Phone)}, Group: {student.Group.Name}");
            }
        }
        else
        {
            Console.WriteLine(Message.NoStudent);
        }
    }
    public void GetById()
    {
        Console.WriteLine(Message.StudentID);
        int studentId = GetValidStudentId();

        Student student = GetStudentById(studentId);

        if (student != null)
        {
            Console.WriteLine($"Student ID: {student.ID}, Full Name: {student.FullName}, Address: {student.Address}, Age: {student.Age}, Phone: {FormatPhoneNumber(student.Phone)}, Group: {student.Group.Name}");
        }
        else
        {
            Console.WriteLine(Message.NotFoundStudent);
        }
    }
    private Student GetStudentById(int studentId)
    {
        return Students.FirstOrDefault(s => s.ID == studentId);
    }
    private int GetValidStudentId()
    {
        int studentId;

        do
        {
            Console.WriteLine(Message.StudentIDEnter);

            if (!int.TryParse(Console.ReadLine(), out studentId) || studentId <= 0)
            {
                Console.WriteLine(Message.InvalidIDStudent);
            }

        } while (studentId <= 0);

        return studentId;
    }
    private int GetValidAge()
    {
        int age;

        do
        {
            Console.WriteLine(Message.StudentAge);

            if (!int.TryParse(Console.ReadLine(), out age) || age < 18 || age > 65)
            {
                Console.WriteLine(Message.StudentAgeInvalid);
            }

        } while (age < 18 || age > 65);

        return age;
    }
    private int GetValidGroupId()
    {
        int groupId;

        do
        {
            Console.WriteLine(Message.GroupId);

            if (!int.TryParse(Console.ReadLine(), out groupId) || groupId <= 0)
            {
                Console.WriteLine(Message.GroupIdInvalid);
            }

        } while (groupId <= 0);

        return groupId;
    }
    private string GetValidFullName()
    {
        string fullName;

        do
        {
            Console.WriteLine(Message.StudentFullName);
            fullName = Console.ReadLine();

            if (!IsValidFullName(fullName))
            {
                Console.WriteLine(Message.StudentFullNameLetters);
            }

        } while (!IsValidFullName(fullName));

        return fullName;
    }
    private bool IsValidFullName(string fullName)
    {
        return !Regex.IsMatch(fullName, @"[^a-zA-Z0-9\s]");
    }
    private bool IsValidPhoneNumber(string phone)
    {
        return Regex.IsMatch(phone, @"^\d{2}\s\d{3}\s\d{2}\s\d{2}$");
    }
    private string GetValidPhoneNumber()
    {
        string phone;

        do
        {
            Console.WriteLine(Message.PhoneNumber);
            phone = Console.ReadLine();

            if (!IsValidPhoneNumber(phone))
            {
                Console.WriteLine(Message.InvalidPhoneNumber);
            }

        } while (!IsValidPhoneNumber(phone));

        return FormatPhoneNumber(phone);
    }
    private string FormatPhoneNumber(string phone)
    {
        string sanitizedPhone = phone.Replace(" ", "");

        if (Regex.IsMatch(sanitizedPhone, @"^\d{9}$"))
        {
            return $"+994 {sanitizedPhone.Substring(0, 2)} {sanitizedPhone.Substring(2, 3)} {sanitizedPhone.Substring(5, 2)}";
        }
        else
        {
            return phone;
        }
    }











}
