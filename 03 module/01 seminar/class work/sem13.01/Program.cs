using System;

namespace sem13._01
{
    //myDel2?.Invoke(); //? проверяет, не пуст ли делегат?
    //1
    delegate int Cast(double a);

    class Program
    {
        static void Main(string[] args)
        {
            Cast cast_odd = delegate (double a)
            {
                return (int)Math.Round(a, MidpointRounding.ToEven);
            };
            Cast cast_por = delegate (double a)
            {
                return (int)Math.Log10(a) + 1;
            };
            Console.WriteLine(cast_odd(1.5));
            Console.WriteLine(cast_por(1005));

            //4
            Cast cast_odd_lambda = (double a) => (int)a % 2 == 0 ? (int)a : (int)a + 1;
            Cast cast_por_lambda = (double a) => ((int)a).ToString().Length;

            Console.WriteLine(cast_odd_lambda(1.5));
            Console.WriteLine(cast_por_lambda(1005));

            //5
            Cast full = cast_odd;
            full += cast_por;

            Console.WriteLine("***");
            Console.WriteLine(full(1005.5));
            Console.WriteLine("***");

            foreach (Cast d in full.GetInvocationList())
            {
                Console.WriteLine(d(1005.5));
            }
        }
    }
}
