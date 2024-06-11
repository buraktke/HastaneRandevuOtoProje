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
    public partial class FrmDoktorTahlilEklemePaneli : Form
    {
        public FrmDoktorTahlilEklemePaneli()
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

        public string RandevuNo;

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxTahlilDurumu.Checked)
            {
                checkBoxTahlilDurumu.Text = "Tahlil Tamamlandı";
            }
            else
            {
                checkBoxTahlilDurumu.Text = "Devam Ediyor";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void FrmDoktorTahlilEklemePaneli_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from table_randevular where randevuId = @id", bgl.baglanti());
            cmd.Parameters.AddWithValue("@id", RandevuNo);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read()) 
            {
                SqlCommand cmd2 = new SqlCommand("select * from table_hastalar where hastatc = @tc",bgl.baglanti());
                cmd2.Parameters.AddWithValue("@tc", dr[6]);
                SqlDataReader dr2 = cmd2.ExecuteReader();
                if (dr2.Read()) 
                {
                    labelRandevuNo.Text = RandevuNo;
                    labelKisiBilgileri.Text = dr2[1] + " " + dr2[2] + " / " + dr2[3];
                }
                else
                {
                    MessageBox.Show("Bu randevu alınmadığı için tahlil paneli gözükmemektedir.\nHasta tarafından alındığı zaman gözükecektir.","Hata!!",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    this.Close();
                }
                dr2.Close();
                bgl.baglanti().Close();
            }
            dr.Close();
            bgl.baglanti().Close();


            SqlCommand cmd3 = new SqlCommand("select * from table_tahliller where randevuno = @rNo", bgl.baglanti());
            cmd3.Parameters.AddWithValue("@rNo", labelRandevuNo.Text);
            SqlDataReader dr3 = cmd3.ExecuteReader();
            while (dr3.Read())
            {
                richTextBoxTahlilSonucu.Text = dr3[1].ToString();
                textBoxTahlilHareketi.Text = dr3[2].ToString();
                if (dr3[3].ToString() == "Tahlil Tamamlandı")
                {
                    checkBoxTahlilDurumu.Text = dr3[3].ToString();
                    checkBoxTahlilDurumu.Checked = true;
                }
                else
                {
                    checkBoxTahlilDurumu.Text = dr3[3].ToString();
                    checkBoxTahlilDurumu.Checked = false;
                }
                textBoxVerilecekIlaclar.Text = dr3[4].ToString();
            }
            dr3.Close();
            bgl.baglanti().Close();


            if (!string.IsNullOrWhiteSpace(textBoxTahlilHareketi.Text) || !string.IsNullOrWhiteSpace(textBoxVerilecekIlaclar.Text) || !string.IsNullOrWhiteSpace(richTextBoxTahlilSonucu.Text))
            {
                buttonKaydet.Enabled = false;              
            }
            else
            {
                buttonKaydet.Enabled = true;
                buttonGuncelle.Enabled = false;
            }
        }

        private void buttonKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand cmd1 = new SqlCommand("insert into table_tahliller(tahlilsonucu,tahlilhareketi,tahlildurumu,Ilaclar,randevuno) values(@p1,@p2,@p3,@p4,@p5)", bgl.baglanti());
            cmd1.Parameters.AddWithValue("@p1",richTextBoxTahlilSonucu.Text);
            cmd1.Parameters.AddWithValue("@p2",textBoxTahlilHareketi.Text);
            cmd1.Parameters.AddWithValue("@p3",checkBoxTahlilDurumu.Checked ? "Tahlil Tamamlandı" : "Devam Ediyor");
            if (checkBoxTahlilDurumu.Checked == true)
            {
                if (string.IsNullOrWhiteSpace(textBoxVerilecekIlaclar.Text))
                {
                    cmd1.Parameters.AddWithValue("@p4", "İlaç Verilmedi");
                }
                else
                {
                    cmd1.Parameters.AddWithValue("@p4", textBoxVerilecekIlaclar.Text);
                }
            }
            cmd1.Parameters.AddWithValue("@p4", textBoxVerilecekIlaclar.Text);
            cmd1.Parameters.AddWithValue("@p5",labelRandevuNo.Text);
            cmd1.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Tahlil Eklendi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            buttonKaydet.Enabled = false;
        }

        private void buttonGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand cmd1 = new SqlCommand("update table_tahliller set tahlilsonucu = @p1 ,tahlilhareketi = @p2 ,tahlildurumu = @p3 ,Ilaclar = @p4 where RandevuNo = @p5", bgl.baglanti());
            cmd1.Parameters.AddWithValue("@p1", richTextBoxTahlilSonucu.Text);
            cmd1.Parameters.AddWithValue("@p2", textBoxTahlilHareketi.Text);
            cmd1.Parameters.AddWithValue("@p3", checkBoxTahlilDurumu.Checked ? "Tahlil Tamamlandı" : "Devam Ediyor");
            if (checkBoxTahlilDurumu.Checked == true)
            {
                if (string.IsNullOrWhiteSpace(textBoxVerilecekIlaclar.Text))
                {
                    cmd1.Parameters.AddWithValue("@p4", "İlaç Verilmedi");
                }
                else
                {
                    cmd1.Parameters.AddWithValue("@p4", textBoxVerilecekIlaclar.Text);
                }
            }
            if (checkBoxTahlilDurumu.Checked == false)
            {
                cmd1.Parameters.AddWithValue("@p4", textBoxVerilecekIlaclar.Text);
            }          
            cmd1.Parameters.AddWithValue("@p5", labelRandevuNo.Text);
            cmd1.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Tahlil Güncellendi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


    }
}
