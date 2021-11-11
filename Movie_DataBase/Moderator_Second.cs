using System;
using System.Windows.Forms;

namespace Movie_DataBase
{
    public partial class Moderator_Second : Form
    {
        public Moderator_Second()
        {
            InitializeComponent();
        }

        private void btnFilm_Click(object sender, EventArgs e)
        {
            Hide();
            Form5 form5 = new Form5();
            form5.ShowDialog();
            Close();
        }

        private void btnFilmMaker_Click(object sender, EventArgs e)
        {
            Hide();
            Form10 form10 = new Form10();
            form10.ShowDialog();
            Close();
        }

        private void btnFilmAndGenre_Click(object sender, EventArgs e)
        {
            Hide();
            Form13 form13 = new Form13();
            form13.ShowDialog();
            Close();
        }

        private void btnGenre_Click(object sender, EventArgs e)
        {
            Hide();
            Form9 form9 = new Form9();
            form9.ShowDialog();
            Close();
        }

        private void btnHall_Click(object sender, EventArgs e)
        {
            Hide();
            Form16 form16 = new Form16();
            form16.ShowDialog();
            Close();
        }

        private void btnTicket_Click(object sender, EventArgs e)
        {
            Hide();
            Form17 form17 = new Form17();
            form17.ShowDialog();
            Close();
        }

        private void btnTiming_Click(object sender, EventArgs e)
        {
            Hide();
            Form21 form21 = new Form21();
            form21.ShowDialog();
            Close();
        }
    }
}
