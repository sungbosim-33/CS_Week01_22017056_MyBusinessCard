using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.Collections; // 1. 이게 있어야 리소스를 뒤질 수 있어요!

namespace MyBusinessCard
{
    public partial class Form1 : Form
    {
        List<Image> myImages = new List<Image>();
        int currentIndex = 0;

        public Form1()
        {
            InitializeComponent();
            // 2. 프로그램이 켜질 때 리소스에서 사진을 가져오라고 시킵니다.
            LoadImagesFromResources();
        }

        // 3. 리소스에서 이미지만 쏙쏙 골라 장바구니에 담는 함수입니다.
        private void LoadImagesFromResources()
        {
            var resourceSet = Properties.Resources.ResourceManager.GetResourceSet(System.Globalization.CultureInfo.CurrentCulture, true, true);
            foreach (DictionaryEntry entry in resourceSet)
            {
                if (entry.Value is Image img)
                {
                    myImages.Add(img);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            this.BackColor = Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string url = "https://github.com/sungbosim-33/CS_Week01_22017056_MyBusinessCard";
            ProcessStartInfo psi = new ProcessStartInfo { FileName = url, UseShellExecute = true };
            Process.Start(psi);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 사진이 하나도 안 담겼으면 오류 메시지를 띄워줍니다.
            if (myImages.Count == 0)
            {
                MessageBox.Show("리소스에 등록된 사진이 없어요!");
                return;
            }

            pictureBox1.Image = myImages[currentIndex];
            currentIndex = (currentIndex + 1) % myImages.Count;
        }

        private void label2_Click(object sender, EventArgs e) { }
        private void pictureBox1_Click(object sender, EventArgs e) { }
    }
}