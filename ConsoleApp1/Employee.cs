using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConsoleApp1.Employee;

namespace ConsoleApp1
{
    class Employee
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public double Wages { get; set; }  
        
        public Employee(int id, string name, string surName, int weges)
        {
            this.Id = id;
            this.Name = name;
            this.SurName = surName;
            this.Wages = weges;
        }

        public static List<Employee> Employees = new List<Employee>();
        public static int id = 1;

        

    }

    
}
