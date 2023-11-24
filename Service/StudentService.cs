using C__ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

public class StudentService
{
    private List<Student> students;

    public StudentService()
    {
        students = new List<Student>();
    }

    public void Create(Student s)
    {
        s.ID = GenId();
        students.Add(s);
        Console.WriteLine($"Student created with ID {s.ID}");
    }

    public void Delete(int id)
    {
        Student s = students.FirstOrDefault(st => st.ID == id);
        if (s != null)
        {
            students.Remove(s);
            Console.WriteLine($"Student with ID {id} deleted.");
        }
        else
        {
            Console.WriteLine($"Student with ID {id} not found.");
        }
    }

    public void Edit(int id, Student us)
    {
        Student s = students.FirstOrDefault(st => st.ID == id);
        if (s != null)
        {
            s.FullName = us.FullName;
            s.Address = us.Address;
            s.Age = us.Age;
            s.Phone = us.Phone;

            Console.WriteLine($"Student with ID {id} updated.");
        }
        else
        {
            Console.WriteLine($"Student with ID {id} not found.");
        }
    }

    public Student GetById(int id) => students.FirstOrDefault(s => s.ID == id);

    public List<Student> GetALL() => students;

    public List<Student> Filter(string kw) => students.Where(s => s.FullName.Contains(kw, StringComparison.OrdinalIgnoreCase)).ToList();

    public List<Student> Search() => students.OrderBy(s => s.Age).ToList();

    private int GenId() => students.Count + 1;
}

