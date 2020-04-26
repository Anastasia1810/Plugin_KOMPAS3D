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
           // _parameters = new Dictionary<NameParameter, Parameter>();
            //Создаем кортеж со значениями параметров звездочки
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
                //Создаем параметр и передаем значения в конструктор
                parameter = new Parameter(value.name.ToString(), value.min, value.max, (value.min + value.max) / 2);
               //parameter = new Parameter(value.name.ToString(), value.min, value.max, value.min);
               //parameter = new Parameter(value.name.ToString(), value.min, value.max, value.max);
                //Добавляем созданный параметр в словарь параметров
                _parameters.Add(value.name, parameter);
            }

        }
    }
}