using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryForGeometry
{
    /// <summary>
    /// Абстрактный треугольник
    /// </summary>
    public class Triangle : FigureBase
    {
        /// <summary>
        /// первая сторона треугольника 
        /// </summary>
        private double _sideOne;

        /// <summary>
        /// первая сторона треугольника 
        /// </summary>
        public double SideOne
        {
            get
            {
                return _sideOne;
            }
            set
            {
                _sideOne = checkSize(value);
            }
        }

        /// <summary>
        /// вторая сторона треугольника
        /// </summary>
        private double _sideTwo;

        /// <summary>
        /// вторая сторона треугольника
        /// </summary>
        public double SideTwo
        {
            get
            {
                return _sideTwo;
            }
            set
            {
                _sideTwo = checkSize(value);
            }
        }

        /// <summary>
        /// C
        /// </summary>
        private double _sideThree;

        /// <summary>
        /// _sideThree
        /// </summary>
        public double SideThree
        {
            get
            {
                return _sideThree;
            }
            set
            {
                _sideThree = checkSize(value);
            }
        }

        private double semiPerimeter(double a,double b,double c)
        {
            return (a + b + c) * 1 / 2;
        }
        


        /// <summary>
        /// Площадь треугольника
        /// </summary>
        /// <returns>Площадь треугольника</returns>
        public override double Square()
        {
            double p = semiPerimeter(_sideOne, _sideTwo, _sideThree);
            return Math.Sqrt(p*(p- _sideOne)*(p - _sideTwo)*(p- _sideThree)); 
        }
    }
}
