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
                            Console.WriteLine($"площадь треугольника равна: {a.Square()}");
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
        /// для работы с консолью
        /// </summary>
        /// <param name="line">входная строка</param>
        /// <returns></returns>
        private static FigureBase FigureWithConsole(string line)
        {
            FigureBase figureBase;
            var listVal3 = new List<Tuple<string, Action>>();

            switch (line)
            {
                case "треугольник":

                    Triangle triangle;

                    //triangle = new Triangle(Convert.ToDouble(Console.ReadLine()), Convert.ToDouble(Console.ReadLine()), Convert.ToDouble(Console.ReadLine()));
                    break;



                case "прямоугольник":
                    Rectangle rectangle = new Rectangle();
                    listVal3.Add
                           (
                               new Tuple<string, Action>
                               (
                                   "введите длину сторону: ",
                                   () =>
                                   {
                                       rectangle.Length = Convert.ToDouble(Console.ReadLine());
                                   }

                               )
                           );

                    listVal3.Add
                          (
                              new Tuple<string, Action>
                              (
                                  "введите ширину сторону: ",
                                  () =>
                                  {
                                      rectangle.Width = Convert.ToDouble(Console.ReadLine());
                                  }

                              )
                          );
                    foreach (var actionItem in listVal3)
                    {
                        ValidateInput(actionItem.Item1, actionItem.Item2);
                    }

                    figureBase = rectangle;
                    break;


                case "окружность":
                    Circle circle = new Circle();
                    listVal3.Add
                           (
                               new Tuple<string, Action>
                               (
                                   "введите радиус сторону: ",
                                   () =>
                                   {
                                       circle.Radius = Convert.ToDouble(Console.ReadLine());
                                   }

                               )
                           );
                    foreach (var actionItem in listVal3)
                    {
                        ValidateInput(actionItem.Item1, actionItem.Item2);
                    }
                    figureBase = circle;
                    break;

                default:
                    throw new Exception("Необходимо ввести фигуру из предложенных");
            }
            return figureBase;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="outputMessage"></param>
        /// <param name="validationAction"></param>
        private static void ValidateInput(string outputMessage,
               Action validationAction)
        {
            while (true)
            {
                try
                {
                    Console.Write(outputMessage);
                    validationAction();
                    return;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}\nПопробуйте снова.");
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="line"></param>
        static void СhekValue(string line)
        {
            int number;
            bool isParsed = Int32.TryParse(line, out number);
            if(!isParsed)
            {
                throw new Exception("Необходимо ввести числовое значение");
            }
        }
    }
}
