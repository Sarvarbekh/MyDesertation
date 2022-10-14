using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Modellashtirish_2topshiriq
{
    public partial class Form1 : Form
    {
        #region private fields
        const int ntor = 100;
        double[,] natija = new double[ntor + 1, ntor + 1]; // hisoblangan  qiymatlarni chop etish uchun massiv
        double[,] aiy = new double[ntor + 1, ntor + 1];    // a(yi) tor funksiya koeffitsienti
        double[,] u = new double[ntor + 1, ntor + 1];      // qidirilayotgan u  funksiya
        double[,] ai = new double[ntor + 1, ntor + 1];     // progonka koeffitsienti Ai
        double[,] bi = new double[ntor + 1, ntor + 1];     // progonka koeffitsienti Bi
        double[,] ci = new double[ntor + 1, ntor + 1];     // progonka koeffitsienti Ci
        double[,] fi = new double[ntor + 1, ntor + 1];     // progo101ka koeffitsienti Fi
        double[,] palfa = new double[ntor + 1, ntor + 1];  // progonka alfasi
        double[,] pbeta = new double[ntor + 1, ntor + 1];  // progonka alfasi
        int n;
        double k, p, l, m, a, kt, q;
        double alfa, beta, b, kl, hash, tau, gamma1, gamma2, agamma1, agamma2;

        private void chart1_Click(object sender, EventArgs e)
        {
            double f = 60;
            double f1 = 50;
            double f3 = 30;
            double[] y = new double[600];

           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        /// <summary>
        /// About tools strip menu item event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"Ushbu dastur magistrlik dissertatsiyasini yozish jarayonida yaratilgan : Dasturni ilmiy rahbarim Kabiljanova Feruza raxbarligida magistratura talabasi Xolto'rayev Sarvar yaratdi",
                              "Dastur haqida");
        }

        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Avtomatik hisoblash
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click_1(object sender, EventArgs e)
        {
            ntb.Text = "10";
            mtb.Text = "1,1";
            ktb.Text = "2,35";
            ptb.Text = "1,25";
            atb.Text = "1,15";
            ttb.Text = "1";
            btb.Text = "2";
        }
        /// <summary>
        /// Tozalash
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            mtb.Text =
               atb.Text =
               btb.Text =
               ttb.Text =
               ntb.Text =
               ktb.Text =
               ptb.Text =
               ntb.Text = "";
            
        }
        /// <summary>
        /// Hisoblash
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            // Return True : False
            if (converotInputToNumber())
            {
                natija=rb1.Checked
                ? progonka(n, k, p, q, l, m, a, kt)
                :progonka_e(n, k, p, q, l, m, a, kt);

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++) {
                        //richTextBox1.Text += "u[" + i + "," + j + "]=" + natija[i, j] + "\r\n";
                    }
                }
                for (int i = 0; i < n; i++)
                {
                    chart1.Series[i].Points.Clear();
                    for (int j = 0; j < n; j++)
                    {
                        chart1.Series[i].Points.AddXY(j * hash, natija[i, j]);
                    }
                }

            }
            else
            {
                MessageBox.Show("Input qiymatlarni o'grshda xatolik kelib chiqdi", "Xatolik!");
            }
        }
        /// <summary>
        /// Input text qiymatlarni int va double qiymatlarga o'gramiz
        /// </summary>
        /// <returns>Agar natija True Yoki False qiymat qaytaradi</returns>
        private bool converotInputToNumber()
        {
            return int.TryParse(this.ntb.Text, out n)
                   && double.TryParse(this.mtb.Text, out m)
                   && double.TryParse(this.ktb.Text, out k)
                   && double.TryParse(this.ptb.Text, out p)
                   && double.TryParse(this.atb.Text, out a)
                   && double.TryParse(this.ttb.Text, out kt)
                   && double.TryParse(this.btb.Text, out q);
                ;
        }
        /// <summary>
        /// Chegaraviy qiymatlarni hisblash
        /// </summary>
        /// <param name="n"></param>
        /// <param name="k"></param>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <param name="l"></param>
        /// <param name="m"></param>
        /// <param name="a"></param>
        /// <param name="kt"></param>
        /// <returns></returns>
        public double[,] chegara(int n, double k, double p, double q, double l, double m, double a, double kt)
        {
            alfa = (p - 1) / (q * p - (1 - k) * (p - 2) - m - l);
            beta = (q - k * (p - 2) - m - l + 1) / (q * p - (1 - k) * (p - 2) - m - l);
            gamma1 = p / (p - 1);
            gamma2 = (p - 1) / ((p - 2) * k + m + l - 2);
            agamma1 = (p - 1) / p;
            agamma2 = ((p - 2) * k + m + l - 2) / (p - 1);
            b = Math.Pow(beta / (Math.Pow(k, p - 2.0) * l), 1 / (p - 1)) * agamma1 * agamma2;
            kl = Math.Pow(a / b, agamma1) * Math.Pow(kt + kt, beta);
            hash = kl / n;
            tau = kt / n;
            for (int j = 0; j < n; j++) // boshlang'ich qiymatlarni hisoblash
            {
                if (a - b * Math.Pow(j * hash * Math.Pow(kt, -beta), gamma1) <= 0)
                    u[0, j] = 0;
                else
                    u[0, j] = Math.Pow(kt, -alfa) * Math.Pow(Math.Pow(a - b *
                    Math.Pow(j * hash * Math.Pow(kt, -beta), gamma1), gamma2), q);
            }
            for (int i = 0; i < n; i++) // chegaraviy qiymatlarni hisoblash
            {
                if (a - b * Math.Pow(kl * Math.Pow(kt + i * tau, -beta), gamma1) <= 0)
                    u[i, n - 1] = 0;
                else
                    u[i, n - 1] = Math.Pow(kt + i * tau, -alfa) * Math.Pow(a - b *
                    Math.Pow(kl * Math.Pow(kt + i * tau, -beta), gamma1), gamma2);
            }
            lb1.Text = "alfa=" + alfa;
            lb2.Text = "beta=" + beta;
            lb3.Text = "gamma1=" + gamma1;
            lb4.Text = "gamma2=" + gamma2;
            lb5.Text = "hash=" + hash;
            lb6.Text = "tau=" + tau;
            lb7.Text = "b=" + b;
            lb8.Text = "L=" + kl;
            lb9.Text = "q=" + q;
            return u;
        }
        public double[,] progonka(int n, double k, double p, double q, double l,double m, double a, double kt)
        {
            u = chegara(n, k, p, q, l, m, a, kt);
            for (int i = 1; i < n; i++) // progonkani qo'llash uchun sikl
            {
                for (int j = 0; j < n; j++) // a(yi) - koeffitsientni hisoblash
                {
                    if (j - 1 < 0)
                        aiy[i, j] = Math.Pow((u[i - 1, j + 1] + u[i - 1, j]) / 2, m - 1) * l *
                        Math.Pow(u[i - 1, j], p - 1) * Math.Pow(k, p - 2) * Math.Pow(u[i - 1, j], (k - 1) * (p -
                        2)) * Math.Pow(Math.Abs((u[i, j + 1] - u[i, j]) / hash), p - 2);
                    else
                        aiy[i, j] = Math.Pow((u[i - 1, j] + u[i - 1, j - 1]) / 2, m - 1) * l *
                        Math.Pow(u[i - 1, j], p - 1) * Math.Pow(k, p - 2) * Math.Pow(u[i - 1, j], (k - 1) * (p -
                        2)) * Math.Pow(Math.Abs((u[i - 1, j] - u[i - 1, j - 1]) / hash), p - 2);
                }
                for (int j = 0; j < n; j++) // progonka koeffitsientlari Ai, Bi, Ci,Fi larni hisoblash
            {
                    if (j + 1 >= n)
                    {
                        ai[i, j] = 0;
                    }
                    else
                    {
                        ai[i, j] = tau * aiy[i, j] / (hash * hash);
                    }
                    if (j + 1 >= n)
                    {
                    bi[i, j] = 0;
                    }
                    else
                    {
                        bi[i, j] = tau * aiy[i, j + 1] / (hash * hash);
                    }
                    if (j + 1 >= n)
                    {
                        ci[i, j] = 0;
                    }
                    else
                    {
                        ci[i, j] = ai[i, j] + bi[i, j] + 1;
                    }
                    if (j + 1 >= n)
                    {
                        fi[i, j] = 0;
                    }
                    else
                    {
                        fi[i, j] = u[i - 1, j];
                    }
                }
                palfa[i, 0] = 0; // progonka alfa sini hisoblash
                for (int j = 0; j < n - 1; j++)
                {
                    if (i < n - 1)
                        palfa[i, j + 1] = bi[i, j] / (ci[i, j] - palfa[i, j] * ai[i, j]);
                }
                pbeta[i, 0] = u[0, 0];
                for (int j = 0; j < n - 1; j++) // progonka beta sini hisoblash
                {
                    if (i < n - 1)
                        pbeta[i, j + 1] = (ai[i, j] * pbeta[i, j] + fi[i, j]) / (ci[i, j] - palfa[i, j] *
                        ai[i, j]);
                }
                for (int j = n - 2; j >= 0; j--) // progonka
                {
                    if (i < n - 1)
                u[i, j] = palfa[i, j + 1] * u[i, j + 1] + pbeta[i, j + 1];
                }
            }
            return u;
        }
        public double[,] progonka_e(int n, double k, double p, double q, double l, double m, double a, double kt)
        {
            alfa = (q * p - (1 - k) * (p - 2) - m - l);
            alfa = (p - 1) / alfa;
            beta = (q - k * (p - 2) - m - l + 1) / alfa;
            b = Math.Pow(beta / (Math.Pow(k, p - 2.0) * l), 1 / (p - 1)) * (k * (p - 2) + m + l - 2) / p;
            kl = Math.Pow(a / b, (p - 1) / p) * Math.Pow(kt + kt, beta);
            hash = kl / n;
            tau = kt / n;
            gamma1 = p / (p - 1);
            gamma2 = (p - 1) / ((p - 2) * k + m + l - 2);
            for (int j = 0; j < n; j++) // boshlang'ich qiymatlarni hisoblash
            {
                if (a - b * Math.Pow(j * hash * Math.Pow(kt, -beta), gamma1) <= 0)
                    u[0, j] = 0;
                else
                    u[0, j] = Math.Pow(kt, -alfa) * Math.Pow(Math.Pow(a - b *
                    Math.Pow(j * hash * Math.Pow(kt, -beta), gamma1), gamma2), q);
            }
            for (int i = 0; i < n; i++) // chegaraviy qiymatlarni hisoblash
            {
                if (a - b * Math.Pow(kl * Math.Pow(kt + i * tau, -beta), gamma1) <= 0)
                    u[i, n - 1] = 0;
                else
                    u[i, n - 1] = Math.Pow(kt + i * tau, -alfa) * Math.Pow(a - b *
                    Math.Pow(kl * Math.Pow(kt + i * tau, -beta), gamma1), gamma2);
            }
            for (int i = 1; i < n; i++) // progonkani qo'llash uchun sikl
            {
                for (int j = 0; j < n; j++) // a(yi) - koeffitsientni hisoblash
                {
                if (j - 1 < 0)
                        aiy[i, j] = Math.Pow((u[i - 1, j + 1] + u[i - 1, j]) / 2, m - 1) * l *
                        Math.Pow(u[i - 1, j], p - 1) * Math.Pow(k, p - 2) * Math.Pow(u[i - 1, j], (k - 1) * (p -
                        2)) * Math.Pow(Math.Abs((u[i, j + 1] - u[i, j]) / hash), p - 2);
                    else
                        aiy[i, j] = Math.Pow((u[i - 1, j] + u[i - 1, j - 1]) / 2, m - 1) * l *
                        Math.Pow(u[i - 1, j], p - 1) * Math.Pow(k, p - 2) * Math.Pow(u[i - 1, j], (k - 1) * (p -
                        2)) * Math.Pow(Math.Abs((u[i - 1, j] - u[i - 1, j - 1]) / hash), p - 2);
                }
                for (int j = 0; j < n; j++) // progonka koeffitsientlari Ai, Bi, Ci, Fi larni hisoblash
            {
                    if (j + 1 >= n)
                    {
                        ai[i, j] = 0;
                    }
                    else
                    {
                        ai[i, j] = tau * aiy[i, j] / (hash * hash);
                    }
                    if (j + 1 >= n)
                    {
                        bi[i, j] = 0;
                    }
                    else
                    {
                        bi[i, j] = tau * aiy[i, j + 1] / (hash * hash);
                    }
                    if (j + 1 >= n)
                    {
                        ci[i, j] = 0;
                    }
                    else
                    {
                        ci[i, j] = ai[i, j] + bi[i, j] + 1;
                    }
                    if (j + 1 >= n)
                    {
                        fi[i, j] = 0;
                    }
                    else
                    {
                        fi[i, j] = u[i - 1, j];
                    }
                }
                palfa[i, 0] = 0; // progonka alfa sini hisoblash
                for (int j = 0; j < n - 1; j++)
                {
                    if (i < n - 1)
                        palfa[i, j + 1] = bi[i, j] / (ci[i, j] - palfa[i, j] * ai[i, j]);
                }
                pbeta[i, 0] = u[0, 0];
                for (int j = 0; j < n - 1; j++) // progonka beta sini hisoblash
                {
                    if (i < n - 1)
                        pbeta[i, j + 1] = (ai[i, j] * pbeta[i, j] + fi[i, j]) / (ci[i, j] - palfa[i, j] *
                        ai[i, j]);
                }
                for (int j = n - 2; j >= 0; j--) // progonka
                {
                    if (i < n - 1)
                        u[i, j] = palfa[i, j + 1] * u[i, j + 1] + pbeta[i, j + 1];
                }
            }
            lb1.Text = "alfa=" + alfa;
            lb2.Text = "beta=" + beta;
            lb3.Text = "gamma1=" + gamma1;
            lb4.Text = "gamma2=" + gamma2;
            lb5.Text = "hash=" + hash;
            lb6.Text = "tau=" + tau;
            lb7.Text = "b=" + b;
            lb8.Text = "L=" + kl;
            lb9.Text = "q=" + q;
            return u;
        }
    }
}
