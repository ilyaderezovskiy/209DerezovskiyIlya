using System;

// Задание 3
delegate double delegateConvertTemperature(double x);

class TemperatureConverterImp
{
    public double ToCelsius(double temp) => 5 / 9 * (temp - 32);
    public double ToFahrenheit(double temp) => 1.8 * temp + 32;
}

class StaticTempConverters
{
    public static double ToKelvin(double temp) => temp + 273.15;
    public static double ToReaumur(double temp) => 0.8 * temp;
    public static double ToRankin(double temp) => (temp + 273.15) * 1.8;

    public static double FromKelvin(double temp) => temp - 273.15;
    public static double FromReaumur(double temp) => temp * 5 / 4;
    public static double FromRankin(double temp) => (temp - 491.67) * 5 / 9;
}

class Program
{
    static void Main(string[] args)
    {
        TemperatureConverterImp temperatureConverter = new TemperatureConverterImp();

        delegateConvertTemperature[] converter = new delegateConvertTemperature[]
        {temperatureConverter.ToFahrenheit, StaticTempConverters.ToKelvin, StaticTempConverters.ToReaumur, StaticTempConverters.ToRankin};

        //delegateConvertTemperature converterToCelsius = new delegateConvertTemperature(temperatureConverter.ToCelsius);
        //delegateConvertTemperature converterToFahrenheit = new delegateConvertTemperature(temperatureConverter.ToFahrenheit);

        string[] names = new string[] { "Fahrenheit ", "Kelvin ", "Reaumur ", "Rankin " };

        Console.WriteLine("Введите вещественное число - температуру по шкале Цельсия:");
        try
        {
            double temperature = double.Parse(Console.ReadLine());
            for (int i = 0; i < converter.Length; i++)
            {
                Console.WriteLine(names[i] + Math.Round(converter[i](temperature), 3));
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Incorrect input!", e);
        }
    }
}