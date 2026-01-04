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

        private int selectedMemberID = -1;
        private int selectedPaymentID = -1;

        public UCAdmin_Payment()
        {
            InitializeComponent();

            LoadMembers();
            LoadPlans();
            LoadPaymentMethods();

            LoadTotalRevenue();
            LoadPaymentToday();

            dgvPaymentMembers.CellClick += dgvMembers_CellClick;
            dgvPayments.CellClick += dgvPayments_CellClick;

            //btnAdd.Click += button1_Click;
            //btnUpdate.Click += btnUpdate_Click_1;
            //btnDelete.Click += btnDelete_Click_1;
            btnAdd.Click += btnAdd_Click;
            btnUpdate.Click += btnUpdate_Click;
            btnDelete.Click += btnDelete_Click;
        }

        private void LoadTotalRevenue()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT ISNULL(SUM(Amount), 0) FROM Payment";

                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                decimal total = Convert.ToDecimal(cmd.ExecuteScalar());

                lblTotalRevenue.Text = total.ToString("N0") + " USD";
            }
        }

        private void LoadPaymentToday()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                SELECT ISNULL(SUM(Amount), 0)
                FROM Payment
                WHERE CAST(PaymentDate AS DATE) = CAST(GETDATE() AS DATE)";

                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                decimal today = Convert.ToDecimal(cmd.ExecuteScalar());

                lblTodayPayment.Text = today.ToString("N0") + " USD";
            }
        }




        // ================== LOAD MEMBER (GRID TRÁI) ==================
        private void LoadMembers()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                SELECT 
                    M.MemberID,
                    M.FullName,
                    M.JoinDate,
                    M.PlanID,
                    ISNULL(P.PlanName, N'Chưa đăng ký') AS MembershipPlan
                FROM Member M
                LEFT JOIN MembershipPlan P ON M.PlanID = P.PlanID";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvPaymentMembers.DataSource = dt;

                //dgvPaymentMembers.Columns["MemberID"].Visible = false;
                //dgvPaymentMembers.Columns["JoinDate"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgvPaymentMembers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

                if (dgvPaymentMembers.Columns.Contains("FullName"))
                    dgvPaymentMembers.Columns["FullName"].Width = 180;
                if (dgvPaymentMembers.Columns.Contains("JoinDate"))
                    dgvPaymentMembers.Columns["JoinDate"].Width = 110;
                if (dgvPaymentMembers.Columns.Contains("PlanID"))
                    dgvPaymentMembers.Columns["PlanID"].Width = 80;

                if (dgvPaymentMembers.Columns.Contains("MembershipPlan"))
                    dgvPaymentMembers.Columns["MembershipPlan"].Width = 165;


                dgvPaymentMembers.ReadOnly = true;
                dgvPaymentMembers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvPaymentMembers.AllowUserToAddRows = false;
            }
        }


        // ================== LOAD PLAN ==================
        private void LoadPlans()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT PlanID, PlanName FROM MembershipPlan";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cbPlan.DataSource = dt;
                cbPlan.DisplayMember = "PlanName";
                cbPlan.ValueMember = "PlanID";
            }
        }

        // ================== CLICK MEMBER ==================
        private void dgvMembers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvPaymentMembers.Rows[e.RowIndex];

            selectedMemberID = Convert.ToInt32(row.Cells["MemberID"].Value);
            txtMemberName.Text = row.Cells["FullName"].Value.ToString();
            // LẤY PLAN CỦA MEMBER
            if (row.Cells["PlanID"].Value != DBNull.Value)
            {
                cbPlan.SelectedValue = row.Cells["PlanID"].Value;
            }
            else
            {
                cbPlan.SelectedIndex = -1; // Chưa có gói
            }

            txtMemberName.Text = row.Cells["FullName"].Value.ToString();
            dtpPaymentDate.Value = DateTime.Now;

            LoadPaymentsByMember(selectedMemberID);
            ClearPaymentForm();
        }

        // ================== LOAD PAYMENT HISTORY ==================
        private void LoadPaymentsByMember(int memberID)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                SELECT
                    PaymentID,
                    Amount,
                    PaymentDate,
                    PaymentMethod,
                    Status 
                FROM Payment
                WHERE MemberID = @MemberID";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MemberID", memberID);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvPayments.DataSource = dt;

                dgvPayments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

                if (dgvPayments.Columns.Contains("PaymentID"))
                    dgvPayments.Columns["PaymentID"].Width = 110;

                if (dgvPayments.Columns.Contains("Amount"))
                    dgvPayments.Columns["Amount"].Width = 100;

                if (dgvPayments.Columns.Contains("PaymentDate"))
                    dgvPayments.Columns["PaymentDate"].Width = 145;

                if (dgvPayments.Columns.Contains("PaymentMethod"))
                    dgvPayments.Columns["PaymentMethod"].Width = 155;


                dgvPayments.ReadOnly = true;
                dgvPayments.AllowUserToAddRows = false;
                dgvPayments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
        }

        // ================== CLICK PAYMENT ==================
        private void dgvPayments_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvPayments.Rows[e.RowIndex];

            selectedPaymentID = Convert.ToInt32(row.Cells["PaymentID"].Value);

            txtAmount.Text = row.Cells["Amount"].Value.ToString();
            cbPaymentMethod.Text = row.Cells["PaymentMethod"].Value.ToString();
            dtpPaymentDate.Value =
                Convert.ToDateTime(row.Cells["PaymentDate"].Value);
        }

        // ================== ADD PAYMENT ==================
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (selectedMemberID == -1)
            {
                MessageBox.Show("Please select a member");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // 1️⃣ Insert Payment (Paid)
                string insertPayment = @"
        INSERT INTO Payment
        (MemberID, PlanID, Amount, PaymentDate, PaymentMethod, Status)
        VALUES
        (@MemberID, @PlanID, @Amount, @PaymentDate, @PaymentMethod, 'Paid')";

                SqlCommand cmd = new SqlCommand(insertPayment, conn);
                cmd.Parameters.AddWithValue("@MemberID", selectedMemberID);
                cmd.Parameters.AddWithValue("@PlanID", cbPlan.SelectedValue);
                cmd.Parameters.AddWithValue("@Amount", decimal.Parse(txtAmount.Text));
                cmd.Parameters.AddWithValue("@PaymentDate", dtpPaymentDate.Value);
                cmd.Parameters.AddWithValue("@PaymentMethod", cbPaymentMethod.Text);
                cmd.ExecuteNonQuery();

                // 2️⃣ Set Member → Active
                SqlCommand updateMember = new SqlCommand(
                    "UPDATE Member SET MemberStatus='Active' WHERE MemberID=@mid",
                    conn);
                updateMember.Parameters.AddWithValue("@mid", selectedMemberID);
                updateMember.ExecuteNonQuery();
            }

            LoadPaymentsByMember(selectedMemberID);
            LoadTotalRevenue();
            LoadPaymentToday();
            ClearPaymentForm();
        }

        private void LoadPaymentMethods()
        {
            cbPaymentMethod.Items.Clear();
            cbPaymentMethod.Items.Add("Cash");
            cbPaymentMethod.Items.Add("Card");
            cbPaymentMethod.Items.Add("Transfer");
            cbPaymentMethod.Items.Add("Other");

            cbPaymentMethod.DropDownStyle = ComboBoxStyle.DropDownList;
        }



        // ================== UPDATE PAYMENT ==================
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedPaymentID == -1) return;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                UPDATE Payment
                SET Amount=@Amount,
                    PaymentDate=@PaymentDate,
                    PaymentMethod=@PaymentMethod
                WHERE PaymentID=@PaymentID";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Amount", decimal.Parse(txtAmount.Text));
                cmd.Parameters.AddWithValue("@PaymentDate", dtpPaymentDate.Value);
                cmd.Parameters.AddWithValue("@PaymentMethod", cbPaymentMethod.Text);
                cmd.Parameters.AddWithValue("@PaymentID", selectedPaymentID);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            LoadPaymentsByMember(selectedMemberID);
            LoadTotalRevenue();
            LoadPaymentToday();
        }

        // ================== DELETE PAYMENT ==================
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedPaymentID == -1) return;

            if (MessageBox.Show("Do you want to delete?", "Confirm",
                MessageBoxButtons.YesNo) == DialogResult.No) return;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Payment WHERE PaymentID=@ID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID", selectedPaymentID);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            LoadPaymentsByMember(selectedMemberID);
            LoadTotalRevenue();
            LoadPaymentToday();
            ClearPaymentForm();
        }

        // ================== CLEAR FORM ==================
        private void ClearPaymentForm()
        {
            txtAmount.Clear();
            cbPaymentMethod.SelectedIndex = -1;
            selectedPaymentID = -1;
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

        private void UCAdmin_Payment_Load_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {

        }
    }
}
