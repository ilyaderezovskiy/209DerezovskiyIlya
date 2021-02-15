using System;

namespace sem_27._01
{
    public delegate void CoordChanged(Dot dot); // событийный делегат

    public class Dot
    {
        public double x;
        public double y;

        public event CoordChanged OnCoordChanged; // событие

        public Dot(double X, double Y)
        {
            x = X;
            y = Y;
        }

        public void DotFlow()
        {
            Random rnd = new Random();
            for (int i = 0; i < 10; i++)
            {
                x = rnd.NextDouble() * 20 - 10;
                y = rnd.NextDouble() * 20 - 10;
                if (x < 0 && y < 0)
                    OnCoordChanged?.Invoke(this); // запуск события
            }
        }

        public override string ToString()
        {
            return $"x = {x:f3}, y = {y:f3}";
        }
    }

    class Program
    {
        static void PrintInfo(Dot A)
        {
            Console.WriteLine(A);
        }

        static void Main(string[] args)
        {
                double x = Convert.ToDouble(Console.ReadLine());
                double y = Convert.ToDouble(Console.ReadLine());
                Dot D = new Dot(x, y);
                D.OnCoordChanged += PrintInfo; // подписать обработчик
                D.DotFlow();
        }
    }
}
