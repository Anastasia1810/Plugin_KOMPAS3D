using System.Collections.Generic;

namespace Parameter
{
    /// <summary>
    /// Класс, который хранит словарь параметров модели и реализует методы 
    /// перерасчета значений параметров
    /// </summary>
    public class SprocketParameters
    {

        /// <summary>
        /// Поле хранит словарь параметров звездочки
        /// </summary>
        private Dictionary<NameParameter, Parameter> _parameters = new Dictionary<NameParameter, Parameter>();

        /// <summary>
        /// Возвращает параметр в соответствии с заданным именем параметра
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Parameter Parameter(NameParameter name)
        {
            return _parameters[name];
        }

        /// <summary>
        /// Перерасчет радиуса цилиндра
        /// </summary>
        public void RecalculateCylinderRadius()
        {
            var maxCylinderRadius = Parameter(NameParameter.CircleRadius).Value / 2;
            Parameter(NameParameter.CylinderRadius).MaxValue = maxCylinderRadius;

            if (Parameter(NameParameter.CylinderRadius).Value > maxCylinderRadius)
            {
                Parameter(NameParameter.CylinderRadius).Value = maxCylinderRadius;
            }
        }

        /// <summary>
        /// Перерасчет радиуса отверстия
        /// </summary>
        public void RecalculateHoleRadius()
        {
            var maxHoleRadius = Parameter(NameParameter.CylinderRadius).Value / 2;
            Parameter(NameParameter.HoleRadius).MaxValue = maxHoleRadius;

            if (Parameter(NameParameter.HoleRadius).Value > maxHoleRadius)
            {
                Parameter(NameParameter.HoleRadius).Value = maxHoleRadius;
            }
        }

        /// <summary>
        /// Перерасчет длины выемки
        /// </summary>
        public void RecalculateExcavationDepth()
        {
            var maxHeight = Parameter(NameParameter.HoleRadius).Value / 2;
            Parameter(NameParameter.ExcavationDepth).MaxValue = maxHeight;

            if (Parameter(NameParameter.ExcavationDepth).Value > maxHeight)
            {
                Parameter(NameParameter.ExcavationDepth).Value = maxHeight;
            }
        }

        public SprocketParameters()
        {
            //Создаем список со значениями параметров звездочки
            var values = new List<(NameParameter name, double min, double max)>
            {
                (NameParameter.CircleRadius, 60, 300),
                (NameParameter.CylinderRadius, 20, 150),
                (NameParameter.HoleRadius, 10, 75),
                (NameParameter.CircleThickness, 5, 20),
                (NameParameter.CylinderThickness, 0, 40),
                (NameParameter.ExcavationDepth, 0, 18),
                (NameParameter.NumberOfTeeth, 7, 30)

            };
            //Перебираем все значения звездочки
            foreach (var value in values)
            {
                //Создание нового параметра
                Parameter parameter = null;
                //Создаем параметр и передаем значения в конструктор (среднее значение максимума 
                //и минимума параметра)
                parameter = new Parameter(value.name.ToString(), value.min, value.max, (value.min + value.max) / 2);
                //Добавляем созданный параметр в словарь параметров
                _parameters.Add(value.name, parameter);
            }

        }
    }
}