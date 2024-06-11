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
namespace DataBased_Party_Election_Graph_Statistics
{
    public partial class FrmOyGiris : Form
    {
        public FrmOyGiris()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-AV376HC\\SQLEXPRESS;Initial Catalog=DbSecimProje;Integrated Security=True;");
        private void btnOyGiris_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand command = new SqlCommand("insert into Tbl_Ilce (IlceAd, A_Parti, B_Parti, C_Parti, D_Parti, E_Parti) values (@P1, @P2, @P3, @P4, @P5, @P6)",conn);
            command.Parameters.AddWithValue("@P1", txtIlceAd.Text);
            command.Parameters.AddWithValue("@P2", txtA.Text);
            command.Parameters.AddWithValue("@P3", txtB.Text);
            command.Parameters.AddWithValue("@P4", txtC.Text);
            command.Parameters.AddWithValue("@P5", txtD.Text);
            command.Parameters.AddWithValue("@P6", txtE.Text);
            command.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Oy Girişi Gerçekleşti");
        }

        private void btnGrafik_Click(object sender, EventArgs e)
        {
            FrmGrafikler fr = new FrmGrafikler();
            fr.Show();
        }
    }
}
