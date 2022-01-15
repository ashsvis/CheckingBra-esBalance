using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheckingBraсesBalance
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void открытьToolStripButton_Click(object sender, EventArgs e)
        {
            int braсesCount = 0;
            lbMessages.Items.Clear();

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var sb = new StringBuilder();
                using (StreamReader sr = new StreamReader(new FileStream(openFileDialog1.FileName, FileMode.Open)))
                {
                    while (sr.Peek() >= 0)
                    {
                        var ch = (char)sr.Read();

                        sb.Append(ch);

                        if (ch == '{')
                            braсesCount++;
                        else if (ch == '}')
                            braсesCount--;
                    }
                }
                textBox1.Text = sb.ToString();
            }
            lbMessages.Items.Add($"Баланс фигурных скобок: {braсesCount}");
            if (braсesCount > 0)
                lbMessages.Items.Add($"Имеются лишние открывающие фигурные скобки.");
            else if (braсesCount < 0)
                lbMessages.Items.Add($"Имеются лишние закрывающие фигурные скобки.");
        }
    }
}
