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
    public partial class FrmGrafikler : Form
    {
        public FrmGrafikler()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-AV376HC\\SQLEXPRESS;Initial Catalog=DbSecimProje;Integrated Security=True;");
        private void FrmGrafikler_Load(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand command = new SqlCommand("Select IlceAd from Tbl_Ilce", conn);
            SqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[0]);
            }
            conn.Close();

            //Render data to chart
            conn.Open();
            SqlCommand command1 = new SqlCommand("select Sum(A_Parti), Sum(B_Parti), Sum(C_Parti), Sum(D_Parti), Sum(E_Parti) from Tbl_Ilce", conn);
            SqlDataReader dr1 = command1.ExecuteReader();

        }
    }
}
