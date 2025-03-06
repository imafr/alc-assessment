using ALCAssessment.Entities;

namespace ALCAssessment.Services;

public class EmployeeService
{
    readonly IEnumerable<EmployeeEntity> _employees =
    [
        new () { EmployeeId = 1, EmployeeName = "Chahat Malhotra", Department = "HR", Salary = 50000.560m },
        new () { EmployeeId = 2, EmployeeName = "Nikhil Gowsami", Department = "IT", Salary = 60000.890m },
        new () { EmployeeId = 3, EmployeeName = "Sachin Dev", Department = "IT", Salary = 70000.485m },
        new () { EmployeeId = 4, EmployeeName = "Praveen Murty", Department = "HR", Salary = 55000.890m }
    ];

    public IEnumerable<EmployeeEntity> GetEmployeesInDepartment(string department)
    {
        var employees = _employees
                            .Where(e => e.Department == department)
                            .ToList();

        // var employees = (from emp in _employees
        //                where emp.Department == department
        //                select emp).ToList();

        return employees;
    }

    public decimal GetAverageSalaryOfDepartment(string department)
    {
        decimal avgSalary = _employees
            .Where(x => x.Department == department)
            .Average(e => e.Salary);

        //avgSalary = (from emp in _employees
        //             where emp.Department == department
        //             select emp.Salary)
        //                     .Average();

        return avgSalary;
    }

    public decimal GetMaxSalaryInDepartment(string department)
    {
        //decimal maxSalary = _employees
        //    .Where(e => e.Department == department)
        //    .MaxBy(x=> x.Salary).Salary;


        return
            (from emp in _employees
             where emp.Department == department
             orderby emp.Salary descending
             select emp.Salary)
            .FirstOrDefault();

        //(from emp in _employees
        //where emp.Department == department
        //select emp)
        //.MaxBy(y => y.Salary)
        //.Salary;
    }

    private Dictionary<string, decimal> GetAverageSalaryOfDepartments()
    {
        var averageSalaries = _employees
                                .GroupBy(e => e.Department)
                                .ToDictionary(g => g.Key, g => g.Average(e => e.Salary));

        // var averageSalaries = (from emp in _employees
        //                       group emp by emp.Department into grp
        //                       select new { Department = grp.Key, AverageSalary = grp.Average(e => e.Salary) })
        //                      .ToDictionary(x => x.Department, x => x.AverageSalary);

        return averageSalaries;
    }
}