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
    public partial class FrmHastaDetayPaneli : Form
    {

        

        public FrmHastaDetayPaneli()
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

        public string TcKimlikNo;

        private void FrmHastaDetayPaneli_Load(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("select * from table_hastalar where hastatc = @tc", bgl.baglanti());
            command.Parameters.AddWithValue("@tc", TcKimlikNo);

            SqlDataReader dr = command.ExecuteReader();

            while (dr.Read())
            {
                labelHastaAdSoyad.Text = dr[1] + " " + dr[2];
                labelTcKimlikNo.Text = dr[3].ToString();
            }
            dr.Close();
            bgl.baglanti().Close();


            SqlCommand command2 = new SqlCommand("select * from table_branslar",bgl.baglanti());
            SqlDataReader dr2 = command2.ExecuteReader();
            while (dr2.Read())
            {
                comboBoxBranslar.Items.Add(dr2[1]);
            }
            dr2.Close();
            bgl.baglanti().Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmHastaGirisPaneli frm = new FrmHastaGirisPaneli();
            frm.Show();
        }

        private void buttonBilgiDuzenle_Click(object sender, EventArgs e)
        {
            FrmHastaBilgiDuzenlemePaneli frm = new FrmHastaBilgiDuzenlemePaneli();
            frm.tcNo = labelTcKimlikNo.Text;
            frm.ShowDialog();
        }

        private void comboBoxBranslar_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxDoktorlar.Items.Clear();
            SqlCommand command3 = new SqlCommand("select doktorad,doktorsoyad from table_doktorlar where doktorBrans = @brans", bgl.baglanti());
            command3.Parameters.AddWithValue("@brans", comboBoxBranslar.Text);
            SqlDataReader dr3 = command3.ExecuteReader();
            while (dr3.Read())
            {
                comboBoxDoktorlar.Items.Add(dr3[0] + " " + dr3[1]);
            }
            dr3.Close();
            bgl.baglanti().Close();

            if (comboBoxBolumler.Text == "Poliklinik Randevuları")
            {
                PoliklinikRandevuları();
            }
            
        }

        private void comboBoxBolumler_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxBolumler.Text == "Randevu Geçmişim")
            {
                textBoxId.Text = "";
                richTextBoxSikayet.Text = "";
        
                HastaRandevuGecmisi();

                comboBoxBranslar.Enabled = false;
                comboBoxBranslar.Text = null;
                comboBoxDoktorlar.Enabled = false;
                comboBoxDoktorlar.Text = null;
            }
            if (comboBoxBolumler.Text == "Doktor Randevuları")
            {
                AlinabilirRandevular();

                comboBoxBranslar.Enabled = true;
                comboBoxDoktorlar.Enabled = true;
            }
            if (comboBoxBolumler.Text == "Poliklinik Randevuları")
            {
                PoliklinikRandevuları();

                comboBoxBranslar.Enabled = true;
                comboBoxDoktorlar.Enabled = false;
                comboBoxDoktorlar.Text = null;
            }
        }

        public void HastaRandevuGecmisi()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select RandevuId as 'Randevu No' , randevutarih as 'Randevu Tarihi' , randevusaat as 'Randevu Saati' , randevubrans as 'Poliklinik' , randevudoktor as 'Doktor' , hastasikayet as 'Şikayetiniz' from table_randevular where HastaTc ='" + labelTcKimlikNo.Text+"'",bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        public void AlinabilirRandevular()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select RandevuId as 'Randevu No' , randevutarih as 'Randevu Tarihi' , randevusaat as 'Randevu Saati' , randevubrans as 'Poliklinik' , randevudoktor as 'Doktor' from table_randevular where randevubrans ='" + comboBoxBranslar.Text+"' and randevudoktor ='"+comboBoxDoktorlar.Text+"' and randevudurum = 0 and RandevuTarih >= '"+ Convert.ToDateTime(DateTime.Now.ToString("d",DateTimeFormatInfo.InvariantInfo)) + "'", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        public void PoliklinikRandevuları()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select RandevuId as 'Randevu No' , randevutarih as 'Randevu Tarihi' , randevusaat as 'Randevu Saati' , randevubrans as 'Poliklinik' , randevudoktor as 'Doktor' from table_randevular where randevubrans = '" + comboBoxBranslar.Text+ "' and randevudurum = 0 and RandevuTarih >= '"+ Convert.ToDateTime(DateTime.Now.ToString("d", DateTimeFormatInfo.InvariantInfo)) + "'", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void comboBoxDoktorlar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxBolumler.Text == "Doktor Randevuları")
            {
                AlinabilirRandevular();
            }
        }

        private void dateTimePickerBaslangic_ValueChanged(object sender, EventArgs e)
        {      
            if (dateTimePickerBaslangic.Value < dateTimePickerBitis.Value)
            {
                dateTimePickerBitis.Enabled = true;
            }
            else
            {
                dateTimePickerBitis.Value = dateTimePickerBaslangic.Value;
            }
        }

        private void dateTimePickerBitis_ValueChanged(object sender, EventArgs e)
        {        
            if (dateTimePickerBaslangic.Value > dateTimePickerBitis.Value)
            {
                dateTimePickerBitis.Value = dateTimePickerBaslangic.Value;
            }               
        }
        
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (comboBoxBolumler.Text == "Doktor Randevuları" || comboBoxBolumler.Text == "Poliklinik Randevuları")
            {
                DataGridViewRow secilenSatir = dataGridView1.CurrentRow;
                textBoxId.Text = secilenSatir.Cells[0].Value.ToString();
            }
        }

        private void buttonRandevuAl_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxId.Text))
            {
                MessageBox.Show("Randevu Alınamadı!! \nLütfen Alacağınız Randevunun Randevu No'sunu Randevuya çift tıklayarak belirleyiniz.","Hata!!",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                SqlCommand cmd = new SqlCommand("update table_randevular set RandevuDurum = 1 , HastaTc = @tc , HastaSikayet = @sikayet , RandevununAlindigiTarih = @rat where RandevuId = @id", bgl.baglanti());
                cmd.Parameters.AddWithValue("@tc", labelTcKimlikNo.Text);
                cmd.Parameters.AddWithValue("@sikayet", richTextBoxSikayet.Text);
                cmd.Parameters.AddWithValue("@rat", DateTime.Now.ToLocalTime().ToString());
                cmd.Parameters.AddWithValue("@id", textBoxId.Text);
                cmd.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Randevu Alındı", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBoxId.Text = "";

                if (comboBoxBolumler.Text == "Doktor Randevuları")
                {
                    AlinabilirRandevular();
                }
                if (comboBoxBolumler.Text == "Poliklinik Randevuları")
                {
                    PoliklinikRandevuları();
                }
            }            
        }

        private void buttonTarihAralıgı_Click(object sender, EventArgs e)
        {
            string TarihBaslangic = dateTimePickerBaslangic.Value.ToString("d",DateTimeFormatInfo.InvariantInfo);
            string TarihBitis = dateTimePickerBitis.Value.ToString("d", DateTimeFormatInfo.InvariantInfo);

            if (comboBoxBolumler.Text == "Randevu Geçmişim")
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("select RandevuId as 'Randevu No' , randevutarih as 'Randevu Tarihi' , randevusaat as 'Randevu Saati' , randevubrans as 'Poliklinik' , randevudoktor as 'Doktor' , hastasikayet as 'Şikayetiniz' from table_randevular where HastaTc ='" + labelTcKimlikNo.Text + "' and randevutarih between '"+TarihBaslangic+"' and '"+TarihBitis+"'", bgl.baglanti());
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            if (comboBoxBolumler.Text == "Doktor Randevuları")
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("select RandevuId as 'Randevu No' , randevutarih as 'Randevu Tarihi' , randevusaat as 'Randevu Saati' , randevubrans as 'Poliklinik' , randevudoktor as 'Doktor' from table_randevular where randevubrans ='" + comboBoxBranslar.Text + "' and randevudoktor ='" + comboBoxDoktorlar.Text + "' and randevudurum = 0 and RandevuTarih >= '" + DateTime.Now.ToString("d", DateTimeFormatInfo.InvariantInfo) + "' and randevutarih between '"+TarihBaslangic+"' and '"+TarihBitis+"'", bgl.baglanti());
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            if (comboBoxBolumler.Text == "Poliklinik Randevuları")
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("select RandevuId as 'Randevu No' , randevutarih as 'Randevu Tarihi' , randevusaat as 'Randevu Saati' , randevubrans as 'Poliklinik' , randevudoktor as 'Doktor' from table_randevular where randevubrans = '" + comboBoxBranslar.Text + "' and randevudurum = 0 and RandevuTarih >= '" + DateTime.Now.ToString("d", DateTimeFormatInfo.InvariantInfo) + "' and randevutarih between '"+TarihBaslangic+"' and '"+TarihBitis + "'", bgl.baglanti());
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
}
