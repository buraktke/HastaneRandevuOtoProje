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
    public partial class FrmDoktorGirisPaneli : Form
    {
        public FrmDoktorGirisPaneli()
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
            this.Hide();
            FrmGirisPaneli frm = new FrmGirisPaneli();
            frm.ShowDialog();
        }

        private void buttonGiris_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from table_doktorlar where doktortc = @p1 and doktorsifre = @p2",bgl.baglanti());
            cmd.Parameters.AddWithValue("@p1", textBoxTcKimlik.Text);
            cmd.Parameters.AddWithValue("@p2", textBoxSifre.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                FrmDoktorDetayPaneli frm = new FrmDoktorDetayPaneli();
                frm.TCKimlikNo = textBoxTcKimlik.Text;
                this.Close();          
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("TC Kimlik No ve/veya Şifre Yanlış","Hata!!",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            dr.Close();
        }

        private void checkBoxSifreGoster_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSifreGoster.Checked)
            {
                textBoxSifre.UseSystemPasswordChar = false;
            }
            else 
            {
                textBoxSifre.UseSystemPasswordChar = true;
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
