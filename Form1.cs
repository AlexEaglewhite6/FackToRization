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

namespace Факторизация
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button1.Enabled = false;
        }



        private void button1_Click(object sender, EventArgs e)
        {
            int n = Convert.ToInt32(textBox1.Text);
            string output = string.Empty;
            if (n == 1) textBox3.Text = "1";
            else if(n == 0) textBox3.Text = "0";
            else
            {
                Dictionary<int, int> dicOfDegree = new Dictionary<int, int>();
                for (int i = 2; i < n + 1; i++)
                {
                    int k = 2;
                    int j = i;
                    while (j > 1)
                    {
                        while (j % k == 0)
                        {
                            try
                            {
                                dicOfDegree.Add(k, 0);
                            }
                            catch { }
                            finally
                            {
                                dicOfDegree[k]++;
                                j /= k;
                            }
                        }
                        k++;
                    }
                }
                foreach (var d in dicOfDegree.OrderBy(key => key.Key))
                {
                    if (d.Value == 1) output += $"{d.Key} ";
                    else output += $"{d.Key}^{d.Value} ";

                }
                output = output.Replace(" ", "*");
                textBox3.Text = output.Substring(0, output.Length - 1);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty || !textBox1.Text.All(char.IsDigit)) button1.Enabled = false;
            else button1.Enabled = true;
        }
    }
}
