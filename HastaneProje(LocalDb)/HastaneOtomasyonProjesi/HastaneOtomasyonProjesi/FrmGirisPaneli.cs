using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HastaneOtomasyonProjesi
{
    public partial class FrmGirisPaneli : Form
    {
        public FrmGirisPaneli()
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


        private void buttonHastaGiris_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmHastaGirisPaneli frm = new FrmHastaGirisPaneli();
            frm.Show();
        }

        private void buttonDoktorGiris_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmDoktorGirisPaneli frm = new FrmDoktorGirisPaneli();
            frm.Show();
        }

        private void buttonSekreterGiris_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmSekreterGirisPaneli frm = new FrmSekreterGirisPaneli();
            frm.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
