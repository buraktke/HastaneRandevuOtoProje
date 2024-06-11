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
    public partial class FrmSekreterDetayPaneli : Form
    {
        public FrmSekreterDetayPaneli()
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

        public bool durum = false;

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();

            FrmSekreterGirisPaneli frm = new FrmSekreterGirisPaneli();
            frm.ShowDialog();
        }

        private void FrmSekreterDetayPaneli_Load(object sender, EventArgs e)
        {
            SqlCommand cmd1 = new SqlCommand("select * from table_sekreter where sekretertc = @tc",bgl.baglanti());
            cmd1.Parameters.AddWithValue("@tc", TCKimlikNo);
            SqlDataReader dr1 = cmd1.ExecuteReader();
            while (dr1.Read())
            {
                labelDoktorAdSoyad.Text = dr1[1].ToString();
                labelTcKimlikNo.Text = dr1[2].ToString();
            }
            dr1.Close();
            bgl.baglanti().Close();


            SqlCommand cmd2 = new SqlCommand("select bransad from table_branslar ",bgl.baglanti());
            SqlDataReader dr2 = cmd2.ExecuteReader();
            while (dr2.Read())
            {
                comboBoxBranslar.Items.Add(dr2[0]);
            }
            dr2.Close();
            bgl.baglanti();



            SqlCommand cmd3 = new SqlCommand("select count(*) from table_randevular", bgl.baglanti());
            SqlDataReader dr3 = cmd3.ExecuteReader();
            while(dr3.Read())
            {
                labelOlusturulanRandevular.Text = dr3[0].ToString();
            }
            dr3.Close();

            SqlCommand cmd4 = new SqlCommand("select count(*) from table_randevular where randevudurum = 1", bgl.baglanti());
            SqlDataReader dr4 = cmd4.ExecuteReader();
            while (dr4.Read())
            {
                labelAlinanRandevular.Text = dr4[0].ToString();
            }
            dr4.Close();

            SqlCommand cmd5 = new SqlCommand("select count(*) from table_doktorlar", bgl.baglanti());
            SqlDataReader dr5 = cmd5.ExecuteReader();
            while (dr5.Read())
            {
                labelDoktorSayisi.Text = dr5[0].ToString();
            }
            dr5.Close();

            SqlCommand cmd6 = new SqlCommand("select count(*) from table_sekreter", bgl.baglanti());
            SqlDataReader dr6 = cmd6.ExecuteReader();
            while (dr6.Read())
            {
                labelSekreterSayisi.Text = dr6[0].ToString();
            }
            dr6.Close();

            SqlCommand cmd7 = new SqlCommand("select count(*) from table_branslar", bgl.baglanti());
            SqlDataReader dr7 = cmd7.ExecuteReader();
            while (dr7.Read())
            {
                labelPoliklinikSayisi.Text = dr7[0].ToString();
            }
            dr7.Close();

            SqlCommand cmd8 = new SqlCommand("select count(*) from table_hastalar", bgl.baglanti());
            SqlDataReader dr8 = cmd8.ExecuteReader();
            while (dr8.Read())
            {
                labelHastaSayisi.Text = dr8[0].ToString();
            }
            dr8.Close();

        }

        private void comboBoxBranslar_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxDoktorlar.Items.Clear();
            SqlCommand cmd = new SqlCommand("select doktorad,doktorsoyad from table_doktorlar where doktorbrans = @brans", bgl.baglanti());
            cmd.Parameters.AddWithValue("@brans", comboBoxBranslar.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBoxDoktorlar.Items.Add(dr[0] + " " + dr[1]);
            }
            dr.Close();
        }

        private void buttonDoktorIslemleri_Click(object sender, EventArgs e)
        {
            FrmSekreterDoktorIslemleriPaneli frm = new FrmSekreterDoktorIslemleriPaneli();
            frm.ShowDialog();
        }

        private void buttonBransIslemleri_Click(object sender, EventArgs e)
        {
            FrmSekreterBransIslemleriPaneli frm = new FrmSekreterBransIslemleriPaneli();
            frm.ShowDialog();

        }

        private void buttonRandevular_Click(object sender, EventArgs e)
        {
            FrmSekreterRandevularPaneli frm = new FrmSekreterRandevularPaneli();
            frm.ShowDialog();
        }

        private void buttonDuyurular_Click(object sender, EventArgs e)
        {
            FrmSekreterDuyurularPaneli frm = new FrmSekreterDuyurularPaneli();
            frm.ShowDialog();
        }

        private void comboBoxHizliBakis_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxHizliBakis.Text == "Doktorlar")
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("select doktorad as 'Adı',doktorsoyad as 'Soyadı',doktorbrans as 'Branşı' from table_doktorlar",bgl.baglanti());
                da.Fill(dt);
                dataGridView1.DataSource = dt;            
            }

            if (comboBoxHizliBakis.Text == "Poliklinikler")
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("select bransad as 'Poliklinik Adı' from table_branslar", bgl.baglanti());
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        private void buttonDuyuruYayinlama_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(richTextBoxDuyuruMetni.Text))
            {
                MessageBox.Show("Duyuru Yayınlayabilmek için birşeyler yazınız.","Hata!!",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                SqlCommand cmd = new SqlCommand("insert into table_duyurular(duyuru) values(@duyuru)", bgl.baglanti());
                cmd.Parameters.AddWithValue("@duyuru", richTextBoxDuyuruMetni.Text);
                cmd.ExecuteNonQuery();
                bgl.baglanti();
                MessageBox.Show("Duyuru Yayınlandı", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                richTextBoxDuyuruMetni.Clear();
            }          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void buttonRandevuOlustur_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(maskedTextBoxRandevuTarih.Text) || string.IsNullOrWhiteSpace(maskedTextBoxRandevuSaat.Text) || string.IsNullOrWhiteSpace(comboBoxBranslar.Text) || string.IsNullOrWhiteSpace(comboBoxDoktorlar.Text))
            {
                MessageBox.Show("Randevu Oluşturulabilmesi için yukarıdaki alanların hepsinin dolu olması gerekmektedir.", "Hata!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                SqlCommand cmdKontrol = new SqlCommand("select * from table_randevular where randevuTarih = @rt and randevuSaat = @rs and randevuBrans = @rb and randevuDoktor = @rd ", bgl.baglanti());
                cmdKontrol.Parameters.AddWithValue("@rt", Convert.ToDateTime(maskedTextBoxRandevuTarih.Text));
                cmdKontrol.Parameters.AddWithValue("@rs", maskedTextBoxRandevuSaat.Text);
                cmdKontrol.Parameters.AddWithValue("@rb", comboBoxBranslar.Text);
                cmdKontrol.Parameters.AddWithValue("@rd", comboBoxDoktorlar.Text);
                SqlDataReader drKontrol = cmdKontrol.ExecuteReader();

                if (drKontrol.Read())
                {
                    MessageBox.Show("Bu Randevu oluşturulamaz \nOluşturmak istediğiniz Randevu daha önce oluşturulmuş","Hata!!",MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    DateTime tarih = Convert.ToDateTime(maskedTextBoxRandevuTarih.Text);

                    if (tarih < DateTime.Now.Date)
                    {
                        MessageBox.Show("Bu Randevu oluşturulamaz \nOluşturmak istediğiniz Randevu'nun tarihi geçmiş.", "Hata!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        SqlCommand cmd = new SqlCommand("insert into table_randevular(randevutarih,randevusaat,randevubrans,randevudoktor,randevudurum) values(@p1,@p2,@p3,@p4,0)", bgl.baglanti());
                        cmd.Parameters.AddWithValue("@p1", Convert.ToDateTime(maskedTextBoxRandevuTarih.Text));
                        cmd.Parameters.AddWithValue("@p2", maskedTextBoxRandevuSaat.Text);
                        cmd.Parameters.AddWithValue("@p3", comboBoxBranslar.Text);
                        cmd.Parameters.AddWithValue("@p4", comboBoxDoktorlar.Text);
                        cmd.ExecuteNonQuery();
                        bgl.baglanti().Close();
                        MessageBox.Show("Randevu Oluşturuldu", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }                 
                }
                drKontrol.Close();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SqlCommand cmd3 = new SqlCommand("select count(*) from table_randevular", bgl.baglanti());
            SqlDataReader dr3 = cmd3.ExecuteReader();
            while (dr3.Read())
            {
                labelOlusturulanRandevular.Text = dr3[0].ToString();
            }
            dr3.Close();

            SqlCommand cmd5 = new SqlCommand("select count(*) from table_doktorlar", bgl.baglanti());
            SqlDataReader dr5 = cmd5.ExecuteReader();
            while (dr5.Read())
            {
                labelDoktorSayisi.Text = dr5[0].ToString();
            }
            dr5.Close();

            SqlCommand cmd7 = new SqlCommand("select count(*) from table_branslar", bgl.baglanti());
            SqlDataReader dr7 = cmd7.ExecuteReader();
            while (dr7.Read())
            {
                labelPoliklinikSayisi.Text = dr7[0].ToString();
            }
            dr7.Close();

            comboBoxBranslar.Items.Clear();
            SqlCommand cmd8 = new SqlCommand("select bransad from table_branslar", bgl.baglanti());
            SqlDataReader dr8 = cmd8.ExecuteReader();
            while (dr8.Read()) 
            {
                comboBoxBranslar.Items.Add(dr8[0].ToString());
            }
            dr8.Close();
        }
    }
}
