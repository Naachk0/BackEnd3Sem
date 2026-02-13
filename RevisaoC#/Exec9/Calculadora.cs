

namespace Exec9
{
    public class Calculadora
    {
          public static double Somar(double a, double b)
    {
        return a + b;
    }

    public static double Subitração(double a, double b)
    {
        return a - b;
    }

    public static double Multiplicação(double a, double b)
    {
        return a * b;
    }

    public static double Divisão(double a, double b)
    {
        if (b == 0)
        {
            Console.WriteLine("Divisão por zero não é aceita");
            return double.NaN; 
        }

        return a / b;

        
    }
    }
}