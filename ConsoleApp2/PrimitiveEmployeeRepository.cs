namespace ConsoleApp2;

public class PrimitiveEmployeeRepository : IEmployeeRepository
{
    private readonly HashSet<Employee> _hashMap = new();
    
    public void AddEmployee(Employee employee)
    {
        _hashMap.Add(employee);
        Console.WriteLine($"employee - {employee} created");
    }

    public IEnumerable<Employee> GetAll()
    {
        return _hashMap;
    }

    public Employee FindEmployee()
    {
        try
        {
            Console.WriteLine("Введите имя");
            var name = Console.ReadLine() ?? throw new Exception();
            var employee = _hashMap.FirstOrDefault(x => x.Name.Equals(name));
            return employee ?? Employee.Empty;
        }
        catch (Exception)
        {
            return FindEmployee();
        }
    }

    public void UpdateEmployee(Employee _)
    {
        var employee = FindEmployee();
        if (Employee.Empty.Equals(employee))
        {
            Console.WriteLine("Сотрудник не найден. Нажмите любую клавишу для выхода в меню");
            Console.ReadKey();
            return;
        }

        var isCompleted = false;
        while (!isCompleted)
        {
            Console.WriteLine(ConsoleOutput.UpdateMenu);
            var command = Extensions.Insert<int>(com => com is 0 or 1 or 2 or 3);
            switch (command)
            {
                case 0:
                    isCompleted = true;
                    break;
                case 1:
                    Console.WriteLine("Введите фамилию:");
                    employee.Surname = Console.ReadLine();
                    break;
                case 2:
                    Console.WriteLine("Введите дату рождения в формате уууу/мм/dd:");
                    employee.DateOfBirth = Extensions.Insert<DateTime>(i =>
                        i < DateTime.Today && i <= DateTime.Today.AddYears(-18) && i >= DateTime.Today.AddYears(-65));
                    break;
                case 3:
                    Console.WriteLine("Введите зп:");
                    employee.Salary = Extensions.Insert<decimal>(_ => true);
                    break;
            }
        }
    }
    
    public void DeleteEmployee()
    {
        var employee = FindEmployee();
        _hashMap.Remove(employee);
    }
}