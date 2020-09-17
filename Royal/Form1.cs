using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Royal
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void principalPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var wreq = giveMeUrl("https://github.com/JPaulBR/RoyalGameOfUr/blob/master/Royal/Resources/dado3.png?raw=true");
            using (var response = wreq.GetResponse())
            using (var stream = response.GetResponseStream())
            this.chip4.BackgroundImage = Bitmap.FromStream(stream);
        }

        private static System.Net.HttpWebRequest giveMeUrl(string url) {
            System.Net.HttpWebRequest wreq;
            wreq = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(url);
            wreq.AllowWriteStreamBuffering = true;
            return wreq;
        }

        public void throwChips(string user) {
            changeImgButton(this.throwButton, "https://raw.githubusercontent.com/JPaulBR/RoyalGameOfUr/master/Royal/Resources/swap.png");
            int i = 0;
            Random random = new Random();
            string url = "https://raw.githubusercontent.com/JPaulBR/RoyalGameOfUr/master/Royal/Resources/dado";
            while (i < 2) {
                changeImgButton(this.chip1, url+random.Next(1, 6)+".png");
                changeImgButton(this.chip2, url + random.Next(1, 6) + ".png");
                changeImgButton(this.chip3, url + random.Next(1, 6) + ".png");
                changeImgButton(this.chip4, url + random.Next(1, 6) + ".png");
                i++;
                System.Threading.Thread.Sleep(0100);
            }
            var c = Color.Chocolate;
            if (user == "human") { 
                c= Color.Chartreuse;
            }
            this.throwButton.BackColor = c;
            changeImgButton(this.throwButton, "https://raw.githubusercontent.com/JPaulBR/RoyalGameOfUr/master/Royal/Resources/"+user+".png");
        }

        public void changeImgButton(Button btn,string url) {
            var wreq = giveMeUrl(url);
            using (var response = wreq.GetResponse())
            using (var stream = response.GetResponseStream())
            {
                btn.BackgroundImage = Bitmap.FromStream(stream);
            }
        }

        private void throwButton_Click(object sender, EventArgs e)
        {
            if (this.throwButton.Enabled) {
                this.throwButton.Enabled = false;
                throwChips("robot32");
                // put turn for the pc
            }
            else {
                this.throwButton.Enabled = true;
                throwChips("human");
                //put turn for the human

            }
        }
    }
}
