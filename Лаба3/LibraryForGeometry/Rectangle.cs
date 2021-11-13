using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryForGeometry
{
    /// <summary>
    /// абстрактный прямоугольник
    /// </summary>
    public class Rectangle : FigureBase
    {
        /// <summary>
        /// поле для длины
        /// </summary>
        private double _length;

        /// <summary>
        /// Длина прямоугольника
        /// </summary>
        public double Length
        {
            get
            {
                return _length;
            }
            set
            {
                if (CheckSize(value))
                {
                    _length = value;
                }
            }
        }

        /// <summary>
        /// поле для ширины 
        /// </summary>
        private double _width;

        /// <summary>
        /// Ширина прямоугольника
        /// </summary>
        public double Width
        {
            get
            {
                return _width;
            }
            set
            {
                if (CheckSize(value))
                {
                    _width = value;
                }
            }
        }      
             


        /// <summary>
        ///  Площадь прямоугольника
        /// </summary>
        /// <returns>площадь прямоугольника</returns>
        public override double Square()
        {
            return Length * Width;
        }


        /// <summary>
        /// конструктор класса
        /// </summary>
        /// <param name="length">длина</param>
        /// <param name="width">ширина</param>
        public Rectangle (double length, double width)
        {
            Length = length;
            Width = width;
        }

        /// <summary>
        /// пустой конструктор
        /// </summary>
        public Rectangle() { }

    }
}
