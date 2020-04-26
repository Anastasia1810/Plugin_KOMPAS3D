using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parameter
{
    /// <summary>
    /// Хранит данные одного параметра (Название, текущее значение и границы значения)
    /// </summary>
    public class Parameter
    {
        /// <summary>
        /// Поле хранит минимальное значение параметра
        /// </summary>
        private double _minValue;

        /// <summary>
        /// Поле хранит максимальное значение параметра
        /// </summary>
        private double _maxValue;

        /// <summary>
        /// Поле хранит текущее значение параметра
        /// </summary>
        private double _value;

        /// <summary>
        /// Поле хранит название параметра
        /// </summary>
        private string _name;

        /// <summary>
        /// 
        /// </summary>
        public double MinValue { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public double MaxValue { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public double Value
        {
            get
            {
                return _value;
            }

            set
            {
                if (value.CompareTo(MinValue) < 0 || value.CompareTo(MaxValue) > 0)
                {
                    throw new ArgumentException("Значение не входит в диапозон от" + _minValue + "до" + _maxValue);
                }
                else
                {
                    _value = value;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="minValue">Минимальное значение</param>
        /// <param name="maxValue">Максимальное значение</param>
        /// <param name="value">Введенное значение</param>
        /// <param name="name">Название параметра</param>
        public Parameter(string name,double minValue, double maxValue, double value)
        {
            Name = name;
            MinValue = minValue;
            MaxValue = maxValue;
            Value = value;
        }
    }
}
