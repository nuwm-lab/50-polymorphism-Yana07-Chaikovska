using System;

namespace GeometryExample
{
    // ===== Абстрактний базовий клас =====
    public abstract class Figure3D
    {
        public abstract void ReadParameters();
        public abstract void PrintParameters();
        public abstract double Volume();
    }

    // ===== Куля =====
    public class Sphere : Figure3D
    {
        public double CenterX { get; private set; }
        public double CenterY { get; private set; }
        public double CenterZ { get; private set; }
        public double Radius  { get; private set; }

        public Sphere() {}

        public override void ReadParameters()
        {
            CenterX = ReadDouble("Введіть b1: ");
            CenterY = ReadDouble("Введіть b2: ");
            CenterZ = ReadDouble("Введіть b3: ");
            Radius  = ReadDouble("Введіть R: ");
        }

        public override void PrintParameters()
        {
            Console.WriteLine("=== Куля ===");
            Console.WriteLine($"Центр: ({CenterX}, {CenterY}, {CenterZ})");
            Console.WriteLine($"Радіус: {Radius}");
        }

        public override double Volume()
        {
            return 4.0 / 3.0 * Math.PI * Math.Pow(Radius, 3);
        }

        protected double ReadDouble(string message)
        {
            double value;
            Console.Write(message);

            while (!double.TryParse(Console.ReadLine(), out value))
            {
                Console.Write("Неправильний формат. Спробуйте ще раз: ");
            }

            return value;
        }
    }

    // ===== Еліпсоїд =====
    public class Ellipsoid : Figure3D
    {
        public double CenterX { get; private set; }
        public double CenterY { get; private set; }
        public double CenterZ { get; private set; }

        public double A1 { get; private set; }
        public double A2 { get; private set; }
        public double A3 { get; private set; }

        public Ellipsoid() {}

        public override void ReadParameters()
        {
            CenterX = ReadDouble("Введіть b1: ");
            CenterY = ReadDouble("Введіть b2: ");
            CenterZ = ReadDouble("Введіть b3: ");

            A1 = ReadDouble("Введіть a1: ");
            A2 = ReadDouble("Введіть a2: ");
            A3 = ReadDouble("Введіть a3: ");
        }

        public override void PrintParameters()
        {
            Console.WriteLine("=== Еліпсоїд ===");
            Console.WriteLine($"Центр: ({CenterX}, {CenterY}, {CenterZ})");
            Console.WriteLine($"Півосі: ({A1}, {A2}, {A3})");
        }

        public override double Volume()
        {
            return 4.0 / 3.0 * Math.PI * A1 * A2 * A3;
        }

        protected double ReadDouble(string message)
        {
            double value;
            Console.Write(message);

            while (!double.TryParse(Console.ReadLine(), out value))
            {
                Console.Write("Неправильний формат. Спробуйте ще раз: ");
            }

            return value;
        }
    }

    // ===== Головна програма =====
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Оберіть об'єкт:");
            Console.WriteLine("1 -- Куля");
            Console.WriteLine("2 -- Еліпсоїд");
            Console.Write("Ваш вибір: ");
            string choice = Console.ReadLine();

            Figure3D figure;

            if (choice == "1")
                figure = new Sphere();
            else
                figure = new Ellipsoid();

            Console.WriteLine();
            figure.ReadParameters();

            Console.WriteLine();
            figure.PrintParameters();
            Console.WriteLine($"Об'єм = {figure.Volume():F3}");
        }
    }
}

