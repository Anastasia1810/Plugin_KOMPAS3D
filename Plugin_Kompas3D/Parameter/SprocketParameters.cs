using System.Collections.Generic;

namespace ModelParameter
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
        /// Присваивание максимального(минимального) значения зависимым параметрам,
        /// если они больше максимального(меньше минимального) значения 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="maxValue"></param>
        public void RecalculateParameter(double value, double maxValue, double minValue)
        {
            if (value > maxValue)
            {
                value = maxValue;
            }

            if (value < minValue)
            {
                value = minValue;
            }
        }

        
        /// <summary>
        /// Конструктор класса SprocketParameters
        /// </summary>
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
                (NameParameter.NumberOfTeeth, 7, 30),
                (NameParameter.ToothDepht, 6, 50)

            };
            //Перебираем все значения звездочки
            foreach (var value in values)
            {
                Parameter parameter = null;
                parameter = new Parameter(value.name.ToString(), value.min, value.max, (value.min + value.max) / 2);
                _parameters.Add(value.name, parameter);
            }

        }
    }
}