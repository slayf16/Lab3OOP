using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryForGeometry
{
    /// <summary>
    /// Треугольник
    /// </summary>
    public class Triangle : FigureBase
    {
     
        /// <summary>
        /// первая сторона треугольника 
        /// </summary>
        private double _sideOne;

        /// <summary>
        /// вторая сторона треугольника
        /// </summary>
        private double _sideTwo;   

        /// <summary>
        /// переменная для третьей стороны треугольника
        /// </summary>
        private double _sideThree;

        /// <summary>
        /// метод для вычисления полупериметра
        /// </summary>
        /// <param name="sideOne">первая сторона</param>
        /// <param name="sideTwo">вторая сторона</param>
        /// <param name="sideThree">третья сторона</param>
        /// <returns>полупериметр</returns>
        private double SemiPerimeter(double sideOne,double sideTwo,double sideThree)
        {
            return (sideOne + sideTwo + sideThree) * 1.0 / 2.0;
        }       

        /// <summary>
        /// Площадь треугольника
        /// </summary>
        /// <returns>Площадь треугольника</returns>
        public override double Square()
        {
            double p = SemiPerimeter(_sideOne, _sideTwo, _sideThree);
            return Math.Sqrt(p*(p- _sideOne)*(p - _sideTwo)*(p- _sideThree)); 
        }
        
        /// <summary>
        /// конструктор класса
        /// </summary>
        /// <param name="sideOne">первая сторона</param>
        /// <param name="sideTwo">вторая сторона</param>
        /// <param name="sideThree">третья сторона</param>
        public Triangle(double sideOne, double sideTwo, double sideThree)
        {
            if(sideOne>0 & sideTwo>0 & sideThree>0 & 
                ValidTringle(sideOne,sideTwo,sideThree)==true)
            {
                _sideOne = sideOne;
                _sideTwo = sideTwo;
                _sideThree = sideThree;
            }
        }
       

        /// <summary>
        /// проверка существования треугольника
        /// </summary>
        /// <param name="sideOne">первая сторона</param>
        /// <param name="sideTwo">вторая сторона</param>
        /// <param name="sideThree">третья сторона</param>
        /// <returns>либо подтвержадает, либо выдает ошибку</returns>
        private bool ValidTringle(double sideOne, double sideTwo, double sideThree)
        {
            
            if (sideOne + sideTwo > sideThree && sideOne + sideThree > sideTwo
                && sideThree + sideTwo > sideOne)
            {
                return true;
            }
            else
            {
                throw new Exception("Треугольника не существует");              
            }                       
        }


        /// <summary>
        /// Информация об окружности
        /// </summary>
        /// <returns>возвращается сформированная строка с информацией</returns>
        public override string GetInfo()
        {

            return $"Side 1: {_sideOne}, "
                + $"side 2: {_sideTwo}, "
                + $"side 3: {_sideThree}. "
                + $"Square: {Math.Round(this.Square(),2)}";
        }

        /// <summary>
        /// метод для выявления названия типа фигуры
        /// </summary>
        /// <returns>строка с информацией о типе фигуры</returns>
        public override string GetName()
        {
            return "Triangle";
        }
    }
}
