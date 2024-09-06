using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace yilanOyunu
{
    public partial class yilanOyunu : Form
    {
        public yilanOyunu()
        {
            InitializeComponent();
        }
        Panel parca;
        Panel elma = new Panel();
        List<Panel> yilan = new List<Panel>();

        string yon = "sağ";
        private int sayac=30;
       private void tekrarOyna()
        {
            label2.Text = "0";
            paneliTemizle();

            parca = new Panel();
            parca.Location = new Point(200, 200);
            parca.Size = new Size(20, 20);
            parca.BackColor = Color.Gray;
            yilan.Add(parca);
            panel1.Controls.Add(yilan[0]);
            timer1.Interval = 170;
            timer1.Start();
            elmaOlustur();
            label3.Visible = false;
            label6.Visible = true;

        }
        private void label3_Click(object sender, EventArgs e)
        {
            
            tekrarOyna();
        }

        
        void carpismaKontol()
        {
            for (int i = 2; i < yilan.Count; i++)
            {
                if (yilan[0].Location == yilan[i].Location || sayac==0 )
                {
                    label4.Visible = true;
                    label4.Text = "KAYBETTİNİZ";
                    //label3.Visible=true;
                    timer1.Stop();
                    timer2.Stop();
                    label6.Visible = false;
                    label7.Visible = false;
                    SoundPlayer player = new SoundPlayer();
                    player.SoundLocation = @"C:\Users\Casper\source\repos\yilanOyunu\yilanOyunu\kybtmeSes.wav";
                    player.Play();
                    DialogResult mesaj = MessageBox.Show("Oyunu kaybettiniz!! \n Tekrar oynamak istiyor musunuz?", "ÜZGÜNÜM", MessageBoxButtons.YesNo,MessageBoxIcon.Information);
                    if (mesaj == DialogResult.Yes)
                    {
                        tekrarOyna();
                    }
                    else
                    {
                        Application.Exit();
                    }

                }
            }
        }

        private void label3_Click()
        {
            throw new NotImplementedException();
        }

        void paneliTemizle()
        {
            panel1.Controls.Clear();
            yilan.Clear();
            label4.Visible = false;

        }

        void puanKontrol()
        {
            int puan = int.Parse(label2.Text);
            if (puan == 180 )
            {
                timer1.Interval = 100;
            }
            if (puan == 300)
            {
                label5.Visible = true;
                timer2.Start();
                timer1.Interval =75;
            }
            if (puan == 450)
            {
                
                label4.Text = "KAZANDINIZ";
               
                label3.Visible = true;
                label4.Visible = true;
                label6.Visible = false;
                label7.Visible = false;
                timer1.Stop();
                timer2.Stop();
                SoundPlayer player = new SoundPlayer();
                player.SoundLocation = @"C:\Users\Casper\source\repos\yilanOyunu\yilanOyunu\ses.wav";
                player.Play();
                DialogResult mesaj = MessageBox.Show("Oyunu kazandınız!! \n Tekrar oynamak istiyor musunuz?", "TEBRİKLER", MessageBoxButtons.YesNo,MessageBoxIcon.Information);
            
                if (mesaj == DialogResult.Yes)
                {
                    tekrarOyna();
                }
                else
                {
                    Application.Exit();
                }


            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int locX = yilan[0].Location.X;
            int locY = yilan[0].Location.Y;

            elmaYedimmi();
            hareket();
            carpismaKontol();
            puanKontrol();

            if (yon == "sağ")
            {
                if (locX < 580)
                    locX += 20;
                else
                    locX = 0;
            }
            if (yon == "sol")
            {
                if (locX > 0)
                    locX -= 20;
                else
                    locX = 580;
            }
            if (yon == "aşağı")
            {
                if (locY < 580)
                    locY += 20;
                else
                    locY = 0;
            }
            if (yon == "yukarı")
            {
                if (locY > 0)
                    locY -= 20;
                else
                    locY = 580;
            }

            yilan[0].Location = new Point(locX, locY);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space)
            {

                timer1.Stop();
                timer2.Stop();
                label6.Visible = false;
                label7.Visible = true;
              
            }
            if(e.KeyCode == Keys.Enter)
            {
                timer1.Start();
                timer2.Start();
                label6.Visible = true;
                label7.Visible = false;
            }
           
              
            if (e.KeyCode == Keys.Right && yon != "sol")
                yon = "sağ";
            if (e.KeyCode == Keys.Left && yon != "sağ")
                yon = "sol";
            if (e.KeyCode == Keys.Up && yon != "aşağı")
                yon = "yukarı";
            if (e.KeyCode == Keys.Down && yon != "yukarı")
                yon = "aşağı";
        }
        void elmaOlustur()
        {
            Random rnd = new Random();
            int elmaX, elmaY;
            elmaX = rnd.Next(580);
            elmaY = rnd.Next(580);

            elmaX -= elmaX % 20;
            elmaY -= elmaY % 20;

            elma.Size = new Size(20, 20);
            elma.BackColor = Color.Red;
            elma.Location = new Point(elmaX, elmaY);
            panel1.Controls.Add(elma);
        }
        void elmaYedimmi()
        {
            int puan = int.Parse(label2.Text);
            if (yilan[0].Location == elma.Location)
            {
                panel1.Controls.Remove(elma);
                puan += 30;
                label2.Text = puan.ToString();
                elmaOlustur();
                parcaEkle();
            }
        }
        void parcaEkle()
        {
            Panel ekParca = new Panel();
            ekParca.Size = new Size(20, 20);
            ekParca.BackColor = Color.Gray;
            yilan.Add(ekParca);
            panel1.Controls.Add(ekParca);
        }


        void hareket()
        {
            for (int i = yilan.Count - 1; i > 0; i--)
                yilan[i].Location = yilan[i - 1].Location;
        }

        private void label6_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            timer2.Stop();
            label6.Visible = false;
            label7.Visible = true;
        }

        private void label7_Click(object sender, EventArgs e)
        {
            timer1.Start();
            timer2.Start();
            label6.Visible = true;
            label7.Visible = false;
        }



        private void Form1_Load(object sender, EventArgs e)
        {
          
            label5.Visible = false;
            label5.Text = Convert.ToString(sayac);
            timer2.Interval= 1000;
           
           // timer2.Start();

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            sayac = sayac - 1;
            label5.Text = Convert.ToString(sayac);
            if (sayac == 0)
            {
                timer2.Stop();
            }
        }

       
    }
}
