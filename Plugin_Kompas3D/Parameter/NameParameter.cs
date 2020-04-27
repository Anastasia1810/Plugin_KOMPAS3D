using System;

namespace ModelParameter
{
    /// <summary>
    /// Перечисление. Хранит названия параметров модели
    /// </summary>
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
