using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryForGeometry
{
    public class GetPhrasesToConsole
    {
        /// <summary>
        /// 
        /// </summary>
        private static List<string> _listPhrasesForTriangle = new List<string>()
        {
            "Введите первую сторону", "Введите вторую сторону",
            "Введите третью сторону"
        };
        /// <summary>
        /// 
        /// </summary>
        private static List<string> _listPhrasesForCircle = new List<string>()
        {
            "Введите радиус"
        };

        /// <summary>
        /// 
        /// </summary>
        private static List<string> _listPhrasesForRectagle = new List<string>()
        {
            "Введите длину", "ширину"
        };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public static List<string> GetList(string line)
        {
            switch (line)
            {
                case "треугольник":
                    return _listPhrasesForTriangle;
                case "прямоугольник":
                    return _listPhrasesForRectagle;
                case "окружность":
                    return _listPhrasesForCircle;
                default :
                    throw new Exception();
            }

        }


    

       
        


    }
}
