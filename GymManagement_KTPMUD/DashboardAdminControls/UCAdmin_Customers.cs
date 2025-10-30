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
            LoadCustomers(); // gọi hàm hiển thị danh sách khách hàng
        }

        private void LoadCustomerData(string keyword = "")
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = @"SELECT MemberID, FullName, Gender, BirthDate, Phone, Email, Address, JoinDate, PlanID 
                                     FROM Member";

                    // Nếu có từ khóa, thêm điều kiện lọc
                    if (!string.IsNullOrEmpty(keyword))
                    {
                        query += " WHERE FullName LIKE @keyword";
                    }

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (!string.IsNullOrEmpty(keyword))
                        {
                            cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
                        }

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dGV_Customers.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void search_button_Click(object sender, EventArgs e)
        {
            string keyword = txt_searchCustomers.Text.Trim();
            LoadCustomerData(keyword);
        }

        private void txt_searchCustomers_TextChanged(object sender, EventArgs e)
        {

        }

        private void LoadCustomers(string searchKeyword = "")
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT 
                        M.MemberID,
                        M.FullName,
                        M.Gender,
                        M.Phone,
                        M.Email,
                        P.PlanName AS MembershipPlan,
                        M.JoinDate
                    FROM Member M
                    LEFT JOIN MembershipPlan P ON M.PlanID = P.PlanID";

                // Nếu có từ khóa tìm kiếm
                if (!string.IsNullOrWhiteSpace(searchKeyword))
                {
                    query += " WHERE M.FullName LIKE @Search";
                }

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (!string.IsNullOrWhiteSpace(searchKeyword))
                        cmd.Parameters.AddWithValue("@Search", "%" + searchKeyword + "%");

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dGV_Customers.DataSource = dt;
                }
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
        }
}
