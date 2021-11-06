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
                _length = checkSize(value);
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
                _width = checkSize(value);
            }
        }

        /// <summary>
        /// поле для диагонали
        /// </summary>
        private double _diagonal;

        /// <summary>
        /// Диагональ прямоугольника
        /// </summary>
        public double Diagonal
        {
            get
            {
                return _diagonal;
            }
            set
            {
                _diagonal = checkSize(value);
            }
        }

        //TODO: Продумать для угла
        /// <summary>
        /// поле для угла между диагоналям
        /// </summary>
        private double _angle;

        public double Angle
        {
            get
            {
                return _angle;
            }
            set
            {
                _angle = Math.PI*checkSize(value)*1/180;
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


        //TODO: нужен конструктор класса 



    }
}
