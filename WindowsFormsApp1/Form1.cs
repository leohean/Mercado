using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        DateTime horario, data;
        double n4,n6;
        public Form1()
        {
            InitializeComponent();      
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
            
                double n1,n2,n3;
                n1 = double.Parse(textBox2.Text);               
                n2 = double.Parse(textBox3.Text);
                n3 = n1 * n2;
                n4 += n3;
                n6 = n4;
                string valor = n3.ToString();
                
                listBox1.Items.Add("Produto: " + textBox1.Text);
                listBox1.Items.Add("Valor unit.: " + textBox2.Text);
                listBox1.Items.Add("Qtd.: " + textBox3.Text);
                listBox1.Items.Add("Valor: R$" + valor);
                label5.Text = "TOTAL: " + n4.ToString();

                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
            }

            catch
            {
                MessageBox.Show("Ocorreu algum erro, tente novamente", "ERRO");
            }
           

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox3.Clear();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            horario = DateTime.Now;
            label4.Text = "Horário:" + horario.ToString("hh\\:mm\\:ss");
            data = DateTime.Now;
            label6.Text = "Data:" + data.ToString("dd\\/MM\\/yyyy");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            double n5;
            n5 = double.Parse(textBox4.Text);
            if (n5 < n6)
            {
                n6 =n6-n5;
                label7.Text = "A SER PAGO: R$"+n6.ToString();
                label9.Text = "R$0";
            }
            if (n6 < n5)
            {
                n6 = n6 - n5;
                label7.Text = "A SER PAGO: R$0";
                n6 = Math.Abs(n6);
                label9.Text = "TROCO: R$" + n6.ToString();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            StreamWriter arquivo;
            string[] mercado = listBox1.Items.OfType<string>().ToArray();

            if (System.IO.File.Exists("D:\\mercado.txt"))
                File.Delete("D:\\mercado.txt");
            
            arquivo = new StreamWriter("D:\\mercado.txt");

            for (int i= 0; i<mercado.Length; i++)
                arquivo.WriteLine(mercado[i]);

            arquivo.WriteLine("Valor da compra: R$"+n4);

            arquivo.Close();

            MessageBox.Show("Compra finalizada com sucesso!","Finalização");
        }
    }
}
