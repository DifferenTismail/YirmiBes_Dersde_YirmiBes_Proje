using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Not_Kayit_Sistemi
{
    public partial class FrmOgrenciDetay : Form
    {
        public FrmOgrenciDetay()
        {
            InitializeComponent();
        }

        public string numara;

        // Ensure the connection string is correct.
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-AV376HC\SQLEXPRESS;Initial Catalog=DbNotKayit;Integrated Security=True;");

        private void FrmOgrenciDetay_Load(object sender, EventArgs e)
        {
            LblNumara.Text = numara;

            try
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("Select * from TBL_DERS where OgrNumara = @p1", baglanti);
                komut.Parameters.AddWithValue("@p1", numara);
                SqlDataReader dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    LblAdSoyad.Text = dr[2].ToString() + " " + dr[3].ToString();
                    LblSinavBir.Text = dr[4].ToString();
                    LblSinavIki.Text = dr[5].ToString();
                    LblSinavUc.Text = dr[6].ToString();
                    LblOrtalama.Text = dr[7].ToString();
                    LblDurum.Text = dr[8].ToString();
                }
                baglanti.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Cannot connect to the server. Please check your network connection and SQL Server configuration.\n\n" + ex.Message, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
