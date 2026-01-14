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
using CustomControl;

namespace GymManagement_KTPMUD.DashboardAdminControls
{
    public partial class UCAdmin_Customers : UserControl
    {
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=GymManagementDB;Integrated Security=True";
        public UCAdmin_Customers()
        {
            InitializeComponent();
            LoadCustomers(); // gọi hàm hiển thị danh sách khách hàng
            dGV_Customers.ReadOnly = true;
            dGV_Customers.AllowUserToAddRows = false;
            dGV_Customers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dGV_Customers.MultiSelect = false;
        }

        private void search_button_Click(object sender, EventArgs e)
        {
            string keyword = txt_searchCustomers.Text.Trim();
            LoadCustomers(keyword);
        }

        private void LoadCustomers(string keyword = "")
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Truy vấn đầy đủ thông tin khách hàng + tên gói tập
                    string query = @"
                    SELECT 
                        M.MemberID,
                        M.FullName,
                        M.Gender,
                        M.BirthDate,
                        M.Phone,
                        M.Email,
                        M.Address,
                        M.JoinDate,
                        ISNULL(P.PlanName, N'Chưa đăng ký') AS MembershipPlan
                    FROM Member M
                    LEFT JOIN MembershipPlan P ON M.PlanID = P.PlanID";

                    // Nếu có từ khóa thì thêm điều kiện tìm kiếm
                    if (!string.IsNullOrWhiteSpace(keyword))
                    {
                        query += @"
                    WHERE M.FullName LIKE @Search
                       OR M.Email LIKE @Search
                       OR M.Phone LIKE @Search";
                    }

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (!string.IsNullOrWhiteSpace(keyword))
                            cmd.Parameters.AddWithValue("@Search", "%" + keyword + "%");

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        // Gán dữ liệu lên DataGridView
                        dGV_Customers.DataSource = dt;

                        // Tắt tự động co giãn
                        dGV_Customers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

                        // Gán độ rộng cố định cho từng cột
                        if (dGV_Customers.Columns.Contains("MemberID"))
                            dGV_Customers.Columns["MemberID"].Width = 115;

                        if (dGV_Customers.Columns.Contains("FullName"))
                            dGV_Customers.Columns["FullName"].Width = 200;

                        if (dGV_Customers.Columns.Contains("Gender"))
                            dGV_Customers.Columns["Gender"].Width = 100;

                        if (dGV_Customers.Columns.Contains("BirthDate"))
                            dGV_Customers.Columns["BirthDate"].Width = 120;

                        if (dGV_Customers.Columns.Contains("Phone"))
                            dGV_Customers.Columns["Phone"].Width = 150;

                        if (dGV_Customers.Columns.Contains("Email"))
                            dGV_Customers.Columns["Email"].Width = 180;

                        if (dGV_Customers.Columns.Contains("Address"))
                            dGV_Customers.Columns["Address"].Width = 130;

                        if (dGV_Customers.Columns.Contains("JoinDate"))
                            dGV_Customers.Columns["JoinDate"].Width = 100;

                        if (dGV_Customers.Columns.Contains("MembershipPlan"))
                            dGV_Customers.Columns["MembershipPlan"].Width = 180;

                        // Không cho người dùng resize cột
                        foreach (DataGridViewColumn col in dGV_Customers.Columns)
                        {
                            col.Resizable = DataGridViewTriState.False;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message,
                                "System Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            // Tạo instance của form thêm khách hàng
            FormAddCustomers form = new FormAddCustomers();

            // Hiển thị form dưới dạng dialog (modal)
            form.ShowDialog();

            // Sau khi form đóng, load lại danh sách khách hàng
            LoadCustomers();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Kiểm tra có chọn dòng nào chưa
            if (dGV_Customers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a customer to delete.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Lấy MemberID từ dòng được chọn
            int memberId = Convert.ToInt32(dGV_Customers.SelectedRows[0].Cells["MemberID"].Value);

            // Hiện hộp thoại xác nhận
            DialogResult result = MessageBox.Show(
                "Do you want to delete this customer?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        string query = "DELETE FROM Member WHERE MemberID = @MemberID";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@MemberID", memberId);

                        int rows = cmd.ExecuteNonQuery();

                        if (rows > 0)
                        {
                            MessageBox.Show("Customer deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadCustomers(); // gọi lại hàm load danh sách
                        }
                        else
                        {
                            MessageBox.Show("Failed to delete customer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting customer: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button__Click(object sender, EventArgs e)
        {
            if (dGV_Customers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a customer first!");
                return;
            }

            int id = Convert.ToInt32(dGV_Customers.SelectedRows[0].Cells["MemberID"].Value);

            FormEditCustomers f = new FormEditCustomers(id);
            f.ShowDialog();

            LoadCustomers(); // load lại danh sách sau khi edit
        }

        private void UCAdmin_Customers_Load(object sender, EventArgs e)
        {

        }

        private void dGV_Customers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txt_searchCustomers_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

