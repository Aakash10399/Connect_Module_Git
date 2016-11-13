using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace Connect_Module
{
    public partial class Form1 : Form
    {
        public static string[] ans;
        public static int c=0;
        public static List<string> inputs;
        public static int score=0;
        public static int co = 0;
        public static string shash, uname;
        public static string click;
        public Form1(string unamet, string shasht, int scoret, string clickt)
        {
            shash = shasht; uname = unamet; score = 0; click = clickt;
            
            InitializeComponent();
            AutoScroll = true;
            this.WindowState = FormWindowState.Maximized;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            System.IO.StreamReader file = new System.IO.StreamReader("C:\\Users\\Public\\Main_App\\Connect_Module\\answers.txt");
            string line;
            while ((line = file.ReadLine()) != null)
            {
                c++;
            }
            file.Close();
            ans = new string[c];
            inputs = new List<string>(c);
            c = 0;
            System.IO.StreamReader file1 = new System.IO.StreamReader("C:\\Users\\Public\\Main_App\\Connect_Module\\answers.txt");          
            while ((line = file1.ReadLine()) != null)
            {
                ans[c] = line;
                c++;
            }
            file1.Close();
            Game_Construct();
        }
        public void Game_Construct()
        {
            if(co<c)
            { 
            pictureBox1.ImageLocation = @"C:\\Users\\Public\\Main_App\\Connect_Module\\qa" + co.ToString();
            pictureBox2.ImageLocation = @"C:\\Users\\Public\\Main_App\\Connect_Module\\qb" + co.ToString();
            pictureBox3.ImageLocation = @"C:\\Users\\Public\\Main_App\\Connect_Module\\qc" + co.ToString();
            pictureBox4.ImageLocation = @"C:\\Users\\Public\\Main_App\\Connect_Module\\qd" + co.ToString();
            }
            else
            {
                string[] temp = inputs.ToArray();
                for(int i=0;i<ans.Length;i++)
                {
                    
                    if(ans[i].Equals(inputs[i]))
                    { score++; }
                }
                End_Screen();
            }
        }
        public void End_Screen()
        {
            pictureBox1.Hide(); pictureBox2.Hide(); pictureBox3.Hide(); pictureBox4.Hide(); label1.Hide(); textBox1.Hide(); button1.Hide();
            label2.Text = "FINAL SCORE : " + score.ToString();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            co++;
            inputs.Add(textBox1.Text);
            Game_Construct();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                WebClient client = new WebClient();


                string url = "http://www.cofas10399.16mb.com/update_score.php?uname=" + uname + "&hash=" + shash + "&score=" + score.ToString() + "&gtype=" + click;
                string response = client.DownloadString(url);
                response = response.Trim();

                if (response.Substring(0, 1).Equals("0"))
                {
                    Console.WriteLine("ERROR_SERVERSIDE");
                }
                if (response.Substring(0, 1).Equals("1"))
                {
                    Console.WriteLine("SUCCESS");
                }


            }
            catch
            {
                Console.WriteLine("ERROR_INTERNET");
            }
        }
    }
}
