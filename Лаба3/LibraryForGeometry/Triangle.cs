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
        /// первая сторона треугольника 
        /// </summary>
        //public double SideOne
        //{
        //    get
        //    {
        //        if (_sideOne != 0)
        //        {
        //            return _sideOne;
        //        }
        //        else
        //        {
        //            throw new Exception("стороны 1 еще не сущствует");
        //        }
        //    }
        //    set
        //    {
        //        if(CheckSize(value)==true & _sideTwo != 0 & _sideThree != 0)
        //        {
        //            if(ValidTringle(SideOne, SideTwo, SideThree) == true)
        //            {
        //                _sideOne = value;
        //            }
        //            else
        //            {
        //                throw new Exception("треугольника не существует");
        //            }
        //        }
        //        else if(CheckSize(value))
        //        {
        //            _sideOne = value;
        //        }

        //    }
        //}

        /// <summary>
        /// вторая сторона треугольника
        /// </summary>
        private double _sideTwo;

        /// <summary>
        /// вторая сторона треугольника
        /// </summary>
        //public double SideTwo
        //{
        //    get
        //    {
        //        if (_sideTwo != 0)
        //        {
        //            return _sideTwo;
        //        }
        //        else
        //        {
        //            throw new Exception("стороны 2 еще не сущствует");
        //        }
        //    }
        //    set
        //    {
        //        if (CheckSize(value) == true && _sideOne != 0 && _sideTwo != 0)
        //        {
        //            if (ValidTringle(SideOne, SideTwo, SideThree) == true)
        //            {
        //                _sideTwo = value;
        //            }
        //            else
        //            {
        //                throw new Exception("треугольника не существует");
        //            }
        //        }
        //        else if (CheckSize(value))
        //        {
        //            _sideTwo = value;
        //        }

        //    }
        //}

        /// <summary>
        /// переменная для третьей стороны треугольника
        /// </summary>
        private double _sideThree;

        /// <summary>
        /// Третья сторона треугольника
        /// </summary>
        //public double SideThree
        //{
        //    get
        //    {
        //        if (_sideThree != 0)
        //        {
        //            return _sideThree;
        //        }
        //        else
        //        {
        //            throw new Exception("стороны 3 еще не сущствует");
        //        }
        //    }
        //    set
        //    {
        //        if (CheckSize(value) == true && _sideOne != 0 && SideTwo != 0)
        //        {
        //            if (ValidTringle(SideOne, SideTwo, SideThree) == true)
        //            {
        //                _sideThree = value;
        //            }
        //            else
        //            {
        //                throw new Exception("треугольника не существует");
        //            }
        //        }
        //        else if (CheckSize(value))
        //        {
        //            _sideThree = value;
        //        }

        //    }
        //}

        //TODO: RSDN+
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

        //TODO: RSDN+
        /// <summary>
        /// конструктор класса
        /// </summary>
        /// <param name="sideOne">первая сторона</param>
        /// <param name="sideTwo">вторая сторона</param>
        /// <param name="sideThree">третья сторона</param>
        public Triangle(double sideOne, double sideTwo, double sideThree)
        {
            if(sideOne>0 & sideTwo>0 & sideThree>0 & ValidTringle(sideOne,sideTwo,sideThree)==true)
            {
                _sideOne = sideOne;
                _sideTwo = sideTwo;
                _sideThree = sideThree;
            }

        }

        /// <summary>
        /// Пустой конструктор
        /// </summary>
      //  public Triangle() { }
        
            
       
       


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sideOne"></param>
        /// <param name="sideTwo"></param>
        /// <param name="sideThree"></param>
        /// <returns></returns>
        //public static bool ValidTringle(double sideOne, double sideTwo, double sideThree)
        //{
        //    if (sideOne + sideTwo > sideThree && sideOne + sideThree > sideTwo && sideThree + sideTwo > sideOne)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
        private bool ValidTringle(double sideOne, double sideTwo, double sideThree)
        {
            
            if (sideOne + sideTwo > sideThree && sideOne + sideThree > sideTwo && sideThree + sideTwo > sideOne)
            {
                return true;
            }
            else
            {
                throw new Exception("Треугольника не существует");              
            }
            
           
        }
    }
}
