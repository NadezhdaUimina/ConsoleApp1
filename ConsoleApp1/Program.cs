using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp1
{
    internal class Program
    {
        // добавление сотрудника
        public static void AddEmployee( string name, string surName, int wages)
        {
            var employee = new Employee(Employee.id, name, surName, wages);
            Employee.Employees.Add(employee);
            Console.WriteLine("Сотрудник успешно добавлен в базу");
            Console.WriteLine($"id: {Employee.id}, имя: {name}, фамилия: {surName}, зароботная плата: {wages}");
            Employee.id++;
        }

        // просмотр сотрудноков
        public static void AllEmployees()
        {
            Console.WriteLine("Список всех сотрудников");
            foreach (var item in Employee.Employees)
            {
                Print(item);
            }
        }

        // поиск сотрудника
        public static void SearchEmployee(string name) 
        {
            if (Employee.Employees.Find(e => e.Name.Equals(name)) != null)
            {
                var employee = Employee.Employees.Find(e => e.Name.Equals(name));
                Print(employee);
            } else
            {
                Console.WriteLine($"Сотрудник с именем {name} отсутствует в базе");
            }
            
        }

        // удаление сотрудника
        public static void RemoveEmployee(int id)
        {
            if (CheckId(id)){
                var employee = Employee.Employees.Find(e => e.Id.Equals(id));
                Employee.Employees.Remove(employee);
                Console.WriteLine("Сотрудник удален из базы");
                Print(employee);
            } 
        }

        // изменение имени сотрудника в базе данных
        public static void UpdateName(int id, string updateName)
        {
            foreach (var item in Employee.Employees)
            {
                if (item.Id == id)
                {
                    Console.WriteLine("Данные сотрудника");
                    Print(item);
                    item.Name = updateName;
                    Console.WriteLine("Измененные данные");
                    Print(item);
                }
            }
        }

        // изменение фамилии сотрудника в базе данных
        public static void UpdateSurName(int id, string updateSurName)
        {
            foreach (var item in Employee.Employees)
            {
                if (item.Id == id)
                {
                    Console.WriteLine("Данные сотрудника");
                    Print(item);
                    item.SurName = updateSurName;
                    Console.WriteLine("Измененные данные");
                    Print(item);
                }
            }
        }

        // изменение заработной платы сотрудника в базе данных
        public static void UpdateWages(int id, int updateWages)
        {
            foreach (var item in Employee.Employees)
            {
                if (item.Id == id)
                {
                    Console.WriteLine("Данные сотрудника");
                    Print(item);
                    item.Wages = updateWages;
                    Console.WriteLine("Измененные данные");
                    Print(item);
                }
            }
        }

        // проверка наличия сотрудника в базе по id
        public static bool CheckId (int id)
        {
            var employee = Employee.Employees.Find(e => e.Id.Equals(id));
            if (employee != null)
            {
                return true;
            }
            else
            {
                Console.WriteLine($"Сотрудник с id {id} отсутствует в базе");
                return false;
            }
        }
        // печать
        public static void Print(Employee employee)
        {
            Console.WriteLine($"id: {employee.Id}, имя: {employee.Name}, фамилия: {employee.SurName}, зароботная плата: {employee.Wages}");
        }

    }
}
