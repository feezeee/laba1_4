using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zalpa
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private Bitmap bm;
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog fDialog = new OpenFileDialog();
            fDialog.Filter = "Графические файлы jpg| *.jpg| Графические файлы bmp|*.bmp|Графические файлы png| *. png | Графические файлы gif|*.gif";
            if (fDialog.ShowDialog() == DialogResult.OK)
            {
                radioButton4.Checked = false;
                radioButton5.Checked = false;
                radioButton8.Checked = false;
                try
                {
                    System.IO.FileStream fs = new System.IO.FileStream(fDialog.FileName, System.IO.FileMode.Open);
                    bm = new Bitmap(fs);
                    pictureBox1.Image = bm;
                    fDialog.Dispose();
                }
                catch
                {
                    MessageBox.Show("Возможно, файл уже используется другим приложением", "Ошибка!",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                }
            }
        }
        private void radioButton4_CheckedChanged_1(object sender, EventArgs e)
        {
            if ((radioButton4.Checked == true) && (pictureBox1.Image != null))
            {
                groupBox1.Enabled = false;
                groupBox2.Enabled = false;
                button1.Enabled = false;
                Bitmap bmR = (Bitmap)bm.Clone();
                for (int i = 0; i < bm.Width; i++)
                    for (int j = 0; j < bm.Height; j++)
                    {
                        System.Drawing.Color color = bm.GetPixel(i, j);
                        if (radioButton3.Checked == true)
                        {
                            bmR.SetPixel(i, j, System.Drawing.Color.FromArgb(color.R, 0, 0));
                        }
                        else
                        {
                            bmR.SetPixel(i, j, System.Drawing.Color.FromArgb(color.R, color.R, color.R));
                        }
                    }

                pictureBox1.Image = bmR;
                groupBox2.Enabled = true;
                groupBox1.Enabled = true;
                button1.Enabled = true;
            }
            else
            {
                radioButton4.Checked = false;
            }
        }

        private void radioButton5_CheckedChanged_1(object sender, EventArgs e)
        {
            if ((radioButton5.Checked == true) && (pictureBox1.Image != null))
            {
                groupBox1.Enabled = false;
                groupBox2.Enabled = false;
                button1.Enabled = false;
                Bitmap bmG = (Bitmap)bm.Clone();
                for (int i = 0; i < bm.Width; i++)
                    for (int j = 0; j < bm.Height; j++)
                    {
                        System.Drawing.Color color = bm.GetPixel(i, j);
                        if (radioButton3.Checked == true)
                        {
                            bmG.SetPixel(i, j, System.Drawing.Color.FromArgb(0, color.G, 0));
                        }
                        else
                        {
                            bmG.SetPixel(i, j, System.Drawing.Color.FromArgb(color.G, color.G, color.G));
                        }
                    }
                pictureBox1.Image = bmG;
                groupBox2.Enabled = true;
                groupBox1.Enabled = true;
                button1.Enabled = true;

            }
            else
            {
                radioButton5.Checked = false;
            }
        }

        private void radioButton8_CheckedChanged_1(object sender, EventArgs e)
        {
            if ((radioButton8.Checked == true) && (pictureBox1.Image != null))
            {
                groupBox1.Enabled = false;
                groupBox2.Enabled = false;
                button1.Enabled = false;
                Bitmap bmB = (Bitmap)bm.Clone();
                for (int i = 0; i < bm.Width; i++)
                    for (int j = 0; j < bm.Height; j++)
                    {
                        System.Drawing.Color color = bm.GetPixel(i, j);
                        if (radioButton3.Checked == true)
                        {
                            bmB.SetPixel(i, j, System.Drawing.Color.FromArgb(0, 0, color.B));

                        }
                        else
                        {
                            bmB.SetPixel(i, j, System.Drawing.Color.FromArgb(color.B, color.B, color.B));

                        }
                    }
                pictureBox1.Image = bmB;
                groupBox2.Enabled = true;
                groupBox1.Enabled = true;
                button1.Enabled = true;
            }
            else
            {
                radioButton8.Checked = false;

            }
        }

        private void radioButton3_CheckedChanged_1(object sender, EventArgs e)
        {

            if ((radioButton3.Checked == true) && (pictureBox1.Image != null))
            {
                if (radioButton8.Checked == true)
                {
                    radioButton8_CheckedChanged_1(sender, e);
                }
                else if (radioButton4.Checked == true)
                {
                    radioButton4_CheckedChanged_1(sender, e);
                }
                else if (radioButton5.Checked == true)
                {
                    radioButton5_CheckedChanged_1(sender, e);
                }
            }
        }

        private void radioButton6_CheckedChanged_1(object sender, EventArgs e)
        {

            {
                if ((radioButton6.Checked == true) && (pictureBox1.Image != null))
                    if (radioButton8.Checked == true)
                    {
                        radioButton8_CheckedChanged_1(sender, e);
                    }
                    else if (radioButton4.Checked == true)
                    {
                        radioButton4_CheckedChanged_1(sender, e);
                    }
                    else if (radioButton5.Checked == true)
                    {
                        radioButton5_CheckedChanged_1(sender, e);
                    }
            }
        }
    }
}
