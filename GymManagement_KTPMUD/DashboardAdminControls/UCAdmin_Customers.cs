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
    public partial class UCAdmin_Customers : UserControl
    {
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=GymManagementDB;Integrated Security=True";
        public UCAdmin_Customers()
        {
            InitializeComponent();
            dGV_Customers.ReadOnly = false;
            dGV_Customers.AllowUserToAddRows = false;
            dGV_Customers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dGV_Customers.MultiSelect = false;

            LoadCustomers(); // gọi hàm hiển thị danh sách khách hàng
        }



        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void search_button_Click(object sender, EventArgs e)
        {
            string keyword = txt_searchCustomers.Text.Trim();
            LoadCustomers(keyword);
        }

        private void txt_searchCustomers_TextChanged(object sender, EventArgs e)
        {

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

                        // Ẩn các cột không cần thiết (nếu muốn)
                        if (dGV_Customers.Columns.Contains("MemberID"))
                            dGV_Customers.Columns["MemberID"].Visible = false;

                        // Căn chỉnh lại cột cho đẹp
                        dGV_Customers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Lỗi khi tải dữ liệu khách hàng: " + ex.Message,
                                "Lỗi hệ thống",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void dGV_Customers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
            DialogResult result = MessageBox.Show(
        "Do you want to save your edits?",
        "Confirm Edit",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Question
    );

            if (result == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();

                        foreach (DataGridViewRow row in dGV_Customers.Rows)
                        {
                            if (row.IsNewRow) continue;

                            // Lấy dữ liệu từng cột (bạn có thể thêm hoặc sửa tùy cấu trúc DB)
                            int memberId = Convert.ToInt32(row.Cells["MemberID"].Value);
                            string fullName = row.Cells["FullName"].Value?.ToString() ?? "";
                            string gender = row.Cells["Gender"].Value?.ToString() ?? "";
                            string phone = row.Cells["Phone"].Value?.ToString() ?? "";
                            string email = row.Cells["Email"].Value?.ToString() ?? "";
                            string planName = row.Cells["MembershipPlan"].Value?.ToString() ?? "";
                            DateTime joinDate = Convert.ToDateTime(row.Cells["JoinDate"].Value);

                            // Cập nhật PlanID theo tên gói (nếu cần)
                            string getPlanIdQuery = "SELECT PlanID FROM MembershipPlan WHERE PlanName = @PlanName";
                            int planId = 0;
                            using (SqlCommand getPlanCmd = new SqlCommand(getPlanIdQuery, conn))
                            {
                                getPlanCmd.Parameters.AddWithValue("@PlanName", planName);
                                var planResult = getPlanCmd.ExecuteScalar();
                                if (planResult != null)
                                    planId = Convert.ToInt32(planResult);
                            }

                            // Câu lệnh update
                            string updateQuery = @"
                        UPDATE Member 
                        SET FullName = @FullName, 
                            Gender = @Gender, 
                            Phone = @Phone, 
                            Email = @Email, 
                            PlanID = @PlanID, 
                            JoinDate = @JoinDate
                        WHERE MemberID = @MemberID";

                            using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                            {
                                cmd.Parameters.AddWithValue("@FullName", fullName);
                                cmd.Parameters.AddWithValue("@Gender", gender);
                                cmd.Parameters.AddWithValue("@Phone", phone);
                                cmd.Parameters.AddWithValue("@Email", email);
                                cmd.Parameters.AddWithValue("@PlanID", planId);
                                cmd.Parameters.AddWithValue("@JoinDate", joinDate);
                                cmd.Parameters.AddWithValue("@MemberID", memberId);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        MessageBox.Show("Customer information updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadCustomers();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

    }
}

