using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ImageProcessor.Processors;
using ImageProcessor.Imaging;
using ImageProcessor.Configuration;
using ImageProcessor.Common;

namespace MemeMaker
{
    public partial class Form1 : Form
    {
        OpenFileDialog openFile;

        string imageFile;

        public Form1()
        {
            InitializeComponent();
        }

        //파일 로드
        private void button1_Click(object sender, EventArgs e)
        {
            openFile  = new OpenFileDialog();
            openFile.InitialDirectory = "";
            openFile.Title = @"Open Image";
            openFile.Filter = @"Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png; *.bmp";
            openFile.FilterIndex = 2;
            openFile.RestoreDirectory = true;

            if(openFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pictureBox1.Image = Image.FromFile(openFile.FileName);
                    imageFile = openFile.FileName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR" + ex.Message);
                }
            }
        }

        //파일 저장
        private void button2_Click(object sender, EventArgs e)
        {
            string Ftext = textBox1.Text;
            string Stext = textBox2.Text;

            Bitmap bitmap = (Bitmap)Image.FromFile(imageFile);

            Rectangle Tr = new Rectangle(0, 10, bitmap.Width, 400);
            Rectangle Br = new Rectangle(0, bitmap.Height -100, bitmap.Width, 400);

            SaveFileDialog save = new SaveFileDialog();

            save.Filter = "Image |*.png; *.bmp; *.jpg; *.jpeg";
            save.ValidateNames = true;

            if (save.ShowDialog() == DialogResult.OK)
            {
                using(Graphics g = Graphics.FromImage(bitmap))
                {
                    using (Font f = new Font("font", 24, FontStyle.Bold, GraphicsUnit.Point))
                    {
                        g.DrawString(Ftext, f, Brushes.Black, Tr);
                        g.DrawString(Stext, f, Brushes.Black, Br);
                    }
                    bitmap.Save(save.FileName);
                }
            }

        }

        //위쪽 테스트입력
        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            label4.Text = textBox1.Text;
        }

        //아래쪽 텍스트 입력
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            label5.Text = textBox2.Text;
        }
    }
}
