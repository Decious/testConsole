using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace testConsole
{
    class Base<T>
    {
        public string Name { get; set; }
        public T Age { get; set; }
        /// <summary>
        /// Contains information about time it took to finish work.
        /// </summary>
        public event EventHandler<OnWorkDoneEventArgs> OnFinishedWork;
        public Base(string name,T age)
        {
            Name = name;
            Age = age;
        }
        public Base(string name)
        {
            Name = name;
            Age = default;
        }
        /// <summary>
        /// This method simulates work async.
        /// </summary>
        /// <returns>Void</returns>
        public async Task WorkAsync()
        {
            await Task.Run(() => Work());
        }
        /// <summary>
        /// This method simulates work.
        /// </summary>
        public void Work()
        {
            Random rnd = new Random();
            Console.WriteLine($"Doing work... Thread: {Thread.CurrentThread.ManagedThreadId}");
            int intensity = 5000+rnd.Next(1000,9000);
            Thread.Sleep(intensity);
            OnWorkDoneEventArgs args = new OnWorkDoneEventArgs();
            args.Time = intensity;
            OnFinishedWork?.Invoke(this, args);
        }
        public void WorkCallout(object state)
        {
            OnWorkDoneEventArgs args = new OnWorkDoneEventArgs();
            args.Time = (int)state;
            OnFinishedWork?.Invoke(this, args);
        }
    }
}
