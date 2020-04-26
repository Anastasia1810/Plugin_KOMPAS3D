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
using Parameter;

namespace Plugin3D.UI
{
    public partial class SprocketForm : Form
    {
        private SprocketParameters _sprocketParameters = new SprocketParameters();

        private Dictionary<TextBox, NameParameter> _formElements = new Dictionary<TextBox, NameParameter>();

        public SprocketForm()
        {
            InitializeComponent();
            // DefaultValue();

            var elements = new List<(TextBox textBox, NameParameter parameter)>
                  {
                     (CircleRadiusTextBox1, NameParameter.CircleRadius),
                     (CylinderRadiusTextBox2, NameParameter.CylinderRadius),
                     (HoleRadiusTextBox3, NameParameter.HoleRadius),
                     (CircleThicknessTextBox4, NameParameter.CircleThickness),
                     (CylinderThicknessTextBox5, NameParameter.CylinderThickness),
                     (ExeavationDepthTextBox6, NameParameter.ExcavationDepth),
                     (NumberOfTeethTextBox7, NameParameter.NumberOfTeeth)
                   };
            //Перебор всех элементов картежа
            foreach (var element in elements)
            {
                //Добавление параметра в словарь элементов TextBox формы
                _formElements.Add(element.textBox, element.parameter);
            }
        }



        private void TextBoxChanged(object sender, EventArgs e)
        {
            //Преобразуем из object в TextBox
            var textBox = (TextBox)sender;
            //Блок ожидания ошибки
            try
            {
                textBox.BackColor = Color.Salmon;
                //Получаем текст из элемента TextBox
                var value = double.Parse(textBox.Text);
                //Определяем имя параметра соответствующего
                //данному TextBox
                var parameterName = _formElements[textBox];
                //Присваиваем значение найденному параметру
                _sprocketParameters.Parameter(parameterName).Value = value;
                //Окрашиваем поле в зеленый цвет
                textBox.BackColor = Color.LightGreen;
                //При изменении радиуса внешней окружности

                if (parameterName == NameParameter.CircleRadius)
                {
                    _sprocketParameters.RecalculateCylinderRadius();
                    CircleRadiusTextBox1.Text = _sprocketParameters.Parameter(NameParameter.CircleRadius).Value.ToString();
                }

                if (parameterName == NameParameter.CylinderRadius)
                {
                    _sprocketParameters.RecalculateHoleRadius();
                    CylinderRadiusTextBox2.Text = _sprocketParameters.Parameter(NameParameter.CylinderRadius).Value.ToString();
                }

                if (parameterName == NameParameter.HoleRadius)
                {
                    _sprocketParameters.RecalculateExcavationDepth();
                    HoleRadiusTextBox3.Text = _sprocketParameters.Parameter(NameParameter.HoleRadius).Value.ToString();
                }

            }
            //Выполняется в случае выявления ошибки в try
            catch
            {
                //Окрашиваем полу в красный цвет
                textBox.BackColor = Color.Salmon;
            }
        }


        private void BuildButton_Click(object sender, EventArgs e)
        {
            SprocketManager sprocketManager = new SprocketManager(_sprocketParameters);
        }

        private void SprocketForm_Load(object sender, EventArgs e)
        {

        }
    }
}
