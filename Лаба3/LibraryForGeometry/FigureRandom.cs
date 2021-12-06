using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryForGeometry
{
    /// <summary>
    /// Класс для формирования случайно фигуры
    /// </summary>
    public class FigureRandom
    {
        /// <summary>
        /// формирование случайной фигуры
        /// </summary>
        /// <returns></returns>
        public static FigureBase GetRandomFigure()
        {
            Random _randomizer = new Random();
            FigureBase figure = null;
            switch(_randomizer.Next(1,4))
            {
                case 1:
                    Circle circle = new Circle(_randomizer.Next(1,100));
                    figure = circle;
                    break;

                case 2:
                    Rectangle rectangle = new Rectangle
                        (
                            _randomizer.Next(1, 100),
                            _randomizer.Next(1, 100)
                        );
                    figure = rectangle;
                    break;
                case 3:
                    List<Triangle> ValidTriangles = new List<Triangle>()
                    {
                        new Triangle(3,4,5),
                        new Triangle(1,1,1),
                        new Triangle(6,8,10),
                        new Triangle(2,2,3),
                        new Triangle(10, 15, 11)
                    };
                    figure = ValidTriangles[_randomizer.Next(0, ValidTriangles.Count)];
                    break;
            }

            return figure;
        }

    }
}
