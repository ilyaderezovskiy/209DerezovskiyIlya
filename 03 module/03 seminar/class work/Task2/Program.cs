using System;
using System.Drawing;

namespace sem_27._01_2
{
    public delegate void SquareSizeChanged(double x);

    public class Square
    {
        double x1, y1, x2, y2;
        public event SquareSizeChanged OnSizeChanged;
        public double Size()
        {
            return Math.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2)) / Math.Sqrt(2);
        }

        public (double, double) Dot1
        {
            get
            {
                return (x1, y1);
            }
            set
            {
                x1 = value.Item1;
                y1 = value.Item1;
                OnSizeChanged?.Invoke(Size());
            }
        }

        public (double, double) Dot2
        {
            get
            {
                return (x2, y2);
            }
            set
            {
                x2 = value.Item1;
                y2 = value.Item1;
                OnSizeChanged?.Invoke(Size());
            }
        }

        public Square(double x1, double y1, double x2, double y2)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
        }
    }

    class Program
    {
        static void SquareConsoleInfo(double A)
        {
            Console.WriteLine($"{A:f2}");
        }

        static void Main()
        {
            double x1 = Convert.ToDouble(Console.ReadLine());
            double y1 = Convert.ToDouble(Console.ReadLine());
            double x2 = Convert.ToDouble(Console.ReadLine());
            double y2 = Convert.ToDouble(Console.ReadLine());
            Square S = new Square(x1, y1, x2, y2);
            S.OnSizeChanged += SquareConsoleInfo;

            for (int i = 0; i < 5; i++)
            {
                S.Dot1 = (Convert.ToDouble(Console.ReadLine()), Convert.ToDouble(Console.ReadLine()));
            }
        }
    }
}
