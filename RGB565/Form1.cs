using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RGB565
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int RGB565 = 0;
            int RGB888 = Convert.ToInt32(textBox1.Text, 16);
            int byte_r = (RGB888 & 0xFF0000)>>16;
            int byte_g = (RGB888 & 0xFF00)>>8;
            int byte_b = RGB888 & 0xFF;

            //byte_r = (byte_r & 0x3E) >> 1;
            //byte_g = (byte_g & 0x3F);
            //byte_b = (byte_b & 0x3E) >> 1;

            byte_r = (byte_r * 249 + 1014) >> 11;
            byte_g = (byte_g * 253 + 505) >> 10;
            byte_b = (byte_b * 249 + 1014) >> 11;

            RGB565 = RGB565 | (byte_r<<11);
            RGB565 = RGB565 | (byte_g<<5);
            RGB565 = RGB565 | byte_b;

            textBox2.Text = String.Format("{0:X}", RGB565);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string item = textBox1.Text;
            int n = 0;
            
            if (textBox1.TextLength < 1)
            {
                button1.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
            }
            
            if (!int.TryParse(item, System.Globalization.NumberStyles.HexNumber, System.Globalization.NumberFormatInfo.CurrentInfo, out n) &&
              item != String.Empty)
            {
                textBox1.Text = item.Remove(item.Length - 1, 1);
                textBox1.SelectionStart = textBox1.Text.Length;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = false;

            textBox1.CharacterCasing = CharacterCasing.Upper;
            textBox2.CharacterCasing = CharacterCasing.Upper;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int RGB888 = 0x000000;
            int RGB565 = Convert.ToInt32(textBox2.Text, 16);
            int byte_r = (RGB565 & 0xF800) >> 11;
            int byte_g = (RGB565 & 0x07E0) >> 5;
            int byte_b = RGB565 & 0x1F;

            byte_r = (byte_r * 527 + 23) >> 6;
            byte_g = (byte_g * 259 + 33) >> 6;
            byte_b = (byte_b * 527 + 23) >> 6;

            RGB888 = RGB888 | (byte_r << 16);
            RGB888 = RGB888 | (byte_g << 8);
            RGB888 = RGB888 | (byte_b);

            textBox1.Text = String.Format("{0:X}", RGB888);
        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {
            string item = textBox2.Text;
            int n = 0;
            
            if (textBox2.TextLength < 1)
            {
                button2.Enabled = false;
            }
            else
            {
                button2.Enabled = true;
            }

            if (!int.TryParse(item, System.Globalization.NumberStyles.HexNumber, System.Globalization.NumberFormatInfo.CurrentInfo, out n) &&
              item != String.Empty)
            {
                textBox2.Text = item.Remove(item.Length - 1, 1);
                textBox2.SelectionStart = textBox2.Text.Length;
            }
        }
    }
}
