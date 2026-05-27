using System;

namespace GeometryTask
{
    // клас опуклий чотирикутник 
    class ConvexQuadrilateral
    {
        protected double x1, y1, x2, y2, x3, y3, x4, y4;

        // задання координат вершин 
        public void SetCoordinates(
            double x1, double y1,
            double x2, double y2,
            double x3, double y3,
            double x4, double y4)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
            this.x3 = x3;
            this.y3 = y3;
            this.x4 = x4;
            this.y4 = y4;
        }

        // виведення кординат 
        public virtual void PrintCoordinates()
        {
            Console.WriteLine("координати вершин чотирикутника:");
            Console.WriteLine($"A({x1}, {y1})");
            Console.WriteLine($"B({x2}, {y2})");
            Console.WriteLine($"C({x3}, {y3})");
            Console.WriteLine($"D({x4}, {y4})");
        }

        // обчислення площі за формулою гауса 
        public virtual double CalculateArea()
        {
            
            double area = (x1 * y2 + x2 * y3 + x3 * y4 + x4 * y1
                         - y1 * x2 - y2 * x3 - y3 * x4 - y4 * x1) / 2.0;

            return Math.Abs(area);
        }
        public void PrintArea()
        {
            Console.WriteLine($"Площа чотирикутника: {CalculateArea()}");
        }
    }
    class ConvexQuadrilateral1
    {
        protected double x1, y1, x2, y2, x3, y3, x4, y4;

        // задання координат вершин 
        public void SetCoordinates(
            double x1, double y1,
            double x2, double y2,
            double x3, double y3,
            double x4, double y4)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
            this.x3 = x3;
            this.y3 = y3;
            this.x4 = x4;
            this.y4 = y4;
        }

        // виведення кординат 
        public virtual void PrintCoordinates()
        {
            Console.WriteLine("координати вершин чотирикутника:");
            Console.WriteLine($"A({x1}, {y1})");
            Console.WriteLine($"B({x2}, {y2})");
            Console.WriteLine($"C({x3}, {y3})");
            Console.WriteLine($"D({x4}, {y4})");
        }

        // обчислення площі за формулою гауса 
        public virtual double CalculateArea()
        {
            
            double area = (x1 * y2 + x2 * y3 + x3 * y4 + x4 * y1
                         - y1 * x2 - y2 * x3 - y3 * x4 - y4 * x1) / 2.0;

            return Math.Abs(area);
        }
    }   

    // похідний клас трикутник
    class Triangle : ConvexQuadrilateral
    {
        // перевантаження задання координат трикутника  
        public void SetCoordinates(
            double x1, double y1,
            double x2, double y2,
            double x3, double y3)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
            this.x3 = x3;
            this.y3 = y3;
        }

        // перевизначення виведення координат 
        public override void PrintCoordinates()
        {
            Console.WriteLine("координати вершин трикутника:");
            Console.WriteLine($"A({x1}, {y1})");
            Console.WriteLine($"B({x2}, {y2})");
            Console.WriteLine($"C({x3}, {y3})");
        }

        // перевизначення площі трикутника 
        public override double CalculateArea()
        {
            double area = Math.Abs(
                x1 * (y2 - y3) +
                x2 * (y3 - y1) +
                x3 * (y1 - y2)
            ) / 2.0;

            return area;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // об'єкт чотирикутник
            ConvexQuadrilateral quad = new ConvexQuadrilateral();
            quad.SetCoordinates(0, 0, 4, 0, 4, 3, 0, 3); 

            quad.PrintCoordinates();
            Console.WriteLine($"Площа чотирикутника: {quad.CalculateArea()}"); 

            Console.WriteLine();

            // об'єкт трикутник
            Triangle triangle = new Triangle();
            triangle.SetCoordinates(0, 0, 4, 0, 2, 3); 

            triangle.PrintCoordinates();
            Console.WriteLine($"Площа трикутника: {triangle.CalculateArea()}");  

            Console.ReadKey();
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // об'єкт чотирикутник
        ConvexQuadrilateral quad = new ConvexQuadrilateral();
        quad.SetCoordinates(0, 0, 4, 0, 4, 3, 0, 3); 

        quad.PrintCoordinates();
        Console.WriteLine($"Площа чотирикутника: {quad.CalculateArea()}"); 

        Console.WriteLine();

        // об'єкт трикутник
        Triangle triangle = new Triangle();
        triangle.SetCoordinates(0, 0, 4, 0, 2, 3); 

        triangle.PrintCoordinates();
        Console.WriteLine($"Площа трикутника: {triangle.CalculateArea()}");  

        Console.ReadKey();
    }
}