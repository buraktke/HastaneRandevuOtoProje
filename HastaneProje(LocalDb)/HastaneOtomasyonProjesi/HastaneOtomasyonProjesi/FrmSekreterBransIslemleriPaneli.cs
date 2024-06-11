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
    public partial class FrmSekreterBransIslemleriPaneli : Form
    {
        public FrmSekreterBransIslemleriPaneli()
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

        public void BransTablosu()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from table_branslar", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void FrmSekreterBransIslemleriPaneli_Load(object sender, EventArgs e)
        {
            BransTablosu();

            buttonGuncelle.Enabled = false;
            buttonSil.Enabled = false;
        }

        private void buttonTemizle_Click(object sender, EventArgs e)
        {
            buttonKaydet.Enabled = true;
            buttonGuncelle.Enabled = false;
            buttonSil.Enabled = false;

            textBoxId.Text = "";
            textBoxAd.Text = "";
            textBoxAd.Focus();
        }

        private void buttonKaydet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxAd.Text))
            {
                MessageBox.Show("Branş Kaydetmek için 'Branş Ad' bölümünü doldurunuz", "Hata!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                SqlCommand cmd = new SqlCommand("insert into table_branslar(bransad) values(@ad)", bgl.baglanti());
                cmd.Parameters.AddWithValue("@ad", textBoxAd.Text);
                cmd.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Branş Eklendi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BransTablosu();
            }         
        }

        private void buttonGuncelle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxAd.Text))
            {
                MessageBox.Show("Branşı Güncellemek için 'Branş Ad' bölümü ve 'Id' bölümü dolu olması gerekemektedir.", "Hata!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                SqlCommand cmd = new SqlCommand("update table_branslar set bransad = @ad where BransId = @id", bgl.baglanti());
                cmd.Parameters.AddWithValue("@ad", textBoxAd.Text);
                cmd.Parameters.AddWithValue("@id", textBoxId.Text);
                cmd.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Branş Güncellendi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BransTablosu();
            }     
        }

        private void buttonSil_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxId.Text))
            {
                MessageBox.Show("Branşı Silmek için 'Id' bölümünde branşın ID'sinin bulunması ve 'Branş Ad' bölümünde o Id'ye sahip branşın yazılması gerekmektedir.", "Hata!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                SqlCommand cmd = new SqlCommand("delete from table_branslar where BransId = @id", bgl.baglanti());
                cmd.Parameters.AddWithValue("@id", textBoxId.Text);
                cmd.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Branş Silindi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BransTablosu();
            }          
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            buttonKaydet.Enabled = false;
            buttonGuncelle.Enabled = true;
            buttonSil.Enabled = true;

            DataGridViewRow SecilenSatir = dataGridView1.CurrentRow;
            textBoxId.Text = SecilenSatir.Cells[0].Value.ToString();
            textBoxAd.Text = SecilenSatir.Cells[1].Value.ToString();
        }
    }
}
