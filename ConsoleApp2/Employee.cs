namespace ConsoleApp2;

public record Employee(string Name)
{
    public Employee(string name, string surname, DateTime dateOfBirth, decimal salary) : this(name)
    {
        Surname = surname;
        DateOfBirth = dateOfBirth;
        Salary = salary;
    }
    public string? Surname {get; set;}
    public DateTime DateOfBirth { get; set; }
    public int Age => DateTime.Now.Year - DateOfBirth.Year;
    public decimal Salary {get; set;}
   private Employee() : this(string.Empty, string.Empty, default, default) { }

   public static Employee Empty { get; } = new();
   
   public void CalculateSalaryForPeriod(DateTime startDate, DateTime endDate)
   {
       var days = (endDate - startDate).Days;
       //примитивная формула расчета зп: зп за месяц делится на 22 рабочих дня в среднем и умножается на количество отработанных дней
       //изначально считаем что все дни в промежутке дат сотрудник отработал
       var salaryForPeriod = Salary / 22 * days;
       Console.WriteLine($"Зарплата с {startDate} по {endDate} составила: {salaryForPeriod}");
   }
}