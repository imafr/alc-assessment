using ALCAssessment.Dtos.Book.Request;
using ALCAssessment.Entities;
using ALCAssessment.Services;

namespace ALCAssessment;

public class Program
{
    static void Main(string[] args)
    {
        ExecuteLibraryServiceMethods();

        ExecuteEmployeeServiceMethods();
    }

    #region OOPS assessment
    private static void ExecuteLibraryServiceMethods()
    {
        LibraryService library = new();

        library.AddBook(new BookRequestDto
        {
            Title = "The Hobbit",
            Author = "J.R.R. Tolkien",
            ISBN = "978-0-395-07122-1"
        });

        library.AddBook(new BookRequestDto
        {
            Title = "The Lord of the Rings",
            Author = "J.R.R. Tolkien",
            ISBN = "978-0-395-19395-7"
        });

        library.GetBooks();
        library.RemoveBookById(1);
        library.GetBooks();
    }
    #endregion

    #region LINQ assessment
    private static void ExecuteEmployeeServiceMethods()
    {
        EmployeeService employeeService = new();

        string department = "IT";

        IEnumerable<EmployeeEntity> employees = employeeService.GetEmployeesInDepartment(department);

        decimal averageSalary = employeeService.GetAverageSalaryOfDepartment(department);

        decimal maxSalary = employeeService.GetMaxSalaryInDepartment(department);
    }
    #endregion
}
