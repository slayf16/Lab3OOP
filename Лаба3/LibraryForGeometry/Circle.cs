using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryForGeometry
{
    /// <summary>
    /// абстрактная окружность
    /// </summary>
    public class Circle : FigureBase
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
        public override double Square ()
        {
            
            return Math.PI * Quantity * Quantity;
        }

        
        /// <summary>
        /// площадь, если задан диаметр, на будущее
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
        
       


    }
}
