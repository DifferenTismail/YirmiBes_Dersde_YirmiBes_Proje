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
namespace Not_Kayit_Sistemi
{
    public partial class FrmOgretmenDetay : Form
    {
        public FrmOgretmenDetay()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-AV376HC\SQLEXPRESS;Initial Catalog=DbNotKayit;Integrated Security=True;");
        private void FrmOgretmenDetay_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dbNotKayitDataSet.TBL_DERS' table. You can move, or remove it, as needed.
            this.tBL_DERSTableAdapter.Fill(this.dbNotKayitDataSet.TBL_DERS);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into TBL_DERS (OgrNumara, OgrAd, OgrSoyad) values (@P1, @P2, @P3)", baglanti);
            komut.Parameters.AddWithValue("@P1", mskNumara.Text);
            komut.Parameters.AddWithValue("@P2", TxtAd.Text);
            komut.Parameters.AddWithValue("@P3", TxtSoyad.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Öğrenci Sisteme Eklendi");
            this.tBL_DERSTableAdapter.Fill(this.dbNotKayitDataSet.TBL_DERS);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            TxtSinavBir.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            TxtSinavIki.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            TxtSinavUc.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double ortalama, s1, s2, s3;
            string durum;
            s1 = Convert.ToDouble(TxtSinavBir.Text);
            s2 = Convert.ToDouble(TxtSinavIki.Text);
            s3 = Convert.ToDouble(TxtSinavUc.Text);

            ortalama = (s1 + s2 + s3) / 3;
            lblSinifOrtalamasi.Text = ortalama.ToString();

            if (ortalama >= 50)
            {
                durum = "True";
            }
            else
            {
                durum = "False";
            }

            baglanti.Open();
            SqlCommand komut = new SqlCommand("update TBL_DERS set OgrS1 = @P1, OgrS2 = @P2, OgrS3 = @P3, Ortalama = @P4, Durum = @P5 WHERE OgrNumara = @P6", baglanti);

            komut.Parameters.AddWithValue("@P1", TxtSinavBir.Text);
            komut.Parameters.AddWithValue("@P2", TxtSinavIki.Text);
            komut.Parameters.AddWithValue("@P3", TxtSinavUc.Text);
            komut.Parameters.AddWithValue("@P4", decimal.Parse(lblSinifOrtalamasi.Text));
            komut.Parameters.AddWithValue("@P5", durum);
            komut.Parameters.AddWithValue("@P6",mskNumara.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Öğrenci Notları Güncellendi");
        }
    }
}
