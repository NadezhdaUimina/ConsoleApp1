using ConsoleApp2;

var cts = new CancellationTokenSource();
var ct = cts.Token;
IEmployeeRepository employeeRepository = new PrimitiveEmployeeRepository();

while (!ct.IsCancellationRequested)
{
    Console.WriteLine(ConsoleOutput.Menu);
    var command = Extensions.Insert<int>(i => i is 1 or 2 or 3 or 4 or 5 or 6 or 0);

    switch (command)
    {
        case 0:
            cts.Cancel();
            break;
        case 1:
            CreateEmployee();
            break;
        case 2:
            foreach (var employee in employeeRepository.GetAll())
                Console.WriteLine(employee);
            break;
        case 3:
            FindEmployee();
            break;
        case 4:
            employeeRepository.UpdateEmployee(Employee.Empty);
            break;
        case 5:
            employeeRepository.DeleteEmployee();
            break;
        case 6:
            CalculateSalary();
            break;
    }
    Console.WriteLine("Press any key to clear console and return to menu");
    Console.ReadKey();
    Console.Clear();
}

return;

void CreateEmployee()
{
    Console.WriteLine("Введите имя:");
    var name = Console.ReadLine() ?? $"User-{Random.Shared.Next()}";
    
    Console.WriteLine("Введите фамилию:");
    var surname = Console.ReadLine();
    
    Console.WriteLine("Введите дату рождения в формате уууу/мм/dd:");
    var age = Extensions.Insert<DateTime>(i => i < DateTime.Today && i <= DateTime.Today.AddYears(-18) && i >= DateTime.Today.AddYears(-65));
    
    Console.WriteLine("Введите з/п:");
    var salary = Extensions.Insert<decimal>(_=> true);

    var employee = new Employee(name, surname, age, salary);
    employeeRepository.AddEmployee(employee);
}

void FindEmployee()
{
    var foundEmployee = employeeRepository.FindEmployee();
    if (foundEmployee.Equals(Employee.Empty))
        Console.WriteLine("Сотрудник не найден");
    else
        Console.WriteLine(foundEmployee);
}

void CalculateSalary()
{
    var findEmployee = employeeRepository.FindEmployee();
            
    Console.WriteLine("Введите начальную дату в формате уууу/мм/dd:");
    var startDate = Extensions.Insert<DateTime>(_ => true);

    Console.WriteLine("Введите конечную дату в формате уууу/мм/dd:");
    var endDate = Extensions.Insert<DateTime>(end => end > startDate);

    findEmployee.CalculateSalaryForPeriod(startDate, endDate);
}