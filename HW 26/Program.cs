using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_26
{
    class Program
    {
        #region StaticFields
        private static List<int> _integers = new List<int> { 3, 1, 4, 1, 5, 9, 2, 6, 5, 9 };

        private static List<string> _strings = new List<string> {
            "Hello",
            "World!",
            "I",
            "am",
            "a",
            "list",
            "of",
            "strings",
        };

        #endregion

        #region StaticMethods
        static int Aggregate(Func<int, int, int> f, List<int> list)
        {
            int result = list[0];
            for (int i = 1; i < list.Count; ++i)
            {
                result = f(result, list[i]);
            }

            return result;
        }

        static IEnumerable<int> Select(Func<int, int> f, IEnumerable<int> list)
        {
            List<int> result = new List<int>();
            foreach (int val in list)
            {
                result.Add(f(val));
            }
            return result;
        }

        static void ForEach<T>(Action<T> f, IEnumerable<T> list)
        {
            foreach (T val in list)
            {
                f(val);
            }
        }

        #endregion

        static void Main(string[] args)
        {

            
            
            //1A
            Console.WriteLine(Aggregate(Sum, _integers));
            Console.ReadLine();

            //1B
            Console.WriteLine(Aggregate(Multiply,_integers));
            Console.ReadLine();

            //1C
            Func<int, int, int> sum = (a, b) => a + b;

            Console.WriteLine(Aggregate(sum, _integers));
            Console.ReadLine();

            //1D
            Func<int, int, int> multiply = (a, b) => a * b;

            Console.WriteLine(Aggregate(multiply,_integers));
            Console.ReadLine();

            //2A -should be Select, not Selectpassing
            Console.WriteLine(Select(MakeDouble,_integers));
            foreach(int output in Select(MakeDouble, _integers))
            {
                Console.WriteLine(output);
            }


            Console.ReadLine();

            //2B -passing Square and _integers into what?
            Console.WriteLine(Select(Square,_integers));
            foreach (int output in Select(Square, _integers))
            {
                Console.WriteLine(output);
            }
            Console.ReadLine();


            //2C
            //Func<int, int> lambDouble = (a) => a * a;

            Console.WriteLine(Select((a)=>2*a,_integers));
            foreach (int output in Select((a) => 2 * a, _integers))
            {
                Console.WriteLine(output);
            }

            Console.ReadLine();

            //2D
            Console.WriteLine(Select((a) => a * a, _integers));
            foreach (int output in Select((a) => a * a, _integers))
            {
                Console.WriteLine(output);
            }

            Console.ReadLine();
        }


        static int Sum(int a, int b)
        {
            return a + b;
        }

         static int Multiply(int a, int b)
        {
            return a * b;
        }

        static int MakeDouble(int a)
        {
            return a * 2;
        }

        static int Square(int a)
        {
            return a * a;
        }
    }
}
