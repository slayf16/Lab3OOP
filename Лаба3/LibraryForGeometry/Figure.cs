using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace LibraryForGeometry
{
    public interface IFigure
    {
        /// <summary>
        /// метод для площади фигуры
        /// </summary>
        /// <returns>возвращает площадь фигуры</returns>
        double Square();    
    }
}
