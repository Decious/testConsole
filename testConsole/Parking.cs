
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Schema;

namespace testConsole
{
    class Parking
    {
        private List<Car> _cars = new List<Car>();
        private const int MAX_CARS = 100;
        public delegate void deleg(int i);

        public event Action onAddCompleted;
        public Car this[string number]
        {
            get
            {
                return _cars.FirstOrDefault(c => c.Number == number);
            }
        }

        public int Count => _cars.Count;
        public string Name { get; set; }

        public static void TestingMethod(deleg method)
        {
            for (int i = 0; i < 10; i++)
            {
                method(i);
            }
        }
        public int Add(Car car)
        {
            if (car == null)
            {
                throw new ArgumentNullException(nameof(car), "Car is null");
            }
            if (_cars.Count < MAX_CARS)
            {
                _cars.Add(car);
                onAddCompleted.Invoke();
                return _cars.Count - 1;
            }

            else return -1;
        }

        public IEnumerable<int> GetNumbers(int max)
        {
            var current = 0;
            for(int i = 0; i < max; i++)
            {
                current += i;
                yield return current;
            }
        }

        /// <summary>
        /// Remove car out of the parking lot.
        /// </summary>
        /// <param name="number">Car registration plate number.</param>
        public void GoOut(string number)
        {
            if (string.IsNullOrWhiteSpace(number))
            {
                throw new ArgumentNullException(nameof(number),"Number is null or whitespace.");
            }

            var car = _cars.FirstOrDefault(c => c.Number == number);
            if (car != null )
            {
                _cars.Remove(car);
            }
        }
    }
}
