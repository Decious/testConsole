using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.PortableExecutable;
using System.Runtime.Serialization.Formatters.Binary;
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
            #region Parking_Cars
            //var cars = new List<Car>()
            //{
            //    new Car() {Name = "ford", Number = "a001aa01"},
            //    new Car() {Name = "lada", Number = "b727et77"}
            //};

            //var parking = new Parking();
            //parking.onAddCompleted += () => Console.WriteLine("Parking added a car...");
            //Console.WriteLine("Testing GitHub integrated capabilities");
            //Parking.TestingMethod((i) => Console.WriteLine(i*i));
            //foreach (var car in cars)
            //{
            //    parking.Add(car);
            //}

            //foreach (var item in parking.GetNumbers(10))
            //{
            //    Console.WriteLine(item);
            //}
            #endregion
            #region attributes_lesson
            //Animal animal = new Animal();
            //NPC npc = new NPC();
            //Player player = new Player();
            //player.Health = 100;
            //List<IEntity> entities = new List<IEntity>();
            //entities.Add(animal);
            //entities.Add(npc);
            //entities.Add(player);
            //foreach(IEntity entity in entities)
            //{
            //    if(entity.GetType().GetCustomAttributes().Any(x=> x.GetType() == typeof(PlayableAttribute)))
            //    {
            //        Console.WriteLine($"Entity {entity}");
            //    } else
            //    {
            //        Console.WriteLine($"[NPC] {entity}");
            //    }
            //}
            #endregion
            #region SerializationLesson
            List<Base> baselist = new List<Base>();
            List<Base> resultinglist;
            var Baza1 = new Base("First Base");
            Baza1.SetSecret(1);
            var Baza2 = new Base("Second Base");
            Baza2.SetSecret(420);
            baselist.Add(Baza1);
            baselist.Add(Baza2);
            var formatter = new BinaryFormatter();
            using(var file = new FileStream("test.bin", FileMode.OpenOrCreate))
            {
                formatter.Serialize(file,baselist);
            }
            using (var file = new FileStream("test.bin", FileMode.OpenOrCreate))
            {
                resultinglist = formatter.Deserialize(file) as List<Base>;
            }
            foreach(var item in resultinglist)
            {
                Console.WriteLine(item);
            }
            #endregion
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
