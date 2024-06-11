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
    public partial class FrmDoktorTeshisEklemePaneli : Form
    {
        public FrmDoktorTeshisEklemePaneli()
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

        public string TeshisNo;

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void FrmDoktorTeshisEklemePaneli_Load(object sender, EventArgs e)
        {
            buttonGuncelle.Enabled = false;

            SqlCommand cmd1 = new SqlCommand("select * from table_randevular where randevuId = @id and hastatc is not null", bgl.baglanti());
            cmd1.Parameters.AddWithValue("@id", TeshisNo);
            SqlDataReader dr1 = cmd1.ExecuteReader();
            if (dr1.Read())
            {
                labelRandevuNo.Text = TeshisNo;
            }
            else
            {
                MessageBox.Show("Bu randevu alınmadığı için teşhis paneli gözükmemektedir.\nHasta tarafından alındığı zaman gözükecektir.", "Hata!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            dr1.Close();


            SqlCommand cmd3 = new SqlCommand("select randevubrans from table_randevular where randevuId = @rNo", bgl.baglanti());
            cmd3.Parameters.AddWithValue("@rNo", labelRandevuNo.Text);
            SqlDataReader dr3 = cmd3.ExecuteReader();
            while (dr3.Read())
            {
                textBoxPoliklinik.Text = dr3[0].ToString();
            }
            dr3.Close();
            bgl.baglanti().Close();

            
            SqlCommand cmd2 = new SqlCommand("select * from table_teshisler where randevuno = @p1", bgl.baglanti());
            cmd2.Parameters.AddWithValue("@p1", labelRandevuNo.Text);
            SqlDataReader dr2 = cmd2.ExecuteReader();
            while (dr2.Read())
            {
                textBoxTeshisAdi.Text = dr2[1].ToString();
                richTextBoxAciklama.Text = dr2[2].ToString();
                dateTimePickerTarih.Text = dr2[3].ToString();
                textBoxPoliklinik.Text = dr2[4].ToString();
            }
            dr2.Close();
            bgl.baglanti().Close();


            if (!string.IsNullOrWhiteSpace(textBoxTeshisAdi.Text) || !string.IsNullOrWhiteSpace(richTextBoxAciklama.Text))
            {
                buttonKaydet.Enabled = false;
                buttonGuncelle.Enabled = true;
            }       
        }


        private void buttonKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("insert into table_teshisler(teshisadi,teshisaciklamasi,teshistarihi,poliklinik,randevuno) values(@p1,@p2,@p3,@p4,@p5)", bgl.baglanti());
            cmd.Parameters.AddWithValue("@p1", textBoxTeshisAdi.Text);
            cmd.Parameters.AddWithValue("@p2", richTextBoxAciklama.Text);
            cmd.Parameters.AddWithValue("@p3", dateTimePickerTarih.Text);
            cmd.Parameters.AddWithValue("@p4", textBoxPoliklinik.Text);
            cmd.Parameters.AddWithValue("@p5", labelRandevuNo.Text);
            cmd.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Teshis Eklendi","Bilgilendirme",MessageBoxButtons.OK,MessageBoxIcon.Information);
            buttonKaydet.Enabled = false;
            buttonGuncelle.Enabled = true;
        }

        private void buttonGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("update table_teshisler set teshisadi = @p1 , teshisaciklamasi = @p2 , teshistarihi = @p3 where randevuno = @p5", bgl.baglanti());
            cmd.Parameters.AddWithValue("@p1", textBoxTeshisAdi.Text);
            cmd.Parameters.AddWithValue("@p2", richTextBoxAciklama.Text);
            cmd.Parameters.AddWithValue("@p3", dateTimePickerTarih.Text);
            cmd.Parameters.AddWithValue("@p5", labelRandevuNo.Text);
            cmd.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Teshis Güncellendi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dateTimePickerTarih_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePickerTarih.Value < DateTime.Now)
            {
                dateTimePickerTarih.Value = DateTime.Now;
            }
        }
    }
}
