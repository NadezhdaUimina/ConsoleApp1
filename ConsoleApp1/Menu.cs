using System;
using ConsoleApp1;

namespace ConsoleApp1
{
    internal class Menu
    {
        static void Main(string[] args)
        {
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Меню \n" +
                    "==================================\n" +
                    "1.Добавить нового сотрудника\n" +         
                    "2.Просмотреть список сотрудников\n" +     
                    "3.Поиск сотрудника по имени\n" +          
                    "4.Обновить данные сотрудника\n" +
                    "5.Удалить сотрудника\n" +                 
                    "6.Рассчет заработной платы\n" +
                    "0.Выход\n" +
                    "==================================\n" +
                    "Введите номер операции: ");

                try
                {
                    int command = Convert.ToInt32(Console.ReadLine());

                    switch (command)
                    {
                        case 1:
                            AddNewEmployeeMenu(); // добавление сотрудника
                            break;
                        case 2:
                            AllEmployeesMenu();  // просмотр всех сотрудников
                            break;
                        case 3:
                            SearchEmployeeMenu(); // поиск сотрудника
                            break;
                        case 4:
                            UpdateEmployeeMenu(); //изменение данных
                            break;
                        case 5:
                            RemoveEmployeeMenu(); //удаление данных сотрудника
                            break;
                        case 6:
                            //PayrollCalculation(); //расчет зп за период
                            break;
                        case 0: //выход
                            flag = false;
                            break;
                        default:
                            Console.WriteLine("Ошибка: неверный ввод.");
                            break;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Ошибка: неверный ввод.");
                }
            }
        }

        

        private static void AddNewEmployeeMenu()
        {
            Console.WriteLine("Введите имя сотрудника");
            string name = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Введите фамилию сотрудника");
            string surName = Convert.ToString(Console.ReadLine()); 
            Console.WriteLine("Введите заработную плату");
            int wages = Convert.ToInt32(Console.ReadLine());

            Program.AddEmployee(name, surName, wages);
        }

        private static void AllEmployeesMenu()
        {
            Program.AllEmployees();
        }

        private static void SearchEmployeeMenu()
        {
            Console.WriteLine("Введите имя сотрудника для поиска");
            string searchName = Convert.ToString(Console.ReadLine());
            Program.SearchEmployee(searchName);
        }

        private static void UpdateEmployeeMenu()
        {
            Console.WriteLine("Введите id сотрудника для изменения данных");
            int updateId = Convert.ToInt32(Console.ReadLine());

            if (Program.CheckId(updateId))
            {
                Submenu(updateId);
            }
        }

        private static void Submenu(int updateId)
        {
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Выберите параметр для изменения данных:\n" +
                    "==================================\n" +
                    "1.Изменить имя сотрудника\n" +
                    "2.Изменить фамилию сотрудника\n" +
                    "3.Изменить заработную плату сотрудника\n" +
                    "0.Выход\n" +
                    "==================================\n" +
                    "Введите номер операции: ");
                try
                {
                    int commandUpdate = Convert.ToInt32(Console.ReadLine());

                    switch (commandUpdate)
                    {
                        case 1:
                            Console.WriteLine("Введите новое имя сотрудника для изменения данных");
                            string updateName = Convert.ToString(Console.ReadLine());
                            Program.UpdateName(updateId, updateName); // изменить имя
                            break;
                        case 2:
                            Console.WriteLine("Введите новую фамилию сотрудника для изменения данных");
                            string updateSurName = Convert.ToString(Console.ReadLine());
                            Program.UpdateSurName(updateId, updateSurName);  // изменить фамилию
                            break;
                        case 3:
                            Console.WriteLine("Введите новую заработную плату сотрудника для изменения данных");
                            int updateWages = Convert.ToInt32(Console.ReadLine());
                            Program.UpdateWages(updateId, updateWages); // изменить заработную плату
                            break;
                        case 0: // выход
                            flag = false;
                            break;
                        default:
                            Console.WriteLine("Ошибка: неверный ввод.");
                            break;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Ошибка: неверный ввод.");
                }
            }
        }
       
        private static void RemoveEmployeeMenu()
        {
            Console.WriteLine("Введите id сотрудника для удаления");
            int delId = Convert.ToInt32(Console.ReadLine());
            Program.RemoveEmployee(delId);
        }
        /*private static void PayrollCalculation()
        {
            Console.WriteLine("Введите id сотрудника для расчета заработной платы");
            int id

        }*/
    }
}