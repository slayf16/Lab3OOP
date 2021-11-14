using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace LibraryForGeometry
{
    /// <summary>
    /// абстрактная фигура
    /// </summary>
    public abstract class FigureBase
    {
        /// <summary>
        /// метод для площади фигуры
        /// </summary>
        /// <returns>возвращает площадь фигуры</returns>
        public abstract double Square();

        /// <summary>
        /// метод для проверки полей
        /// </summary>
        /// <param name="number"></param>
        /// <returns>проверенное число</returns>
        public static double CheckSize(double number)
        {
            if (number < 0.0)
            {

                throw new Exception("Величина должна быть положительной");
            }
            else
            {
                return number;
            }
        }
    }
}
