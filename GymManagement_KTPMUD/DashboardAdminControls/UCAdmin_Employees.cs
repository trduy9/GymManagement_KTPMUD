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
    public partial class UCAdmin_Employees : UserControl
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=GymManagementDB;Integrated Security=True");
        public UCAdmin_Employees()
        {

            InitializeComponent();
            LoadEmployees();
        }

        // 📘 Load danh sách huấn luyện viên
        private void LoadEmployees(string searchKeyword = "")
        {
            {
                string query = @"
            SELECT 
                TrainerID,
                FullName,
                Phone,
                Email,
                Gender,
                BirthDate,
                JoinDate,
                Specialty,
                ExperienceYears
            FROM Trainer";

                if (!string.IsNullOrWhiteSpace(searchKeyword))
                {
                    query += @" WHERE FullName LIKE @Search
                        OR Email LIKE @Search
                        OR Phone LIKE @Search";
                }

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (!string.IsNullOrWhiteSpace(searchKeyword))
                        cmd.Parameters.AddWithValue("@Search", "%" + searchKeyword + "%");

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dGV_Employees.DataSource = dt;
                }
            }
        }

        private void UCAdmin_Employees_Load(object sender, EventArgs e)
        {
            LoadEmployees();
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Tạo instance của form thêm trainer
            FormAddEmployees form = new FormAddEmployees();

            // Hiển thị form dưới dạng dialog (modal)
            form.ShowDialog();

            // Sau khi form đóng, load lại danh sách khách hàng
            LoadEmployees();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Kiểm tra có chọn dòng nào chưa
            if (dGV_Employees.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a trainer to delete.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Lấy MemberID từ dòng được chọn
            int trainerId = Convert.ToInt32(dGV_Employees.SelectedRows[0].Cells["TrainerID"].Value);

            // Hiện hộp thoại xác nhận
            DialogResult result = MessageBox.Show(
                "Do you want to delete this trainer?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                try
                {
                    {
                        conn.Open();
                        string query = "DELETE FROM Trainer WHERE TrainerID = @TrainerID";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@TrainerID", trainerId);

                        int rows = cmd.ExecuteNonQuery();

                        if (rows > 0)
                        {
                            MessageBox.Show("Trainer deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadEmployees(); // gọi lại hàm load danh sách
                        }
                        else
                        {
                            MessageBox.Show("Failed to delete trainer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting customer: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
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
                    {
                        conn.Open();

                        foreach (DataGridViewRow row in dGV_Employees.Rows)
                        {
                            if (row.IsNewRow) continue;

                            int trainerId = Convert.ToInt32(row.Cells["TrainerID"].Value);
                            string fullName = row.Cells["FullName"].Value?.ToString() ?? "";
                            string phone = row.Cells["Phone"].Value?.ToString() ?? "";
                            string email = row.Cells["Email"].Value?.ToString() ?? "";
                            string gender = row.Cells["Gender"].Value?.ToString() ?? "";
                            string specialty = row.Cells["Specialty"].Value?.ToString() ?? "";
                            int expYears = 0;

                            // Ép kiểu an toàn cho ExperienceYears
                            if (row.Cells["ExperienceYears"].Value != null && int.TryParse(row.Cells["ExperienceYears"].Value.ToString(), out int val))
                                expYears = val;

                            // Ngày sinh và ngày tham gia
                            DateTime birthDate = DateTime.Now;
                            DateTime joinDate = DateTime.Now;

                            if (DateTime.TryParse(row.Cells["BirthDate"].Value?.ToString(), out DateTime parsedBirth))
                                birthDate = parsedBirth;
                            if (DateTime.TryParse(row.Cells["JoinDate"].Value?.ToString(), out DateTime parsedJoin))
                                joinDate = parsedJoin;

                            string updateQuery = @"
                        UPDATE Trainer 
                        SET 
                            FullName = @FullName,
                            Phone = @Phone,
                            Email = @Email,
                            Gender = @Gender,
                            BirthDate = @BirthDate,
                            JoinDate = @JoinDate,
                            Specialty = @Specialty,
                            ExperienceYears = @ExperienceYears
                        WHERE TrainerID = @TrainerID";

                            using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                            {
                                cmd.Parameters.AddWithValue("@FullName", fullName);
                                cmd.Parameters.AddWithValue("@Phone", phone);
                                cmd.Parameters.AddWithValue("@Email", email);
                                cmd.Parameters.AddWithValue("@Gender", gender);
                                cmd.Parameters.AddWithValue("@BirthDate", birthDate);
                                cmd.Parameters.AddWithValue("@JoinDate", joinDate);
                                cmd.Parameters.AddWithValue("@Specialty", specialty);
                                cmd.Parameters.AddWithValue("@ExperienceYears", expYears);
                                cmd.Parameters.AddWithValue("@TrainerID", trainerId);

                                cmd.ExecuteNonQuery();
                            }
                        }

                        MessageBox.Show("✅ Trainer information updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadEmployees(); // Cập nhật lại danh sách
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("❌ Error updating trainer data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button_searchCustomers_Click(object sender, EventArgs e)
        {
            string keyword = textBox_searchEmployee.Text.Trim();
            LoadEmployees(keyword);

        }
    }
}
