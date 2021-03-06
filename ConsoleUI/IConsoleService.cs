﻿using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUI
{
   public interface IConsoleService
    {
        void GetMenus(string[] menus);
        //void GetAllBrands(List<Brand> brands);
        //void GetAllColors(List<Color> colors);
        //void GetAllCars(List<CarDetailDto> cars);
        void GetAllCarsIfNotRented(List<Car> cars);
    }
}
