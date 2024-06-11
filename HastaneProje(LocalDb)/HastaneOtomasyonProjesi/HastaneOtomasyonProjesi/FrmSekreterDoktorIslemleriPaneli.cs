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
    public partial class FrmSekreterDoktorIslemleriPaneli : Form
    {
        public FrmSekreterDoktorIslemleriPaneli()
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
            this.Close();
        }

        public void DoktorTablosu()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from table_doktorlar", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void FrmSekreterDoktorIslemleriPaneli_Load(object sender, EventArgs e)
        {
            DoktorTablosu();

            SqlCommand cmd = new SqlCommand("select bransad from table_branslar",bgl.baglanti());
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBoxBrans.Items.Add(dr[0]);
            }
            dr.Close();
            bgl.baglanti().Close();

            buttonGuncelle.Enabled = false;
            buttonSil.Enabled = false;
        }

        private void buttonKaydet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxAd.Text) || string.IsNullOrWhiteSpace(textBoxSoyad.Text) || string.IsNullOrWhiteSpace(textBoxSifre.Text) || string.IsNullOrWhiteSpace(comboBoxBrans.Text) || string.IsNullOrWhiteSpace(maskedTextBoxTC.Text))
            {
                MessageBox.Show("Kayıt için yeterli kutucuk dolu değil","Hata!!",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                SqlCommand cmd = new SqlCommand("insert into table_doktorlar(doktorad,doktorsoyad,doktorbrans,doktortc,doktorsifre) values(@p1,@p2,@p3,@p4,@p5)", bgl.baglanti());
                cmd.Parameters.AddWithValue("@p1", textBoxAd.Text);
                cmd.Parameters.AddWithValue("@p2", textBoxSoyad.Text);
                cmd.Parameters.AddWithValue("@p3", comboBoxBrans.Text);
                cmd.Parameters.AddWithValue("@p4", maskedTextBoxTC.Text);
                cmd.Parameters.AddWithValue("@p5", textBoxSifre.Text);
                cmd.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Kayıt Eklendi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DoktorTablosu();
            }       
        }

        private void buttonGuncelle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxAd.Text) || string.IsNullOrWhiteSpace(textBoxSoyad.Text) || string.IsNullOrWhiteSpace(textBoxSifre.Text) || string.IsNullOrWhiteSpace(comboBoxBrans.Text) || string.IsNullOrWhiteSpace(maskedTextBoxTC.Text))
            {
                MessageBox.Show("Kaydın Güncellenmesi için yeterli kutucuk dolu değil", "Hata!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                SqlCommand cmd = new SqlCommand("update table_doktorlar set doktorad = @ad , doktorsoyad = @soyad , doktorbrans = @brans , doktortc = @tc , doktorsifre = @sifre where DoktorId = @id ", bgl.baglanti());
                cmd.Parameters.AddWithValue("@ad", textBoxAd.Text);
                cmd.Parameters.AddWithValue("@soyad", textBoxSoyad.Text);
                cmd.Parameters.AddWithValue("@brans", comboBoxBrans.Text);
                cmd.Parameters.AddWithValue("@tc", maskedTextBoxTC.Text);
                cmd.Parameters.AddWithValue("@sifre", textBoxSifre.Text);
                cmd.Parameters.AddWithValue("@id", textBoxId.Text);
                cmd.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Kayıt Güncellendi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DoktorTablosu();
            }         
        }

        private void buttonSil_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxSifre.Text))
            {
                MessageBox.Show("Kaydın Silinmesi için 'Id' Bölümünde Doktorun ID'sinin bulunması gerekiyor", "Hata!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                SqlCommand cmd = new SqlCommand("delete from table_doktorlar where DoktorId = @id", bgl.baglanti());
                cmd.Parameters.AddWithValue("@id", textBoxId.Text);
                cmd.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Kayıt Silindi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DoktorTablosu();
            }         
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            buttonKaydet.Enabled = false;
            buttonGuncelle.Enabled = true;
            buttonSil.Enabled = true;

            DataGridViewRow secilenSatir = dataGridView1.CurrentRow;
            textBoxId.Text = secilenSatir.Cells[0].Value.ToString();
            textBoxAd.Text = secilenSatir.Cells[1].Value.ToString();
            textBoxSoyad.Text = secilenSatir.Cells[2].Value.ToString();
            maskedTextBoxTC.Text = secilenSatir.Cells[3].Value.ToString();
            comboBoxBrans.Text = secilenSatir.Cells[4].Value.ToString();
            textBoxSifre.Text = secilenSatir.Cells[5].Value.ToString();
        }

        private void buttonTemizle_Click(object sender, EventArgs e)
        {
            buttonKaydet.Enabled = true;
            buttonGuncelle.Enabled = false;
            buttonSil.Enabled = false;

            textBoxId.Text = "";
            textBoxAd.Text = "";
            textBoxSoyad.Text = "";
            maskedTextBoxTC.Text = "";
            comboBoxBrans.Text = null;
            textBoxSifre.Text = "";
            textBoxAd.Focus();
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
