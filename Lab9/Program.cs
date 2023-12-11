using System;

interface ITrigonometricFigure
{
    double GetSurfaceArea();
}

abstract class TrigonometricFigure : ITrigonometricFigure
{
    public abstract double GetSurfaceArea();
}

class Cylinder : TrigonometricFigure
{
    public double Radius { get; set; }
    public double Height { get; set; }

    public override double GetSurfaceArea()
    {
        return 2 * Math.PI * Radius * (Radius + Height);
    }
}

class Cube : TrigonometricFigure
{
    public double SideLength { get; set; }

    public override double GetSurfaceArea()
    {
        return 6 * Math.Pow(SideLength, 2);
    }
}

class Cone : TrigonometricFigure
{
    public double Radius { get; set; }
    public double SlantHeight { get; set; }

    public override double GetSurfaceArea()
    {
        return Math.PI * Radius * (Radius + SlantHeight);
    }
}

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Виберіть фігуру:");
            Console.WriteLine("1. Циліндр");
            Console.WriteLine("2. Куб");
            Console.WriteLine("3. Конус");
            Console.WriteLine("0. Вихід");

            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Будь ласка, введіть коректне число.");
                continue;
            }

            if (choice == 0)
                break;

            TrigonometricFigure figure = null;

            switch (choice)
            {
                case 1:
                    figure = new Cylinder();
                    Console.Write("Введіть радіус циліндра: ");
                    ((Cylinder)figure).Radius = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Введіть висоту циліндра: ");
                    ((Cylinder)figure).Height = Convert.ToDouble(Console.ReadLine());
                    break;
                case 2:
                    figure = new Cube();
                    Console.Write("Введіть довжину сторони куба: ");
                    ((Cube)figure).SideLength = Convert.ToDouble(Console.ReadLine());
                    break;
                case 3:
                    figure = new Cone();
                    Console.Write("Введіть радіус конуса: ");
                    ((Cone)figure).Radius = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Введіть висоту конуса: ");
                    ((Cone)figure).SlantHeight = Convert.ToDouble(Console.ReadLine());
                    break;
                default:
                    Console.WriteLine("Невідомий вибір. Спробуйте ще раз.");
                    continue;
            }

            Console.WriteLine($"Площа поверхні обраної фігури: {figure.GetSurfaceArea()}\n");
        }
    }
}
