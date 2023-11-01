using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace kvadratnoeuravnenie
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            this.Text = "Решение квадратного уравнения";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // очищаем поле вывода результата для нового результата
            textBox4.Clear();

            double a, b, c;

            try
            {
                // Пробуем получить значения параметров и преобразовать их из текста в дабл
                a = Convert.ToDouble(textBox1.Text);
                b = Convert.ToDouble(textBox2.Text);
                c = Convert.ToDouble(textBox3.Text);
            }
            // Если введенные данные не являются числами
            catch (FormatException)
            {
                textBox4.Text = "Ошибка: Введите числовые значения в поля.";
                return; // Выйти из метода, так как входные данные недопустимы.
            }
            // Если введенные данные выходят за границу double
            catch (OverflowException)
            {
                textBox4.Text = "Ошибка: Введенные числа слишком большие или слишком маленькие.";
                return; // Выйти из метода, так как входные данные вызывают переполнение.
            }

            if (a == 0)
            {
                if (b != 0)
                {
                    // Если уравнение линейное, то находим его решение
                    double x = -c / b;
                    textBox4.Text = "x = " + x;
                    return;
                }
                else
                {
                    if (c == 0)
                    {
                        textBox4.Text = "Решение - любое число";
                        return;
                    }
                    else {
                        textBox4.Text = "Решений нет";
                        return;
                    }
                }
            }
            
            double discriminant;
            double x1, x2;
            // Считаем дискриминант
            discriminant = Math.Pow(b, 2) - 4 * a * c;

            if (discriminant > 0)
            {
                // Ищем корни в случае двух корней и выводим их 
                x1 = (-b - Math.Sqrt(discriminant)) / (2 * a);
                x2 = (-b + Math.Sqrt(discriminant)) / (2 * a);
                textBox4.Text = textBox4.Text + "x1=" + x1 + System.Environment.NewLine + "x2=" + x2;
            }

            else if (discriminant == 0)
            {
                // Ищем корни в случае одного корня и выводим его
                x1 = -b / (2 * a);
                textBox4.Text = textBox4.Text + "x=" + x1;
            }

            else textBox4.Text = "корней нет";


        }
        private void button2_Click(object sender, EventArgs e)
        {
            // Очищаем все поля по нажатию кнопки сброс
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }
    }
}
