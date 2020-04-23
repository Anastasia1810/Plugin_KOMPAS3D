using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Plugin3D.UI
{
    public partial class SprocketForm : Form
    {
        public SprocketForm()
        {
            InitializeComponent();
            DefaultValue();
        }

        /// <summary>
        /// Функция, производящая автозаполнение полей данных звездочки
        /// </summary>
        private void DefaultValue()
        {
            CircleRadiusTextBox1.Text = "120";
            CylinderRadiusTextBox2.Text = "40";
            HoleRadiusTextBox3.Text = "15";
            CircleThicknessTextBox4.Text = "5";
            CylinderThicknessTextBox5.Text = "5";
            ExeavationDepthTextBox6.Text = "3";
            NumberOfTeethTextBox7.Text = "10"; 
        }

       

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
