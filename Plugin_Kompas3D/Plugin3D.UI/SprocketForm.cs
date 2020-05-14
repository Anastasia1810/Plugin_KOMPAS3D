using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Builder;
using ModelParameter;

namespace Plugin3D.UI
{
    public partial class SprocketForm : Form
    {
        /// <summary>
        /// Поле хранит все параметры звездочки
        /// </summary>
        private SprocketParameters _sprocketParameters = new SprocketParameters();

        /// <summary>
        /// Хранит словарь соответствий TextBox и параметров моделей
        /// </summary>
        private Dictionary<TextBox, NameParameter> _formElements = new Dictionary<TextBox, NameParameter>();

        public SprocketForm()
        {
            InitializeComponent();

            //Создание списка элементов TextBox существующих на форме
            var elements = new List<(TextBox textBox, NameParameter parameter)>
                  {
                     (CircleRadiusTextBox1, NameParameter.CircleRadius),
                     (CylinderRadiusTextBox2, NameParameter.CylinderRadius),
                     (HoleRadiusTextBox3, NameParameter.HoleRadius),
                     (CircleThicknessTextBox4, NameParameter.CircleThickness),
                     (CylinderThicknessTextBox5, NameParameter.CylinderThickness),
                     (ExeavationDepthTextBox6, NameParameter.ExcavationDepth),
                     (NumberOfTeethTextBox7, NameParameter.NumberOfTeeth),
                     (ToothDephtTextBox8, NameParameter.ToothDepht)
                   };
            foreach (var element in elements)
            {
                _formElements.Add(element.textBox, element.parameter);
            }
        }

        /// <summary>
        /// Присваивает параметру значение из соответствующего элемента TextBox
        /// при изменении пользователем значения Text для TextBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxChanged(object sender, EventArgs e)
        {
            var textBox = (TextBox)sender;
            //Блок ожидания ошибки
            try
            {
                textBox.BackColor = Color.Salmon;
                var value = double.Parse(textBox.Text);
                var parameterName = _formElements[textBox];
                _sprocketParameters.Parameter(parameterName).Value = value;
                textBox.BackColor = Color.LightGreen;
                //При изменении радиуса внешней окружности
                if (parameterName == NameParameter.CircleRadius)
                {
                    var maxCylinderRadius = 
                        _sprocketParameters.Parameter(NameParameter.CircleRadius).Value / 2;
                    _sprocketParameters.Parameter(NameParameter.CylinderRadius).MaxValue = maxCylinderRadius;
                    var minCylinderRadius = _sprocketParameters.Parameter(NameParameter.CylinderRadius).MinValue;
                    _sprocketParameters.RecalculateParameter(value, maxCylinderRadius,minCylinderRadius);

                    var maxToothDepth = _sprocketParameters.Parameter(NameParameter.CircleRadius).Value / 6;
                    _sprocketParameters.Parameter(NameParameter.ToothDepht).MaxValue = maxToothDepth;
                    var minToothDepth = _sprocketParameters.Parameter(NameParameter.CircleRadius).Value / 10;
                    _sprocketParameters.Parameter(NameParameter.ToothDepht).MinValue = minToothDepth;
                    _sprocketParameters.RecalculateParameter(value,maxToothDepth,minToothDepth);

                    CircleRadiusTextBox1.Text = 
                        _sprocketParameters.Parameter(NameParameter.CircleRadius).Value.ToString();
                }
                //При изменении радиуса цилиндра
                if (parameterName == NameParameter.CylinderRadius)
                {
                    var maxHoleRadius = 
                        _sprocketParameters.Parameter(NameParameter.CylinderRadius).Value / 2;
                    _sprocketParameters.Parameter(NameParameter.HoleRadius).MaxValue = maxHoleRadius;
                    var minHoleRadius = _sprocketParameters.Parameter(NameParameter.HoleRadius).MinValue;
                    _sprocketParameters.RecalculateParameter(value, maxHoleRadius,minHoleRadius);
                    CylinderRadiusTextBox2.Text = 
                        _sprocketParameters.Parameter(NameParameter.CylinderRadius).Value.ToString();
                }
                //При изменении радиуса отверстия
                if (parameterName == NameParameter.HoleRadius)
                {
                    var maxHeight = _sprocketParameters.Parameter(NameParameter.HoleRadius).Value / 4;
                    _sprocketParameters.Parameter(NameParameter.ExcavationDepth).MaxValue = maxHeight;
                    var minHeight = _sprocketParameters.Parameter(NameParameter.ExcavationDepth).MinValue;
                    _sprocketParameters.RecalculateParameter(value, maxHeight,minHeight);
                    HoleRadiusTextBox3.Text = 
                        _sprocketParameters.Parameter(NameParameter.HoleRadius).Value.ToString();
                }

            }
            //Выполняется в случае выявления ошибки в try
            catch
            {
                textBox.BackColor = Color.Salmon;
            }
        }

        /// <summary>
        /// При нажатии на кнопку "Построить", метод для создания нового экземпляра класса SprocketManager
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BuildButton_Click(object sender, EventArgs e)
        {
            SprocketManager sprocketManager = new SprocketManager(_sprocketParameters);
        }

       
    }
}
