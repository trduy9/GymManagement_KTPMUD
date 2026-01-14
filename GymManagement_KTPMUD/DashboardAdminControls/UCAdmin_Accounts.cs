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

        // LOAD ROLE FILTER 
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


        // LOAD ACCOUNTS
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
    }

}

