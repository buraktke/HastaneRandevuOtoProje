using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HastaneOtomasyonProjesi
{
    public partial class FrmDoktorHastaRaporPaneli : Form
    {
        public FrmDoktorHastaRaporPaneli()
        {
            InitializeComponent();
        }

        #region SürüklemeKodları

        bool drag = false;
        Point Start_Point = new Point(0, 0);


        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                Point p = PointToScreen(e.Location);
                this.Location = new Point(p.X - Start_Point.X, p.Y - Start_Point.Y);
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            Start_Point = new Point(e.X, e.Y);
        }


        #endregion

        SqlBaglanti bgl = SqlBaglanti.SinifiGetir();

        public string randevuNo;

        private void button4_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmDoktorHastaRaporPaneli_Load(object sender, EventArgs e)
        {
            labelRandevuNo.Text = randevuNo;

            SqlCommand cmd3 = new SqlCommand("select RandevuDoktor from table_randevular where RandevuId = @p1", bgl.baglanti());
            cmd3.Parameters.AddWithValue("@p1", labelRandevuNo.Text);
            SqlDataReader dr3 = cmd3.ExecuteReader();
            while (dr3.Read())
            {
                labelDoktor.Text = dr3[0].ToString();
            }

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select '',r.HastaTC,r.RandevuBrans,r.RandevuDoktor, ta.TahlilHareketi,ta.TahlilSonucu,ta.Ilaclar , te.TeshisAdi,te.TeshisAciklamasi,te.TeshisTarihi from Table_Randevular r join Table_Tahliller ta on r.RandevuId = ta.RandevuNo join Table_Teshisler te on ta.RandevuNo = te.RandevuNo where r.RandevuId = @id";
            cmd.Connection = bgl.baglanti();
            cmd.Parameters.AddWithValue("@id", randevuNo);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read()) 
            {
                labelHastaTC.Text = dr[1].ToString();
                SqlCommand cmd2 = new SqlCommand("select hastaad,hastasoyad,cinsiyet from table_hastalar where hastatc = @tc", bgl.baglanti());
                cmd2.Parameters.AddWithValue("@tc", dr[1].ToString());
                SqlDataReader dr2 = cmd2.ExecuteReader();
                while (dr2.Read())
                {
                    labelHastaAdSoyad.Text = dr2[0] + " " + dr2[1];
                    labelCinsiyet.Text = dr2[2].ToString();
                }
                dr2.Close();
                labelPoliklinik.Text = dr[2].ToString();
                labelDoktor.Text = dr[3].ToString();
                labelYapilanTahliller.Text = dr[4].ToString();
                richTextBoxTahlilSonuclari.Text = dr[5].ToString();
                labelVerilenIlaclar.Text = dr[6].ToString();
                labelKonulanTeshis.Text = dr[7].ToString();
                richTextBoxDoktorAciklamasi.Text = dr[8].ToString();
                labelTeshisTarihi.Text = dr[9].ToString();
            }
            dr.Close();
            bgl.baglanti().Close();
        }
    }
}
