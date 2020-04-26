using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parameter
{
    public enum NameParameter
    {
        /// <summary>
        /// Радиус внешней окружности
        /// </summary>
        CircleRadius,

        /// <summary>
        /// Радиус цилиндра
        /// </summary>
        CylinderRadius,

        /// <summary>
        /// Радиус отверстия
        /// </summary>
        HoleRadius,

        /// <summary>
        /// Толщина внешней части звездочки
        /// </summary>
        CircleThickness,

        /// <summary>
        /// Толщина цилиндра
        /// </summary>
        CylinderThickness,

        /// <summary>
        /// Глубина шпоночной выемки
        /// </summary>
        ExcavationDepth,

        /// <summary>
        /// Количество зубьев
        /// </summary>
        NumberOfTeeth
    }
}
