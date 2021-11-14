using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryForGeometry;
using System.Text.RegularExpressions;

namespace Лабораторная_3
{
    /// <summary>
    /// класс для тестирования
    /// </summary>
    class Program
    {
        /// <summary>
        /// точка входа в программу
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Начнем? (да/нет)");

                switch (Console.ReadLine())
                {
                    case "да":
                        try
                        {
                            Console.WriteLine("треугольник/окружность/прямоугольник");
                            FigureBase a = FigureWithConsole(Console.ReadLine());
                            Console.WriteLine($"площадь фигуры равна: {a.Square()}");
                            Console.ReadKey();


                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case "нет":
                        return;

                    default:
                        break;
                }
            }
        }


        /// <summary>
        /// TODO:
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        private static FigureBase FigureWithConsole(string line)
        {
            
            FigureBase figureBase;
            switch (line)
            {
                case "треугольник":
                    List<double> numbers = new List<double>();
                    while (true)
                    {
                        for (int i = 0; i < GetPhrasesToConsole.GetList(line).Count; i++)
                        {

                            while (true)
                            {
                                try
                                {
                                    Console.WriteLine(GetPhrasesToConsole.GetList(line)[i]);                                           
                                    numbers.Add(FigureBase.CheckSize(
                                        Convert.ToDouble(СhekValue(Console.ReadLine()))));
                                    break;

                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                            }
                        }
                        try
                        {
                            Triangle triangle = new Triangle(numbers[0], numbers[1], numbers[2]);
                            figureBase = triangle;
                            break;
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    
                    break;

                case "прямоугольник":
                    Rectangle rectangle = new Rectangle();
                    for (int i = 0; i < GetPhrasesToConsole.GetList(line).Count; i++)
                    {
                        while (true)
                        {
                            try
                            {
                                Console.WriteLine(GetPhrasesToConsole.GetList(line)[i]);
                                switch (i)
                                {
                                    case 0:
                                        rectangle.Length = Convert.ToDouble(Console.ReadLine());
                                        break;
                                    case 1:
                                        rectangle.Width = Convert.ToDouble(Console.ReadLine());
                                        break;
                                }
                                break;
                            }
                            catch(Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                    }
                    figureBase = rectangle;
                    break;


                case "окружность":
                    Circle circle = new Circle();
                    while (true)
                    {
                        try
                        {
                            Console.WriteLine(GetPhrasesToConsole.GetList(line)[0]);
                            circle.Radius = Convert.ToDouble(Console.ReadLine());
                            break;
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        
                    }
                    figureBase = circle;
                    break;

                default:
                    throw new Exception("Необходимо ввести фигуру из предложенных");
            }
            return figureBase;
        }
        /// <summary>
        /// TODO:
        /// </summary>
        /// <param name="line"></param>
        public static string СhekValue(string line)
        {
            int number;
            bool isParsed = Int32.TryParse(line, out number);
            if (!isParsed)
            {
                throw new Exception("Необходимо ввести числовое значение");
            }
            else
            {
                return line;
            }
        }

    }
    
}
