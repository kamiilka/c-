using System;

namespace ConicSectionsApp
{
    // базовий клас крива другого порядку
    class ConicSection
    {
        // поля для коефіцієнтів рівняння: a11*x^2 + 2*a12*xy + a22*y^2 + b1*x + b2*y + c = 0
        protected double a11;
        protected double a12;
        protected double a22;
        protected double b1;
        protected double b2;
        protected double c;

        // конструктор для задання коефіцієнтів
        public ConicSection(double a11, double a12, double a22, double b1, double b2, double c)
        {
            this.a11 = a11;
            this.a12 = a12;
            this.a22 = a22;
            this.b1 = b1;
            this.b2 = b2;
            this.c = c;
        }

        // метод для виведення коефіцієнтів на екран
        public virtual void DisplayCoefficients()
        {
            Console.WriteLine("Коефіцієнти кривої другого порядку:");
            Console.WriteLine($"a11 = {a11}, a12 = {a12}, a22 = {a22}, b1 = {b1}, b2 = {b2}, c = {c}");
            Console.WriteLine($"Рівняння: {a11}*x^2 + 2*({a12})*xy + {a22}*y^2 + {b1}*x + {b2}*y + {c} = 0");
        }

        // віртуальний метод  чи належить точка (x, y) кривій
        public virtual bool ContainsPoint(double x, double y)
        {
            double result = a11 * x * x + 2 * a12 * x * y + a22 * y * y + b1 * x + b2 * y + c;
            return Math.Abs(result) < 0.0001;
        }
    }

    // похідний клас Еліпс
    class Ellipse : ConicSection
    {
        private double a;
        private double b;

        // x^2/a^2 + y^2/b^2 = 1 рівняння у загальному вигляді буде: (1/a^2)*x^2 + (1/b^2)*y^2 - 1 = 0
        public Ellipse(double a, double b) : base(1 / (a * a), 0, 1 / (b * b), 0, 0, -1)
        {
            this.a = a;
            this.b = b;
        }

        // Перевантажений (перевизначений) метод виведення коефіцієнтів
        public override void DisplayCoefficients()
        {
            Console.WriteLine($"Еліпс із півосями: a = {a}, b = {b}");
            Console.WriteLine($"Канонічне рівняння: x^2/({a}^2) + y^2/({b}^2) = 1");
        }

        // Перевантажений (перевизначений) метод перевірки точки спеціально для еліпса
        public override bool ContainsPoint(double x, double y)
        {
            // Підставляємо в канонічне рівняння еліпса: x^2/a^2 + y^2/b^2
            double result = (x * x) / (a * a) + (y * y) / (b * b);
            
            // Перевіряємо, чи дорівнює результат одиниці (з урахуванням невеликої похибки)
            return Math.Abs(result - 1) < 0.0001;
        }
    }

    // Головна програма для демонстрації роботи
    class Program
    {
        static void Main(string[] args)
        {
            // Налаштування кодування для коректного відображення української мови в консолі
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("--- Створення об'єкта класу 'Еліпс' ---");
            
            // Введення параметрів еліпса
            Console.Write("Введіть піввісь a: ");
            double a = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введіть піввісь b: ");
            double b = Convert.ToDouble(Console.ReadLine());

            // Створення об'єкта похідного класу
            Ellipse myEllipse = new Ellipse(a, b);
            
            Console.WriteLine();
            myEllipse.DisplayCoefficients();
            Console.WriteLine();

            // Введення координат точки користувачем
            Console.WriteLine("--- Перевірка належності точки еліпсу ---");
            Console.Write("Введіть координату x: ");
            double x = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введіть координату y: ");
            double y = Convert.ToDouble(Console.ReadLine());

            // Визначення належності точки за допомогою перевизначеного методу
            if (myEllipse.ContainsPoint(x, y))
            {
                Console.WriteLine($"\nРезультат: Точка ({x}; {y}) НАЛЕЖИТЬ даному еліпсу.");
            }
            else
            {
                Console.WriteLine($"\nРезультат: Точка ({x}; {y}) НЕ НАЛЕЖИТЬ даному еліпсу.");
            }

            Console.ReadKey();
        }
    }
}