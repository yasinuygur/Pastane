using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Pastane
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=MASTER;Initial Catalog=PASTANE;Integrated Security=True;Encrypt=False");

        void malzemeListe()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from tblmalzemeler",baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        void urunListe()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from tblurunler", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        void kasa()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from tblkasa", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void btnurunlistesi_Click(object sender, EventArgs e)
        {
            urunListe();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            malzemeListe();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            kasa();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnmalzeme_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand komut = new SqlCommand("insert into tblmalzemeler (ad, stok,fiyat, notlar) values (@p1,@p2,@p3,@p4)", baglanti);

            komut.Parameters.AddWithValue("@p1",txtmalzemead.Text);
            komut.Parameters.AddWithValue("@p2", txtmalzemestok.Text);
            komut.Parameters.AddWithValue("@p3",txtmalzemefiyat.Text);
            komut.Parameters.AddWithValue("@p4", txtnot.Text);

            komut.ExecuteNonQuery();
            baglanti.Close();

            MessageBox.Show("Malzeme eklendi...");

        }
    }
}
