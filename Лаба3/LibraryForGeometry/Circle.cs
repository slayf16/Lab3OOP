using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryForGeometry
{
    public class Circle : IFigure
    {
        
        /// <summary>
        /// поле для радиуса или диаметра
        /// </summary>
        private double _quantity;

        /// <summary>
        /// публичное поле для присваения радиуса
        /// </summary>
        public double Quantity
        {
            get
            {
                return _quantity;
            }

            set
            {
                _quantity = checkSize(value);
            }
        }


        /// <summary>
        /// Площаадь, если задан радиус
        /// </summary>
        /// <returns>Площадь окружности</returns>
        public double Square ()
        {
            
            return Math.PI * Quantity * Quantity;
        }


        /// <summary>
        /// площадь, если задан диаметр
        /// </summary>
        /// <returns>Площадь окружности</returns>
        public double SquareDiam()
        {
            return Math.PI * Quantity * Quantity * 1 / 4;
        }
        /// <summary>
        /// Конструктор класса 
        /// </summary>
        /// <param name="radius">поле радиуса</param>
        public Circle(double radius, size size)
        {
            Quantity = radius;
        }


        //TODO: подумать о надобности 
        /// <summary>
        /// для выбора диаметра 
        /// </summary>
       public enum size
        {
            Diam,
            Rad
        }

        /// <summary>
        /// метод для проверки размера
        /// </summary>
        /// <param name="number">принимаемое числовое значение размера фигуры</param>
        /// <returns>проверенное значение</returns>
        private static double checkSize(double number)
        {
            if(number<0)
            {
                throw new Exception("Размер должен быть больше 0");
            }
            else
            {
                return number;
            }
        }

    }
}
