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
    public partial class FrmDoktorBilgiDuzenlemePaneli : Form
    {
        public FrmDoktorBilgiDuzenlemePaneli()
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
        public string TCKimlikNo;

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonGuncelleme_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("update table_doktorlar set doktorad = @ad , doktorsoyad = @soyad , doktorbrans = @brans , doktorsifre = @sifre where doktortc = @tc", bgl.baglanti());
            cmd.Parameters.AddWithValue("@ad", textBoxAd.Text);
            cmd.Parameters.AddWithValue("@soyad", textBoxSoyad.Text);
            cmd.Parameters.AddWithValue("@brans", comboBoxBrans.Text);
            cmd.Parameters.AddWithValue("@sifre", textBoxSifre.Text);
            cmd.Parameters.AddWithValue("@tc", maskedTextBoxTC.Text);
            cmd.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Kayıt Güncellendi","bilgilendirme",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void FrmDoktorBilgiDuzenlemePaneli_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from table_doktorlar where doktortc = @tc",bgl.baglanti());
            cmd.Parameters.AddWithValue("@tc", TCKimlikNo);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                textBoxAd.Text = dr[1].ToString();
                textBoxSoyad.Text = dr[2].ToString();
                maskedTextBoxTC.Text = dr[3].ToString();
                comboBoxBrans.Text = dr[4].ToString();
                textBoxSifre.Text = dr[5].ToString();
            }
            dr.Close();

            SqlCommand cmd2 = new SqlCommand("select * from table_branslar", bgl.baglanti());
            SqlDataReader dr2 = cmd2.ExecuteReader();
            while (dr2.Read())
            {
                comboBoxBrans.Items.Add(dr2[1].ToString());
            }
            dr2.Close();
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
