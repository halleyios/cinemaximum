using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace movie_n96
{
    public partial class Form1 : Form
    {
        BindingList<Film> movies = new BindingList<Film>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Film film1 = new Film(1, "Hızlı ve Öfkeli 10", "02:50", "Aksiyon", true, new DateTime(2023, 08, 20));

            movies.Add(film1);

            dataGridView1.DataSource = movies; //hastalar listesini datagrid içine ekler
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Film filmler = (Film)dataGridView1.SelectedRows[0].DataBoundItem;

                txtId.Text = filmler.Id.ToString();
                txtAd.Text = filmler.FilmAd;
                txtSure.Text = filmler.Sure;
                cmbTur.Text = filmler.FilmTur;
                cbBegendim.Checked = filmler.Begendim;
                dateTimePicker1.Value = filmler.Tarih;
            }
                
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            string filmad = txtAd.Text;
            string sure = txtSure.Text;
            string tur = cmbTur.Text;
            bool like = cbBegendim.Checked;
            DateTime tarih = DateTime.Now;

            Film filmler = new Film(id, filmad, sure, tur, like, tarih);

            movies.Add(filmler);

            txtId.Clear();
            txtAd.Clear();
            txtSure.Clear();
            cbBegendim.Checked = false; 

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Film filmler = (Film)dataGridView1.SelectedRows[0].DataBoundItem;

                filmler.FilmAd = txtAd.Text;
                filmler.Sure = txtSure.Text;
                filmler.FilmTur = cmbTur.Text;
                filmler.Begendim = cbBegendim.Checked;
                filmler.Tarih = dateTimePicker1.Value;

                dataGridView1.Refresh(); //datagridview yeniden yüklenir.
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            Film filmler = (Film)dataGridView1.SelectedRows[0].DataBoundItem;

            if (dataGridView1.SelectedRows.Count > 0)
            {
                DialogResult sonuc = MessageBox.Show(filmler.FilmAd + " Silinsin mi, Bu işlem geri alınamaz!", "Film Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                if (sonuc == DialogResult.Yes) 
                {
                   movies.Remove(filmler);
                }
            }
        }
    }
}
