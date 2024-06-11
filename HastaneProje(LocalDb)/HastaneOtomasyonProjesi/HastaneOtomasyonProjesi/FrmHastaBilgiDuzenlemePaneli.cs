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
    public partial class FrmHastaBilgiDuzenlemePaneli : Form
    {
        public FrmHastaBilgiDuzenlemePaneli()
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        SqlBaglanti bgl = SqlBaglanti.SinifiGetir();
        public string tcNo;

        private void FrmHastaBilgiDuzenlemePaneli_Load(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("select * from table_hastalar where HastaTc = @tc",bgl.baglanti());
            command.Parameters.AddWithValue("@tc", tcNo);
            SqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                textBoxAd.Text = dr[1].ToString();
                textBoxSoyad.Text = dr[2].ToString();
                maskedTextBoxTC.Text = dr[3].ToString();
                comboBoxCinsiyet.Text = dr[4].ToString();
                textBoxSifre.Text = dr[5].ToString();
                maskedTextBoxTelefon.Text = dr[6].ToString();
            }
            dr.Close();
        }

        private void buttonGuncelleme_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("update table_hastalar set hastaad = @ad , hastasoyad = @soyad , cinsiyet = @cinsiyet , hastasifre = @sifre , hastatelefon = @telefon where hastatc = @tc ", bgl.baglanti());
            command.Parameters.AddWithValue("@ad", textBoxAd.Text);
            command.Parameters.AddWithValue("@soyad", textBoxSoyad.Text);
            command.Parameters.AddWithValue("@cinsiyet", comboBoxCinsiyet.Text);
            command.Parameters.AddWithValue("@sifre", textBoxSifre.Text);
            command.Parameters.AddWithValue("@telefon", maskedTextBoxTelefon.Text);
            command.Parameters.AddWithValue("@tc", maskedTextBoxTC.Text);
            command.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Bilgileriniz Güncellendi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void maskedTextBoxTC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar >= 48 && e.KeyChar <= 57 || e.KeyChar == 8))
            {
                e.Handled = true;
            }
        }
    }
}
