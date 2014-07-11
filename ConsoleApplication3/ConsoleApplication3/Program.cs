using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirportClassLibrary1;
using metClassLibrary2;
using AutopilotClassLibrary4;






namespace обучалка
{
    
    class Program  //базовый класс
    {
        static void Main(string[] args) //точка входа в программу
        {
            AutopilotClassLibrary4.newmet.center1();   //просто передача управления в наш метод-интерфейс
            Console.WriteLine("Остановка прогр.");
            Console.ReadKey();
        }
    }
}
