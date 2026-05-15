using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeometryApp
{
    //  АБСТРАК БАЗ КЛАС 
    public abstract class TBody
    {
        public abstract double GetSurfaceArea();
        public abstract double GetVolume();
    }

    // ПАРАЛЕЛЕПІПЕД
    public class TParallelepiped : TBody
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public double Depth { get; set; }

        public TParallelepiped(double w, double h, double d)
        {
            Width = w;
            Height = h;
            Depth = d;
        }

        public override double GetSurfaceArea()
        {
            return 2 * (Width * Height + Height * Depth + Depth * Width);
        }

        public override double GetVolume()
        {
            return Width * Height * Depth;
        }
    }

    // КУЛЯ
    public class TBall : TBody
    {
        public double Radius { get; set; }

        public TBall(double r)
        {
            Radius = r;
        }

        public override double GetSurfaceArea()
        {
            return 4 * Math.PI * Math.Pow(Radius, 2);
        }

        public override double GetVolume()
        {
            return (4.0 / 3.0) * Math.PI * Math.Pow(Radius, 3);
        }
    }



    public class BodyManager<T> where T : TBody
    {
        private List<T> items = new List<T>();

        public void Add(T item) => items.Add(item);


        public double CalculateTotalSurfaceArea()
        {
            return items.Sum(item => item.GetSurfaceArea());
        }


        public T GetLargestBody()
        {
            if (items.Count == 0) return default;
            
            T maxBody = items[0];
            foreach (var item in items)
            {
                if (item.GetVolume() > maxBody.GetVolume())
                {
                    maxBody = item;
                }
            }
            return maxBody;
        }


        public int Count => items.Count;
    }


    class Program
    {
        static void Main(string[] args)
        {

            

            BodyManager<TBody> manager = new BodyManager<TBody>();
            Random rnd = new Random();

            Console.Write("Введіть кількість пар фігур (паралелепіпед + куля): ");
            if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0) n = 3; 

            for (int i = 0; i < n; i++)
            {

                manager.Add(new TParallelepiped(
                    Math.Round(rnd.NextDouble() * 10 + 1, 2), 
                    Math.Round(rnd.NextDouble() * 10 + 1, 2), 
                    Math.Round(rnd.NextDouble() * 10 + 1, 2)));


                manager.Add(new TBall(
                    Math.Round(rnd.NextDouble() * 10 + 1, 2)));
            }



            Console.WriteLine($"Всього створено об'єктів: {manager.Count}");
            Console.WriteLine($"Загальна площа поверхні всіх тіл: {manager.CalculateTotalSurfaceArea():F2}");

            TBody largest = manager.GetLargestBody();
            if (largest != null)
            {
                Console.WriteLine($"Тип найбільшої за об'ємом фігури: {largest.GetType().Name}");
                Console.WriteLine($"Її об'єм: {largest.GetVolume():F2}");
            }

            Console.WriteLine("\nНатисніть будь-яку клавішу для виходу...");
            Console.ReadKey();
        }
    }
}