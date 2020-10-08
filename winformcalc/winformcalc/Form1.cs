using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winformcalc
{
    public partial class Form1 : Form
    {
        private double firstValue = 0;
        private double secondValue = 0;
        private double thirdvalue = 0;
        char znak = '0';
        
        public int StringToInt(string a)
        {
            int b = Convert.ToInt32(a);
            return b;
        }
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            textBox1.Text += (sender as Button).Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
            
        }

        private void button11_Click(object sender, EventArgs e)//deleter
        {
            if(textBox1.Text is string & textBox1.Text.Length>1)
            {
                string a = textBox1.Text;
                a = Text.TrimEnd();
                textBox1.Clear();
                textBox1.Text += a;
            }
            else
            {
                return;
            }
            
        }

        private void button12_Click(object sender, EventArgs e)//знак +, -, /, x
        {
            thirdvalue = 0;
            if(firstValue==0)
            {
                firstValue = Convert.ToDouble(textBox1.Text);
            }
            

            if(znak=='0')
            {
                znak = (sender as Button).Text[0];
                textBox2.Text += textBox1.Text + znak;
                textBox1.Clear();
            }
            else
            {
                return;
            }

            
                


        }

        private void button16_Click(object sender, EventArgs e) //Равно
        {
            if(firstValue==0)
            {
                return;
            }
            else
            {

            }
            secondValue = Convert.ToDouble(textBox1.Text);
            switch(znak)
            {
                case '+': thirdvalue = firstValue + secondValue;
                    break;
                case '-': thirdvalue = firstValue - secondValue;
                    break;
                case 'x': thirdvalue = firstValue * secondValue;
                    break;
                case '/': thirdvalue = firstValue / secondValue;
                    break;

            }
            textBox3.Text = textBox2.Text +  textBox1.Text;
            textBox2.Text = thirdvalue.ToString();
            textBox1.Clear();
            firstValue = thirdvalue;
            znak = '0';
        }

        private void button10_Click(object sender, EventArgs e) // С = очистка. Красная кнопка
        {
            textBox1.Clear(); firstValue = 0;
            textBox2.Clear(); secondValue = 0;
            textBox3.Clear(); thirdvalue = 0;
            znak = '0';
        }

        public void DeleteLast()
        {
            textBox1.Text = Text.Substring(textBox1.Text.Length-1, textBox1.Text.Length);
        }
    }
}
