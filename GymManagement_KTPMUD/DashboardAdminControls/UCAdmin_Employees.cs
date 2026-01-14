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
            dGV_Employees.ReadOnly = true;                
            dGV_Employees.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dGV_Employees.MultiSelect = false;            
            dGV_Employees.AllowUserToAddRows = false;     
        }

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
                    dGV_Employees.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

                    // Gán độ rộng cố định cho từng cột
                    if (dGV_Employees.Columns.Contains("TrainerID"))
                        dGV_Employees.Columns["TrainerID"].Width = 120;

                    if (dGV_Employees.Columns.Contains("FullName"))
                        dGV_Employees.Columns["FullName"].Width = 200;

                    if (dGV_Employees.Columns.Contains("Specialty"))
                        dGV_Employees.Columns["Specialty"].Width = 120;

                    if (dGV_Employees.Columns.Contains("ExperienceYears"))
                        dGV_Employees.Columns["ExperienceYears"].Width = 180;

                    if (dGV_Employees.Columns.Contains("Gender"))
                        dGV_Employees.Columns["Gender"].Width = 100;

                    if (dGV_Employees.Columns.Contains("Email"))
                        dGV_Employees.Columns["Email"].Width = 180;

                    if(dGV_Employees.Columns.Contains("Phone"))
                        dGV_Employees.Columns["Phone"].Width = 160;

                    if (dGV_Employees.Columns.Contains("BirthDate"))
                        dGV_Employees.Columns["BirthDate"].Width = 100;

                    if (dGV_Employees.Columns.Contains("JoinDate"))
                        dGV_Employees.Columns["JoinDate"].Width = 100;

                    // Không cho người dùng resize cột
                    foreach (DataGridViewColumn col in dGV_Employees.Columns)
                    {
                        col.Resizable = DataGridViewTriState.False;
                    }
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

            // form đóng, load lại danh sách khách hàng
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
                    MessageBox.Show("Error deleting trainer: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dGV_Employees.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a trainer first!");
                return;
            }

            int id = Convert.ToInt32(dGV_Employees.SelectedRows[0].Cells["TrainerID"].Value);

            FormEditEmployees f = new FormEditEmployees(id);
            f.ShowDialog();

            LoadEmployees(); // load lại danh sách sau khi edit
        }

        private void button_searchCustomers_Click(object sender, EventArgs e)
        {
            string keyword = textBox_searchEmployee.Text.Trim();
            LoadEmployees(keyword);

        }

        private void roundAnglePanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void UCAdmin_Employees_Load_1(object sender, EventArgs e)
        {

        }
    }
}
