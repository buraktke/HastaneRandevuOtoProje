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
    public partial class FrmHastaKayitOlPaneli : Form
    {
        public FrmHastaKayitOlPaneli()
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxAd.Text) || string.IsNullOrWhiteSpace(textBoxSoyad.Text) || string.IsNullOrWhiteSpace(maskedTextBoxTcNo.Text) || string.IsNullOrWhiteSpace(textBoxSifre.Text))
            {
                MessageBox.Show("Ad,Soyad,TC Kimlik No ve Sifre bölümleri boş bırakılamaz","Hata!!",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                if (maskedTextBoxTcNo.Text.Length == 11)
                {
                    SqlCommand command = new SqlCommand("insert into table_hastalar(hastaad,hastasoyad,hastatc,cinsiyet,hastasifre,hastatelefon) values(@p1,@p2,@p3,@p4,@p5,@p6)", bgl.baglanti());
                    command.Parameters.AddWithValue("@p1", textBoxAd.Text);
                    command.Parameters.AddWithValue("@p2", textBoxSoyad.Text);
                    command.Parameters.AddWithValue("@p3", maskedTextBoxTcNo.Text);
                    command.Parameters.AddWithValue("@p4", comboBoxCinsiyet.Text);
                    command.Parameters.AddWithValue("@p5", textBoxSifre.Text);
                    command.Parameters.AddWithValue("@p6", maskedTextBoxTelefon.Text);
                    command.ExecuteNonQuery();
                    bgl.baglanti().Close();
                    MessageBox.Show("Kayıt Olundu", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if(maskedTextBoxTcNo.Text.Length < 11)
                {
                    MessageBox.Show("TC Kimlik Numarası 11 haneli olmak zorunda");
                }              
            }          
        }

        private void maskedTextBoxTcNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar >= 48 && e.KeyChar <= 57 || e.KeyChar == 8))
            {
                e.Handled = true;
            }
        }
    }
}
