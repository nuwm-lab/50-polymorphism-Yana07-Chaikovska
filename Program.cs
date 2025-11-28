using System;

namespace GeometryExample
{
    // ===== Абстрактний базовий клас =====
    public abstract class Figure3D
    {
        public abstract void SetParameters();
        public abstract void PrintParameters();
        public abstract double Volume();
    }

    // ===== Клас Куля =====
    public class Sphere : Figure3D
    {
        protected double B1, B2, B3; // центр
        protected double R;          // радіус

        public override void SetParameters()
        {
            Console.WriteLine("=== Введення параметрів кулі ===");
            Console.Write("b1 = ");
            B1 = double.Parse(Console.ReadLine());

            Console.Write("b2 = ");
            B2 = double.Parse(Console.ReadLine());

            Console.Write("b3 = ");
            B3 = double.Parse(Console.ReadLine());

            Console.Write("R = ");
            R = double.Parse(Console.ReadLine());
        }

        public override void PrintParameters()
        {
            Console.WriteLine("=== Куля ===");
            Console.WriteLine($"Центр: ({B1}, {B2}, {B3})");
            Console.WriteLine($"Радіус: R = {R}");
        }

        public override double Volume()
        {
            return 4.0 / 3.0 * Math.PI * Math.Pow(R, 3);
        }
    }

    // ===== Клас Еліпсоїд (успадковує кулю) =====
    public class Ellipsoid : Sphere
    {
        private double A1, A2, A3; // півосі

        public override void SetParameters()
        {
            Console.WriteLine("=== Введення параметрів еліпсоїда ===");

            Console.Write("b1 = ");
            B1 = double.Parse(Console.ReadLine());

            Console.Write("b2 = ");
            B2 = double.Parse(Console.ReadLine());

            Console.Write("b3 = ");
            B3 = double.Parse(Console.ReadLine());

            Console.Write("a1 = ");
            A1 = double.Parse(Console.ReadLine());

            Console.Write("a2 = ");
            A2 = double.Parse(Console.ReadLine());

            Console.Write("a3 = ");
            A3 = double.Parse(Console.ReadLine());
        }

        public override void PrintParameters()
        {
            Console.WriteLine("=== Еліпсоїд ===");
            Console.WriteLine($"Центр: ({B1}, {B2}, {B3})");
            Console.WriteLine($"Півосі: A1={A1}, A2={A2}, A3={A3}");
        }

        public override double Volume()
        {
            return 4.0 / 3.0 * Math.PI * A1 * A2 * A3;
        }
    }

    // ===== Головна програма =====
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Оберіть об'єкт:");
            Console.WriteLine("1 — Куля");
            Console.WriteLine("2 — Еліпсоїд");
            Console.Write("Ваш вибір: ");
            string userChoose = Console.ReadLine();

            Figure3D figure;

            if (userChoose == "1")
            {
                figure = new Sphere();
            }
            else
            {
                figure = new Ellipsoid();
            }

            Console.WriteLine();
            figure.SetParameters();
            Console.WriteLine();
            figure.PrintParameters();
            Console.WriteLine($"Об'єм = {figure.Volume():F4}");
        }
    }
}
