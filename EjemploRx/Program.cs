using System;
using System.Reactive.Linq;

namespace EjemploRx
{
    static class Program
    {
        public static event EventHandler<int> MyEvent;

        static void Main(string[] args)
        {
            var observable = Observable.FromEventPattern<int>(
                e => MyEvent += e,
                e => MyEvent -= e
                );

            observable.Subscribe(some =>
            {
                Console.WriteLine("Hizo algo, vamos a c0mentarlo - Chismoso 1 - " + some.EventArgs);
            });

            observable.Subscribe(some =>
            {
                Console.WriteLine("Hizo algo - Chismoso 2 - " + some.EventArgs);
            });

            observable.Subscribe(some =>
            {
                Console.WriteLine("Hizo algo - Chismoso 3 - " + some.EventArgs);
            });

            MyEvent(null, 9);
            MyEvent(null, 1);
            MyEvent(null, 5);

            Console.Read();
        }
    }
}
