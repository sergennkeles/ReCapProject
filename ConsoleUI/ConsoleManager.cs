using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUI
{
  public class ConsoleManager:IConsoleService
    {
 

        public void GetAllCarsIfNotRented(List<Car> cars)
        {
            Console.WriteLine(@"*****************************");
            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Id}\t{car.ModelYear}\t{car.Description}");
            }
            Console.WriteLine(@"*****************************");
        }


        public void GetMenus(string[] menus)
        {
            Console.WriteLine("------------------------------");
            for (int i = 0; i < menus.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {menus[i]}");
            }
            Console.WriteLine("------------------------------");
        }
    }
}

