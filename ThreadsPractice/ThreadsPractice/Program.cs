using System;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadsPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Threads
            //Thread myEvenThread = new Thread(new ThreadStart(CalculateEven));

            //myEvenThread.Start();

            //Thread myOddThread = new Thread(new ThreadStart(CalculateOdd));

            //myOddThread.Start();
            #endregion

            #region Async
            //Console.WriteLine("Hello, I`m main stream!");

            //CalculateEvenAsync();

            //Console.WriteLine("I`m tired, bye!");
            #endregion
        }

        static async Task CalculateEvenAsync()
        {
            Console.WriteLine("Start Calculate Even Async");

            await Task.Run(() => CalculateEven());

            Console.WriteLine("End Calculate Even Async");
        }

        static void CalculateEven()
        {
            for (int i = 0; i < 10; i++)
            {
                if (i % 2 == 0)
                    Console.WriteLine($"Even {i} from even stream!");
            }
        }

        static void CalculateOdd()
        {
            for (int i = 0; i < 10; i++)
            {
                if (i % 2 != 0)
                    Console.WriteLine($"Odd {i} from odd stream!");
            }
        }
    }
}
