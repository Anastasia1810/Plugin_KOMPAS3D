using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parameter
{
    public class SprocketParameters
    {
     
        /// <summary>
        /// Словарь параметров звездочки
        /// </summary>
        private Dictionary<NameParameter, Parameter> _parameters = new Dictionary<NameParameter, Parameter>();

        /// <summary>
        /// Минимальный радиус внешней окружности
        /// </summary>
        public const double CircleRadiusMin = 60;

        /// <summary>
        /// Максимальный радиус внешней окружности
        /// </summary>
        public const double CircleRadiusMax = 300;

        /// <summary>
        /// Минимальный радиус цилиндра
        /// </summary>
        public const double CylinderRadiusMin = 20;

        /// <summary>
        /// Максимальный радиус цилиндра
        /// </summary>
        public const double CylinderRadiusMax = 150;

        /// <summary>
        /// Минимальный радиус отверстия
        /// </summary>
        public const double HoleRadiusMin = 10;

        /// <summary>
        /// Максимальный радиус отверстия
        /// </summary>
        public const double HoleRadiusMax = 75;

        /// <summary>
        /// Минимальная толщина внешней части 
        /// </summary>
        public const double CircleThicknessMin = 5;

        /// <summary>
        /// Максимальная толщина внешней части
        /// </summary>
        public const double CircleThicknessMax = 20;

        /// <summary>
        /// Минимальная толщина цилиндра
        /// </summary>
        public const double CylinderThicknessMin = 0;

        /// <summary>
        /// Максимальная толщина цилиндра
        /// </summary>
        public const double CylinderThicknessMax = 40;

        /// <summary>
        /// Минимальная глубина шпоночной выемки
        /// </summary>
        public const double ExcavationDepthMin = 0;

        /// <summary>
        /// Максимальная глубина шпоночной выемки
        /// </summary>
        public const double ExcavationDepthMax = 18;

        /// <summary>
        /// Минимальное количество зубьев
        /// </summary>
        public const double NumberOfTeethMin = 7;

        /// <summary>
        /// Максимальное количество зубьев
        /// </summary>
        public const double NumberOfTeethMax = 30;

        /// <summary>
        /// 
        /// </summary>
        public void DefaultValue()
        { 
            
        }


    }
}
