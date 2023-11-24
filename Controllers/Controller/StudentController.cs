using C__ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers.Controller
{
    public class StudentController
    {


        private readonly StudentService studentService;

        private List<Student> students;
        public StudentService()
        {
            students = new List<Student>();
        }

        public StudentController(StudentService studentService)
            {
                this.studentService = studentService;
            }

            public void Run()
            {
                Console.WriteLine("Student operations: 8-Create, 9-Delete, 10-Edit, 11-GetById, 12-GetAll, 13-Filter, 14-Search");

                while (true)
                {
                    Console.Write("Enter operation number (or '0' to exit): ");
                    if (!int.TryParse(Console.ReadLine(), out int operation))
                    {
                        Console.WriteLine("Invalid input. Please enter a number.");
                        continue;
                    }

                    if (operation == 0)
                    {
                        Console.WriteLine("Exiting the program...");
                        break;
                    }

                    PerformOperation(operation);
                }
            }

            private void PerformOperation(int operation)
            {
                switch (operation)
                {
                    case 8:
                        CreateStudent();
                        break;
                    case 9:
                        DeleteStudent();
                        break;
                    case 10:
                        EditStudent();
                        break;
                    case 11:
                        GetById();
                        break;
                    case 12:
                        GetAll();
                        break;
                    case 13:
                        FilterByAge();
                        break;
                    case 14:
                        SearchByName();
                        break;
                    default:
                        Console.WriteLine("Invalid operation number. Please try again.");
                        break;
                }
            }

            private void CreateStudent()
            {
                Console.Write("Enter Full Name: ");
                string fullName = Console.ReadLine();

                Console.Write("Enter Address: ");
                string address = Console.ReadLine();

                Console.Write("Enter Age: ");
                if (!int.TryParse(Console.ReadLine(), out int age))
                {
                    Console.WriteLine("Invalid age. Please enter a valid number.");
                    return;
                }

                Console.Write("Enter Phone: ");
                string phone = Console.ReadLine();

                studentService.Create(new Student { FullName = fullName, Address = address, Age = age, Phone = phone });
                Console.WriteLine("Student created successfully.");
            }

            private void DeleteStudent()
            {
                Console.Write("Enter Student ID to delete: ");
                if (!int.TryParse(Console.ReadLine(), out int id))
                {
                    Console.WriteLine("Invalid ID. Please enter a valid number.");
                    return;
                }

                studentService.Delete(id);
            }

            private void EditStudent()
            {
                Console.Write("Enter Student ID to edit: ");
                if (!int.TryParse(Console.ReadLine(), out int id))
                {
                    Console.WriteLine("Invalid ID. Please enter a valid number.");
                    return;
                }

                Student existingStudent = studentService.G(id);
                if (existingStudent == null)
                {
                    Console.WriteLine($"Student with ID {id} not found.");
                    return;
                }

                Console.Write("Enter New Full Name: ");
                string newFullName = Console.ReadLine();

                Console.Write("Enter New Address: ");
                string newAddress = Console.ReadLine();

                Console.Write("Enter New Age: ");
                if (!int.TryParse(Console.ReadLine(), out int newAge))
                {
                    Console.WriteLine("Invalid age. Please enter a valid number.");
                    return;
                }

                Console.Write("Enter New Phone: ");
                string newPhone = Console.ReadLine();

                studentService.E(id, new Student { FullName = newFullName, Address = newAddress, Age = newAge, Phone = newPhone });
                Console.WriteLine($"Student with ID {id} updated successfully.");
            }

            private void GetById()
            {
                Console.Write("Enter Student ID to get details: ");
                if (!int.TryParse(Console.ReadLine(), out int id))
                {
                    Console.WriteLine("Invalid ID. Please enter a valid number.");
                    return;
                }

                Student student = studentService.G(id);
                if (student != null)
                {
                    Console.WriteLine($"Student Details - ID: {student.ID}, Name: {student.FullName}, Age: {student.Age}");
                }
                else
                {
                    Console.WriteLine($"Student with ID {id} not found.");
                }
            }

            private void GetAll()
            {
                List<Student> students = studentService.GA();
                Console.WriteLine("All Students:");
                foreach (var student in students)
                {
                    Console.WriteLine($"ID: {student.ID}, Name: {student.FullName}, Age: {student.Age}");
                }
            }

            private void FilterByAge()
            {
                List<Student> students = studentService.SB();
                Console.WriteLine("Students Sorted By Age:");
                foreach (var student in students)
                {
                    Console.WriteLine($"ID: {student.ID}, Name: {student.FullName}, Age: {student.Age}");
                }
            }

            private void SearchByName()
            {
                Console.Write("Enter Name to search: ");
                string keyword = Console.ReadLine();

                List<Student> students = studentService.S(keyword);
                Console.WriteLine($"Search Results for '{keyword}':");
                foreach (var student in students)
                {
                    Console.WriteLine($"ID: {student.ID}, Name: {student.FullName}, Age: {student.Age}");
                }
            }



        public void Create(Student student)
        {
            student.ID = GenerateId();
            students.Add(student);
            Console.WriteLine($"Student created with ID {student.ID}");
        }

        public void Delete(int id)
        {
            Student student = students.FirstOrDefault(s => s.ID == id);
            if (student != null)
            {
                students.Remove(student);
                Console.WriteLine($"Student with ID {id} deleted.");
            }
            else
            {
                Console.WriteLine($"Student with ID {id} not found.");
            }
        }

        public void Edit(int id, Student updatedStudent)
        {
            Student student = students.FirstOrDefault(s => s.ID == id);
            if (student != null)
            {
                student.FullName = updatedStudent.FullName;
                student.Address = updatedStudent.Address;
                student.Age = updatedStudent.Age;
                student.Phone = updatedStudent.Phone;

                Console.WriteLine($"Student with ID {id} updated.");
            }
            else
            {
                Console.WriteLine($"Student with ID {id} not found.");
            }
        }

        public Student GetById(int id) => students.FirstOrDefault(s => s.ID == id);

        public List<Student> GetAll() => students;

        public List<Student> Filter(string keyword) => students.Where(s => s.FullName.Contains(keyword, StringComparison.OrdinalIgnoreCase)).ToList();

        public List<Student> SortByAge() => students.OrderBy(s => s.Age).ToList();

        private int GenerateId() => students.Count + 1;


    }
}
