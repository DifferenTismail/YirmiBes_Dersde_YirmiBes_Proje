﻿using System;
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
            while (dr1.Read())
            {
                chart1.Series["Partiler"].Points.AddXY("A Parti", dr1[0]);
                chart1.Series["Partiler"].Points.AddXY("B Parti", dr1[1]);
                chart1.Series["Partiler"].Points.AddXY("C Parti", dr1[2]);
                chart1.Series["Partiler"].Points.AddXY("D Parti", dr1[3]);
                chart1.Series["Partiler"].Points.AddXY("E Parti", dr1[4]);
            }
            conn.Close();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand command = new SqlCommand("select * from Tbl_Ilce where IlceAd = @P1",conn);
            command.Parameters.AddWithValue("@P1", comboBox1.Text);
            SqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                progressBar1.Value = int.Parse(dr[2].ToString());
                progressBar2.Value = int.Parse(dr[3].ToString());
                progressBar3.Value = int.Parse(dr[4].ToString());
                progressBar4.Value = int.Parse(dr[5].ToString());
                progressBar5.Value = int.Parse(dr[6].ToString());

                lblA.Text = dr[2].ToString();
                lblB.Text = dr[3].ToString();
                lblC.Text = dr[4].ToString();
                lblD.Text = dr[5].ToString();
                lblE.Text = dr[6].ToString();
            }
            conn.Close();
        }
    }
}
