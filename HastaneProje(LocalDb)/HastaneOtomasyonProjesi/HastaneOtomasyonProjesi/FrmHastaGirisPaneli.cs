using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HastaneOtomasyonProjesi
{
    public partial class FrmHastaGirisPaneli : Form
    {
        public FrmHastaGirisPaneli()
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmGirisPaneli frm = new FrmGirisPaneli();
            frm.ShowDialog();
        }
       
        private void buttonGiris_Click(object sender, EventArgs e)
        { 
            SqlCommand command = new SqlCommand("select * from table_hastalar where hastatc = @p1 and hastasifre = @p2 ",bgl.baglanti());
            command.Parameters.AddWithValue("@p1", textBoxTcKimlik.Text);
            command.Parameters.AddWithValue("@p2", textBoxSifre.Text);
            SqlDataReader dr = command.ExecuteReader();
            
            if(dr.Read() == true)
            {
                FrmHastaDetayPaneli frm = new FrmHastaDetayPaneli();
                frm.TcKimlikNo = textBoxTcKimlik.Text;
                frm.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("TC Kimlik No Veya/Ve Şifre Yanlış","Hata!!",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            dr.Close();
            bgl.baglanti().Close();
        }

        private void linkLabelKayitOl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmHastaKayitOlPaneli frm = new FrmHastaKayitOlPaneli();
            frm.ShowDialog();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSifreGoster.Checked == true)
            {
                textBoxSifre.UseSystemPasswordChar = false;
            }
            else
            {
                textBoxSifre.UseSystemPasswordChar= true;
            }
        }

        private void textBoxTcKimlik_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar >= 48 && e.KeyChar <= 57 || e.KeyChar == 8))
            {
                e.Handled = true;
            }
        }
    }
}
