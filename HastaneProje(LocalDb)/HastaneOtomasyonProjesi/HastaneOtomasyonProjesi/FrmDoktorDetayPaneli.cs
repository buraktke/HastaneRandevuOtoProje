using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HastaneOtomasyonProjesi
{
    public partial class FrmDoktorDetayPaneli : Form
    {
        public FrmDoktorDetayPaneli()
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
            FrmDoktorGirisPaneli frm = new FrmDoktorGirisPaneli();
            frm.Show();        
        }

        public string TCKimlikNo;

        private void FrmDoktorDetayPaneli_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select doktorad , doktorsoyad , doktortc from table_doktorlar where doktortc = @tc", bgl.baglanti());
            cmd.Parameters.AddWithValue("@tc", TCKimlikNo);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                labelDoktorAdSoyad.Text = dr[0] + " " + dr[1];
                labelTcKimlikNo.Text = dr[2].ToString();
            }
            dr.Close();

            if (string.IsNullOrWhiteSpace(textBoxId.Text))
            {
                buttonTeshisEkle.Enabled = false;
                buttonTahlilEkle.Enabled = false;
                buttonHastaDetay.Enabled = false;
            }
            else
            {
                buttonTeshisEkle.Enabled = true;
                buttonTahlilEkle.Enabled = true;
                buttonHastaDetay.Enabled = true;
            }
        }

        private void buttonBilgiDuzenle_Click(object sender, EventArgs e)
        {
            FrmDoktorBilgiDuzenlemePaneli frm = new FrmDoktorBilgiDuzenlemePaneli();
            frm.TCKimlikNo = labelTcKimlikNo.Text;
            frm.ShowDialog();
        }

        private void buttonDuyurular_Click(object sender, EventArgs e)
        {
            FrmSekreterDuyurularPaneli frm = new FrmSekreterDuyurularPaneli();
            frm.ShowDialog();
        }

        private void comboBoxRandevuTurleri_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxRandevuTurleri.Text == "Geçmiş Randevular")
            {
                GecmisRandevular();
            }
            if (comboBoxRandevuTurleri.Text == "Aktif Randevular")
            {
                AktifRandevular();
            }
        }

        public void GecmisRandevular()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select RandevuId as 'Randevu No' , randevutarih as 'Randevu Tarihi' , randevusaat as 'Randevu Saati' , HastaTC as 'Hasta TC' , hastasikayet as 'Şikayeti' from table_randevular where RandevuDoktor ='" + labelDoktorAdSoyad.Text +"' and randevutarih < '"+ DateTime.Now.ToString("d", DateTimeFormatInfo.InvariantInfo) + "' and HastaTC is not null", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;           
        }

        public void AktifRandevular()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select RandevuId as 'Randevu No' , randevutarih as 'Randevu Tarihi' , randevusaat as 'Randevu Saati' , HastaTC as 'Hasta TC' , hastasikayet as 'Şikayeti' from table_randevular where RandevuDoktor ='" + labelDoktorAdSoyad.Text +"' and randevutarih >= '"+ DateTime.Now.ToString("d", DateTimeFormatInfo.InvariantInfo) + "'", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            DataGridViewRow secilenSatir = dataGridView1.CurrentRow;
            textBoxId.Text = secilenSatir.Cells[0].Value.ToString();
            richTextBoxHastaSikayet.Text = secilenSatir.Cells[4].Value.ToString();

            if (comboBoxRandevuTurleri.Text == "Geçmiş Randevular")
            {
                buttonTahlilEkle.Enabled = false;
                buttonTeshisEkle.Enabled = false;
                buttonHastaDetay.Enabled = true;
            }
            if (comboBoxRandevuTurleri.Text == "Aktif Randevular")
            {
                buttonTahlilEkle.Enabled = true;
                buttonTeshisEkle.Enabled = true;
                buttonHastaDetay.Enabled = true;
            }
        }

        private void dateTimePickerBaslangic_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePickerBaslangic.Value > dateTimePickerBitis.Value)
            {
                dateTimePickerBitis.Value = dateTimePickerBaslangic.Value;
            }
        }

        private void dateTimePickerBitis_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePickerBitis.Value < dateTimePickerBaslangic.Value)
            {
                dateTimePickerBitis.Value = dateTimePickerBaslangic.Value;
            }
        }

        private void buttonTarihAralıgı_Click(object sender, EventArgs e)
        {
            string TarihBaslangic = dateTimePickerBaslangic.Value.ToString("d", DateTimeFormatInfo.InvariantInfo);
            string TarihBitis = dateTimePickerBitis.Value.ToString("d", DateTimeFormatInfo.InvariantInfo);
            if (comboBoxRandevuTurleri.Text == "Geçmiş Randevular")
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("select RandevuId as 'Randevu No' , randevutarih as 'Randevu Tarihi' , randevusaat as 'Randevu Saati' , HastaTC as 'Hasta TC' , hastasikayet as 'Şikayeti' from table_randevular where RandevuDoktor ='" + labelDoktorAdSoyad.Text + "' and randevutarih < '" + DateTime.Now.ToString("d",DateTimeFormatInfo.InvariantInfo) + "' and randevutarih between '" + TarihBaslangic + "' and '" + TarihBitis + "'", bgl.baglanti());
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            if (comboBoxRandevuTurleri.Text == "Aktif Randevular")
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("select RandevuId as 'Randevu No' , randevutarih as 'Randevu Tarihi' , randevusaat as 'Randevu Saati' , HastaTC as 'Hasta TC' , hastasikayet as 'Şikayeti' from table_randevular where RandevuDoktor ='" + labelDoktorAdSoyad.Text + "' and randevutarih >= '" + DateTime.Now.ToString("d", DateTimeFormatInfo.InvariantInfo) + "' and randevutarih between '" + TarihBaslangic + "' and '" + TarihBitis + "'", bgl.baglanti());
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        private void buttonTeshisEkle_Click(object sender, EventArgs e)
        {
            FrmDoktorTeshisEklemePaneli frm = new FrmDoktorTeshisEklemePaneli();
            frm.TeshisNo = textBoxId.Text;
            frm.ShowDialog();
        }

        private void buttonTahlilEkle_Click(object sender, EventArgs e)
        {
            FrmDoktorTahlilEklemePaneli frm = new FrmDoktorTahlilEklemePaneli();
            frm.RandevuNo = textBoxId.Text;
            frm.ShowDialog();
        }

        private void buttonHastaDetay_Click(object sender, EventArgs e)
        {
            FrmDoktorHastaRaporPaneli frm = new FrmDoktorHastaRaporPaneli();
            frm.randevuNo = textBoxId.Text;
            frm.ShowDialog();
        }
    }
}
