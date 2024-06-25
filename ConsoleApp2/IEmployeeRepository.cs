namespace ConsoleApp2;

public interface IEmployeeRepository
{
    Employee FindEmployee();

    void UpdateEmployee(Employee employee);

    void DeleteEmployee();
    void AddEmployee(Employee employee);
    IEnumerable<Employee> GetAll();
}