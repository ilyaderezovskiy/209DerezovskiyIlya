using System;

public class Plant
{
    private double growth;
    private double photosensitivity;
    private double frostresistance;

    public Plant(double gr, double photo, double frost)
    {
        growth = gr;
        photosensitivity = photo;
        frostresistance = frost;
    }

    public double Growth
    {
        get
        {
            return growth;
        }

        set
        {
            growth = value;
        }
    }

    public double Photosensitivity
    {
        get
        {
            return photosensitivity;
        }

        set
        {
            photosensitivity = value;
        }
    }

    public double Frostresistance
    {
        get
        {
            return frostresistance;
        }

        set
        {
            frostresistance = value;
        }
    }
    public override string ToString() => $"Growth: {growth} Photosensitivity: {photosensitivity} Frostresistance: {frostresistance}";
}
class Program
{
    static int Sorting(Plant x, Plant y)
    {
        if ((int)x.Photosensitivity % 2 == 0 && (int)y.Photosensitivity % 2 != 0)
            return -1;
        if ((int)x.Photosensitivity % 2 != 0 && (int)y.Photosensitivity % 2 == 0)
            return 1;
        return 0;
    }

    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        Plant[] arr = new Plant[n];
        Random rnd = new Random();
        for (int i = 0; i < n; i++)
            arr[i] = new Plant(rnd.Next(25, 101), rnd.Next(0, 101), rnd.Next(0, 101));
        Array.ForEach(arr, a => Console.WriteLine(a));
        Console.WriteLine();

        // сортировка по возрастания роста
        Array.Sort(arr, delegate (Plant x, Plant y)
        {
            if (x.Growth > y.Growth) return -1;
            if (x.Growth < y.Growth) return 1;
            return 0;
        });
        Array.ForEach(arr, a => Console.WriteLine(a));
        Console.WriteLine();

        // сортировка по убыванию морозоустойчивости
        Array.Sort(arr, (x, y) => 
        {
            if (x.Frostresistance < y.Frostresistance) return -1;
            if (x.Frostresistance > y.Frostresistance) return 1;
            return 0;
        });
        Array.ForEach(arr, a => Console.WriteLine(a));
        Console.WriteLine();

        // сортировка по чётности светочувствительности
        Array.Sort(arr, (x, y) => Sorting(x, y));
        Array.ForEach(arr, a => Console.WriteLine(a));
        Console.WriteLine();

        Array.ConvertAll(arr, x => {
            int frost = (int)x.Frostresistance;
            if (frost % 2 == 0)
                x.Frostresistance = Math.Round(x.Frostresistance / 3, 3);
            else
                x.Frostresistance = Math.Round(x.Frostresistance / 2, 3);
            return x;
        });
        Array.ForEach(arr, a => Console.WriteLine(a));
    }
}
