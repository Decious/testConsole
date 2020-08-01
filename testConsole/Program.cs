﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Threading;
using System.Threading.Tasks;

namespace testConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            #region old_Lesson
            //Base<int> baseC = new Proizv<int>("Magical Unicorn",14);
            //baseC.Fin_Work += BaseC_Fin_Work;
            //baseC.Fin_Work_Customized += BaseC_Fin_Work_Customized;
            //baseC.Work();
            //Console.ReadLine();
            #endregion
            var cars = new List<Car>()
            {
                new Car() {Name = "ford", Number = "a001aa01"},
                new Car() {Name = "lada", Number = "b727et77"}
            };

            var parking = new Parking();
            parking.onAddCompleted += () => Console.WriteLine("Parking added a car...");
            Parking.TestingMethod((i) => Console.WriteLine(i*i));
            foreach (var car in cars)
            {
                parking.Add(car);
            }

            foreach (var item in parking.GetNumbers(10))
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }

        static private void Print()
        {
            for (int i = 0; i < 200; i++)
            {
                Console.WriteLine("Print");
            }
        }
        #region old_Lesson
        //private static int BaseC_Fin_Work_Customized(string name)
        //{
        //    Console.WriteLine($"Object {name} invoked a customized event!");
        //    return 10;
        //}

        //private static void BaseC_Fin_Work(object sender, OnWorkDoneEventArgs e)
        //{
        //    Console.WriteLine(e.Name);
        //    if (sender is Base<int>)
        //    {
        //        Console.WriteLine($"Object {((Base<int>)sender).Name} invoked an event!");
        //    }
        //}
        #endregion

    }
}