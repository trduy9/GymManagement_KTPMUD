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

namespace GymManagement_KTPMUD.DashboardAdminControls
{
    public partial class UCAdmin_Accounts : UserControl
    {
        SqlConnection connectionString = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=GymManagementDB;Integrated Security=True");
        public UCAdmin_Accounts()
        {
            InitializeComponent();
            InitRoleFilter();
            LoadAccounts();

        }

        // ================== LOAD ROLE FILTER ==================
        void InitRoleFilter()
        {
            comboBox1.Items.Add("All");
            comboBox1.Items.Add("Admin");
            comboBox1.Items.Add("Member");
            comboBox1.SelectedIndex = 0;

            comboBox1.SelectedIndexChanged += (s, e) => LoadAccounts();
            txtSearch.TextChanged += (s, e) => LoadAccounts();
            btnRefresh.Click += (s, e) => LoadAccounts();
        }

        private void FormAccounts_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("All");
            comboBox1.Items.Add("Admin");

            comboBox1.Items.Add("Member");

            comboBox1.SelectedIndex = 0; // All

            LoadAccounts();
        }


        // ================== LOAD ACCOUNTS ==================
        void LoadAccounts()
        {
            try
            {
                string keyword = txtSearch.Text.Trim();
                string role = comboBox1.SelectedItem.ToString();

                string query = @"
                SELECT 
                    Username,
                    Email,
                    Role,
                    CreatedAt
                FROM UserAccount
                WHERE 
                (Username LIKE @key OR Email LIKE @key)";

                if (role != "All")
                {
                    query += " AND Role = @role";
                }

                SqlCommand cmd = new SqlCommand(query, connectionString);
                cmd.Parameters.AddWithValue("@key", "%" + keyword + "%");

                if (role != "All")
                    cmd.Parameters.AddWithValue("@role", role);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvAccounts.DataSource = dt;
                dgvAccounts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadAccounts();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadAccounts();
        }




        // ================== GRID STYLE ==================
        void StyleGrid()
        {
            dgvAccounts.ReadOnly = true;
            dgvAccounts.AllowUserToAddRows = false;
            dgvAccounts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAccounts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAccounts.RowTemplate.Height = 40;

            dgvAccounts.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvAccounts.DefaultCellStyle.Font = new Font("Segoe UI", 9);

            if (dgvAccounts.Columns["UserID"] != null)
                dgvAccounts.Columns["UserID"].Visible = false;

            //dgvAccounts.CellFormatting += dgvAccounts_CellFormatting;
        }

        // ================== STATUS COLOR ==================
        //private void dgvAccounts_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        //{
        //    if (dgvAccounts.Columns[e.ColumnIndex].Name == "Status")
        //    {
        //        string status = e.Value.ToString();

        //        if (status == "Active")
        //        {
        //            e.CellStyle.BackColor = Color.FromArgb(34, 197, 94);
        //            e.CellStyle.ForeColor = Color.White;
        //        }
        //        else
        //        {
        //            e.CellStyle.BackColor = Color.FromArgb(239, 68, 68);
        //            e.CellStyle.ForeColor = Color.White;
        //        }

        //        e.CellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
        //    }
        //}
    }

}

