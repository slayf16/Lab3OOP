using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryForGeometry
{
    /// <summary>
    /// окружность
    /// </summary>
    public class Circle : FigureBase
    {
        /// <summary>
        /// поле для радиуса или диаметра
        /// </summary>
        private double _radius;

        /// <summary>
        /// публичное поле для присваения радиуса
        /// </summary>
        public double Radius
        {
            get
            {
                return _radius;
            }
            set
            {
                _radius = CheckSize(value);
            }
        }

        /// <summary>
        /// Площаадь, если задан радиус
        /// </summary>
        /// <returns>Площадь окружности</returns>
        public override double Square()
        {

            return Math.PI * Radius * Radius;
        }

        /// <summary>
        /// Конструктор класса 
        /// </summary>
        /// <param name="radius">поле радиуса</param>
        public Circle(double radius)
        {
            Radius = radius;
        }

        /// <summary>
        /// пустой конструктор
        /// </summary>
        public Circle() { }

        /// <summary>
        /// Информация об окружности
        /// </summary>
        /// <returns>возвращается сформированная строка с информацией</returns>
        public override string GetInfo()
        {
            return $"Radius: {_radius}. "
                + $"Square: {Math.Round(this.Square(), 2)}";
        }

        /// <summary>
        /// метод для выявления названия типа фигуры
        /// </summary>
        /// <returns>строка с информацией о типе фигуры</returns>
        public override string GetName()
        {
            return "Circle";
        }
    }
}