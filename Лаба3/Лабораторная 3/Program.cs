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
    public class Program
    {
        /// <summary>
        /// тестирование работы классов
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Начнем? (да/нет)");
                FigureBase figure;
                switch (Console.ReadLine())
                {
                    case "да":
                        try
                        {
                            Console.WriteLine("1-треугольник\n2-окружность\n3-прямоугольник");
                            switch (Int32.Parse(Console.ReadLine()))
                            {
                                case 1:
                                    figure = TriangleTohConsole();
                                    break;
                                case 2:
                                    figure = CircleTohConsole();
                                    break;
                                case 3:
                                    figure = RectangleTohConsole();
                                    break;
                                default:
                                    throw new Exception("Нееобходимо выбрать фигуру");
                            }
                            Console.WriteLine($"площадь фигуры: {figure.Square()}");
                            Console.ReadKey();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case "нет":
                        return;                    
                }
            }
        }

        /// <summary>
        /// ввод треугольник с консоли
        /// </summary>
        /// <returns>треугольник</returns>
        private static Triangle TriangleTohConsole()
        {
            List<double> numbers = new List<double>();
            var trianglePhrasesListTmp = new List<string>()
            {
                "Введите А",  "Введите Б",  "Введите С"
            };
            var action = new Action(() => numbers.Add(FigureBase.CheckSize(
                               Convert.ToDouble(СhekValue(Console.ReadLine())))));

            while (true)
            {
                foreach (var phrase in trianglePhrasesListTmp)
                {
                    InvokeAciton(phrase, action);
                }

                try
                {
                    return new Triangle(numbers[0], numbers[1], numbers[2]);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        /// <summary>
        /// ввод прямоугольника с консоли
        /// </summary>
        /// <returns>прямоугольник</returns>
        private static Rectangle RectangleTohConsole()
        {
            Rectangle rectangle = new Rectangle();
            var rectangleActionPhrasesList = new List<Tuple<string, Action>>()
            {
                new Tuple<string, Action> ("Введите длину", new Action (() => 
                    rectangle.Length = Convert.ToDouble(СhekValue(Console.ReadLine())))),
                new Tuple<string, Action>("Введите ширину", new Action (() => 
                    rectangle.Width = Convert.ToDouble(СhekValue(Console.ReadLine()))))
            };
            foreach (var tmpAction in rectangleActionPhrasesList)
            {
                InvokeAciton(tmpAction.Item1, tmpAction.Item2);
            }
            return rectangle;
        }

        /// <summary>
        /// ввод окружности с консоли
        /// </summary>
        /// <returns>окружность</returns>
        private static Circle CircleTohConsole()
        {
            Circle circle = new Circle();
            InvokeAciton("введите радиус",
                new Action(() => circle.Radius = Convert.ToDouble(СhekValue(Console.ReadLine()))));
            return circle;
        }

        /// <summary>
        /// выполнение действий и выведение фраз н аконсоль
        /// </summary>
        /// <param name="message">фраза</param>
        /// <param name="action">действие</param>
        public static void InvokeAciton(string message, Action action)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine(message);                                           
                    action.Invoke();
                    return;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        /// <summary>
        /// проверяем входную строку на возможность преобразования в число
        /// </summary>
        /// <param name="line">входная строка с консоли</param>
        public static string СhekValue(string line)
        {
            double number;
            bool isParsed = Double.TryParse(line, out number);
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
