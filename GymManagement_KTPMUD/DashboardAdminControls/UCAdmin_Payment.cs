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
    public partial class UCAdmin_Payment : UserControl
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=GymManagementDB;Integrated Security=True";

        public UCAdmin_Payment()
        {
            InitializeComponent();
            this.Load += UCAdmin_Payment_Load;
        }

        private void UCAdmin_Payment_Load(object sender, EventArgs e)
        {
            LoadPaymentSummary();
        }

        private void LoadPaymentSummary()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Total Revenue
                    SqlCommand cmdTotal = new SqlCommand(
                        "SELECT ISNULL(SUM(Amount), 0) FROM Payment", conn);

                    decimal totalRevenue = (decimal)cmdTotal.ExecuteScalar();
                    lblTotalRevenue.Text = totalRevenue.ToString("N0") + " VND";

                    // Payments Today
                    SqlCommand cmdToday = new SqlCommand(
                        @"SELECT COUNT(*) 
                  FROM Payment
                  WHERE PaymentDate IS NOT NULL
                  AND CAST(PaymentDate AS DATE) = CAST(GETDATE() AS DATE)", conn);

                    int todayPayments = (int)cmdToday.ExecuteScalar();
                    lblTodayPayment.Text = todayPayments.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to load payment\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }



        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lblTotalTitle_Click(object sender, EventArgs e)
        {

        }

        private void lblTodayTitle_Click(object sender, EventArgs e)
        {

        }
    }
}
