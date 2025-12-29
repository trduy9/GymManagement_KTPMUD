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
using System.Windows.Forms.DataVisualization.Charting;

namespace GymManagement_KTPMUD.DashboardAdminControls
{
    public partial class UCAdmin_Reports : UserControl
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=GymManagementDB;Integrated Security=True";
        public UCAdmin_Reports()
        {
            InitializeComponent();
            LoadDashboardKPIs();
            LoadRevenueChart();
            LoadTopPlans();
            LoadRecentPayments();
            LoadGenderChart();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void LoadDashboardKPIs()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // TOTAL REVENUE
                SqlCommand cmd1 = new SqlCommand("SELECT ISNULL(SUM(Amount),0) FROM Payment", conn);
                lblTotalRevenue.Text = Convert.ToDecimal(cmd1.ExecuteScalar()).ToString("N0") + " USD";

                // PAYMENT TODAY
                SqlCommand cmd2 = new SqlCommand(
                    "SELECT ISNULL(SUM(Amount),0) FROM Payment WHERE CAST(PaymentDate AS DATE)=CAST(GETDATE() AS DATE)", conn);
                lblPaymentToday.Text = Convert.ToDecimal(cmd2.ExecuteScalar()).ToString("N0") + " USD";

                // TOTAL CUSTOMERS
                SqlCommand cmd3 = new SqlCommand("SELECT COUNT(*) FROM Member", conn);
                lblTotalCustomers.Text = cmd3.ExecuteScalar().ToString();

                // ACTIVE PLANS
                SqlCommand cmd4 = new SqlCommand("SELECT COUNT(*) FROM MembershipPlan", conn);
                lblActivePlans.Text = cmd4.ExecuteScalar().ToString();
            }
        }

        private void LoadRevenueChart()
        {
            chartRevenue.Series.Clear();
            chartRevenue.Series.Add("Revenue");
            chartRevenue.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                SELECT 
                    CAST(PaymentDate AS DATE) AS PayDate,
                    SUM(Amount) AS Total
                FROM Payment
                WHERE PaymentDate >= DATEADD(DAY,-6,GETDATE())
                GROUP BY CAST(PaymentDate AS DATE)
                ORDER BY PayDate";

                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    chartRevenue.Series[0].Points.AddXY(
                        Convert.ToDateTime(rd["PayDate"]).ToString("dd/MM"),
                        Convert.ToDecimal(rd["Total"])
                    );
                }
            }
        }

        private void LoadTopPlans()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                SELECT
                    P.PlanName,
                    COUNT(DISTINCT M.MemberID) AS TotalMembers,
                    ISNULL(SUM(Pay.Amount),0) AS Revenue
                FROM MembershipPlan P
                LEFT JOIN Member M 
                    ON P.PlanID = M.PlanID
                LEFT JOIN Payment Pay 
                    ON Pay.MemberID = M.MemberID   
                GROUP BY P.PlanName
                ORDER BY Revenue DESC
                ";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvTopPlans.DataSource = dt;
                FormatTopPlansGrid();
            }
        }

        private void FormatTopPlansGrid()
        {
            dgvTopPlans.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvTopPlans.AllowUserToAddRows = false;
            dgvTopPlans.ReadOnly = true;
            dgvTopPlans.RowHeadersVisible = false;
            dgvTopPlans.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTopPlans.MultiSelect = false;
            dgvTopPlans.EnableHeadersVisualStyles = false;

            // Set width theo UI Dashboard
            dgvTopPlans.Columns["PlanName"].Width = 100;
            dgvTopPlans.Columns["TotalMembers"].Width = 110;
            dgvTopPlans.Columns["Revenue"].Width = 115;

            // Căn lề
            dgvTopPlans.Columns["PlanName"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleLeft;

            dgvTopPlans.Columns["TotalMembers"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvTopPlans.Columns["Revenue"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleRight;

            // Format tiền
            dgvTopPlans.Columns["Revenue"].DefaultCellStyle.Format = "N0";

            // Header style
            dgvTopPlans.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10, FontStyle.Bold);

            dgvTopPlans.EnableHeadersVisualStyles = false;
            dgvTopPlans.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);

            foreach (DataGridViewColumn col in dgvTopPlans.Columns)
            {
                col.Resizable = DataGridViewTriState.False;
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }


        private void LoadRecentPayments()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                SELECT TOP 10
                    M.FullName,
                    Pay.Amount,
                    Pay.PaymentDate,
                    Pay.PaymentMethod
                FROM Payment Pay
                JOIN Member M ON Pay.MemberID = M.MemberID
                ORDER BY Pay.PaymentDate DESC";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvRecentPayments.DataSource = dt;
                FormatRecentPaymentsGrid();
                dgvRecentPayments.Columns["PaymentDate"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgvRecentPayments.Columns["Amount"].DefaultCellStyle.Format = "N0";
            }
        }

        private void FormatRecentPaymentsGrid()
        {
            dgvRecentPayments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvRecentPayments.AllowUserToAddRows = false;
            dgvRecentPayments.ReadOnly = true;
            dgvRecentPayments.RowHeadersVisible = false;
            dgvRecentPayments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRecentPayments.MultiSelect = false;
            dgvRecentPayments.EnableHeadersVisualStyles = false;


            dgvRecentPayments.Columns["FullName"].Width = 80;
            dgvRecentPayments.Columns["Amount"].Width = 80;
            dgvRecentPayments.Columns["PaymentDate"].Width = 100;
            dgvRecentPayments.Columns["PaymentMethod"].Width = 140;

            // Format
            dgvRecentPayments.Columns["PaymentDate"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvRecentPayments.Columns["Amount"].DefaultCellStyle.Format = "N0";

            // Alignment
            dgvRecentPayments.Columns["FullName"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleLeft;

            dgvRecentPayments.Columns["Amount"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleRight;

            dgvRecentPayments.Columns["PaymentDate"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvRecentPayments.Columns["PaymentMethod"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            // Header
            dgvRecentPayments.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10, FontStyle.Bold);

            dgvRecentPayments.EnableHeadersVisualStyles = false;
            dgvRecentPayments.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(240, 240, 240);

            foreach (DataGridViewColumn col in dgvRecentPayments.Columns)
            {
                col.Resizable = DataGridViewTriState.False;
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }


        private void LoadGenderChart()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                SELECT Gender, COUNT(*) AS Total
                FROM Member
                GROUP BY Gender";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                chartGender.Titles.Clear();
                chartGender.Titles.Add("Member Gender Distribution");

                chartGender.Series.Clear();
                chartGender.ChartAreas.Clear();
                chartGender.Legends.Clear();

                ChartArea area = new ChartArea();
                chartGender.ChartAreas.Add(area);

                Series series = new Series("Gender");
                series.ChartType = SeriesChartType.Pie;
                series.IsValueShownAsLabel = true;
                series.Label = "#PERCENT{P1}";
                series.LegendText = "#VALX";
                

                foreach (DataRow row in dt.Rows)
                {
                    series.Points.AddXY(row["Gender"].ToString(), row["Total"]);
                }

                chartGender.Series.Add(series);

                Legend legend = new Legend();
                legend.Docking = Docking.Right;
                chartGender.Legends.Add(legend);
            }
        }





        private void lblTotalRevenue_Click(object sender, EventArgs e)
        {

        }
    }
}
