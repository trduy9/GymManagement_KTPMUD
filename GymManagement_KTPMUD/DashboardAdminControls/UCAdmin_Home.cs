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
    
    public partial class UCAdmin_Home : UserControl
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=GymManagementDB;Integrated Security=True";
        public UCAdmin_Home()
        {
            InitializeComponent();
            LoadDashboardStats();
        }

        private void LoadDashboardStats()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // MEMBERS
                SqlCommand cmdMembers = new SqlCommand("SELECT COUNT(*) FROM Member", conn);
                lblMembers.Text = cmdMembers.ExecuteScalar().ToString();

                // STAFF
                SqlCommand cmdStaff = new SqlCommand("SELECT COUNT(*) FROM Trainer", conn);
                lblStaff.Text = cmdStaff.ExecuteScalar().ToString();

                // CLASSES
                SqlCommand cmdClasses = new SqlCommand("SELECT COUNT(*) FROM Class", conn);
                lblClasses.Text = cmdClasses.ExecuteScalar().ToString();

                // EQUIPMENT
                SqlCommand cmdEquip = new SqlCommand("SELECT COUNT(*) FROM Equipment", conn);
                lblEquipment.Text = cmdEquip.ExecuteScalar().ToString();

                // TOTAL REVENUE
                SqlCommand cmdRevenue = new SqlCommand(
                    "SELECT ISNULL(SUM(Amount),0) FROM Payment", conn);
                decimal total = Convert.ToDecimal(cmdRevenue.ExecuteScalar());
                lblTotalRevenue.Text = total.ToString("N0") + " USD";
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
