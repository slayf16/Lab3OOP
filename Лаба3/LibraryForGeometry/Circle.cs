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
        /// поле
        /// </summary>
        private double _radius;

        public double Radius
        {
            get
            {
                return _radius;
            }

            set
            {
                if (value > 0)
                {
                    _radius = value;
                }
                else
                {
                    throw new Exception("Радиус должен быть больше нуля");
                }
            }
        }

        public double Square ()
        {
            return Math.PI * Radius * Radius;
        }

        public Circle(double radius)
        {
            Radius = radius;
        }

       

    }
}
