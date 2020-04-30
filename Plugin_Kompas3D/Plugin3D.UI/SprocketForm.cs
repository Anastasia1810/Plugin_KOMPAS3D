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
            //Инициализация формы
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
            //Перебор всех элементов списка
            foreach (var element in elements)
            {
                //Добавление параметра в словарь элементов TextBox формы
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
            //Преобразуем из object в TextBox
            var textBox = (TextBox)sender;
            //Блок ожидания ошибки
            try
            {
                //Окрашиваем поле в красный цвет
                textBox.BackColor = Color.Salmon;
                //Получаем текст из элемента TextBox
                var value = double.Parse(textBox.Text);
                //Определяем имя параметра соответствующего данному TextBox
                var parameterName = _formElements[textBox];
                //Присваиваем значение найденному параметру
                _sprocketParameters.Parameter(parameterName).Value = value;
                //Окрашиваем поле в зеленый цвет
                textBox.BackColor = Color.LightGreen;
                //При изменении радиуса внешней окружности
                if (parameterName == NameParameter.CircleRadius)
                {
                    _sprocketParameters.RecalculateCylinderRadius();
                    _sprocketParameters.RecalculateToothDepth();
                    CircleRadiusTextBox1.Text = _sprocketParameters.Parameter(NameParameter.CircleRadius).Value.ToString();
                }
                //При изменении радиуса цилиндра
                if (parameterName == NameParameter.CylinderRadius)
                {
                    _sprocketParameters.RecalculateHoleRadius();
                    CylinderRadiusTextBox2.Text = _sprocketParameters.Parameter(NameParameter.CylinderRadius).Value.ToString();
                }
                //При изменении радиуса отверстия
                if (parameterName == NameParameter.HoleRadius)
                {
                    _sprocketParameters.RecalculateExcavationDepth();
                    HoleRadiusTextBox3.Text = _sprocketParameters.Parameter(NameParameter.HoleRadius).Value.ToString();
                }

            }
            //Выполняется в случае выявления ошибки в try
            catch
            {
                //Окрашиваем поле в красный цвет
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
