using System;

public class StudentController
{
    private StudentService studentService;

    public StudentController(StudentService studentService)
    {
        this.studentService = studentService;
    }

    public void CreateStudent()
    {
        studentService.CreateStudent();
    }

    public void DeleteStudent()
    {
        studentService.DeleteStudent();
    }

    public void EditStudent()
    {
        studentService.EditStudent();
    }

    public void GetAllStudents()
    {
        studentService.GetAllStudents();
    }

    public void FilterStudents()
    {
        studentService.FilterStudents();
    }

    public void SearchStudents()
    {
        studentService.SearchStudents();
    }

    public void GetById() 
    {
        studentService.GetById();
    
    }
}
