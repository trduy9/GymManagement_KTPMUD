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
    public partial class UCAdmin_Classes1 : UserControl
    {
        private string connectionString =@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=GymManagementDB;Integrated Security=True";
        public UCAdmin_Classes1()
        {
            InitializeComponent();
            LoadTrainerList();
            LoadClassTable();
            dgvClasses.ReadOnly = true;
        }

        private void LoadTrainerList()
        {
            string sql = "SELECT TrainerID FROM Trainer";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                cmbTrainerID.Items.Clear();
                while (dr.Read())
                {
                    cmbTrainerID.Items.Add(dr["TrainerID"].ToString());
                }
                dr.Close();
            }
        }

        private void LoadClassTable(string keyword = "")
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = @"
                        SELECT 
                            C.ClassID,
                            C.ClassName,
                            C.Schedule,
                            C.TrainerID,
                            T.FullName AS TrainerName
                        FROM Class C
                        LEFT JOIN Trainer T ON C.TrainerID = T.TrainerID";

                    if (!string.IsNullOrWhiteSpace(keyword))
                    {
                        query += @"
                        WHERE C.ClassName LIKE @Search
                           OR T.FullName LIKE @Search";
                    }

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (!string.IsNullOrWhiteSpace(keyword))
                            cmd.Parameters.AddWithValue("@Search", "%" + keyword + "%");

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        dgvClasses.DataSource = dt;

                        if (dgvClasses.Columns.Contains("Schedule"))
                            dgvClasses.Columns["Schedule"].DefaultCellStyle.Format = "dd/MM/yyyy";

                        dgvClasses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

                        if (dgvClasses.Columns.Contains("ClassID"))
                            dgvClasses.Columns["ClassID"].Width = 120;

                        if (dgvClasses.Columns.Contains("ClassName"))
                            dgvClasses.Columns["ClassName"].Width = 250;

                        if (dgvClasses.Columns.Contains("Schedule"))
                            dgvClasses.Columns["Schedule"].Width = 400;

                        if (dgvClasses.Columns.Contains("TrainerID"))
                            dgvClasses.Columns["TrainerID"].Width = 130;

                        if (dgvClasses.Columns.Contains("TrainerName"))
                            dgvClasses.Columns["TrainerName"].Width = 290;

                        foreach (DataGridViewColumn col in dgvClasses.Columns)
                        {
                            col.Resizable = DataGridViewTriState.False;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dGV_Classes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cmbTrainerID_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "SELECT FullName FROM Trainer WHERE TrainerID = @id";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@id", cmbTrainerID.SelectedItem);

                conn.Open();
                object name = cmd.ExecuteScalar();
                txtTrainerName.Text = name?.ToString() ?? "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtClassName.Text.Trim() == "")
            {
                MessageBox.Show("Please enter Class Name!");
                return;
            }
            if (cmbTrainerID.SelectedIndex == -1)
            {
                MessageBox.Show("Please choose a Trainer ID!");
                return;
            }

            string sql = @"INSERT INTO Class (ClassName, Schedule, TrainerID)
                   VALUES (@name, @date, @tid)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@name", txtClassName.Text.Trim());
                cmd.Parameters.AddWithValue("@date", dateTimePicker1.Value.Date);
                cmd.Parameters.AddWithValue("@tid", cmbTrainerID.SelectedItem);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Added Successfully!");
            LoadClassTable();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dgvClasses.SelectedRows.Count > 0)
            {
                int classID = Convert.ToInt32(dgvClasses.SelectedRows[0].Cells["ClassID"].Value);

                FormEditClass f = new FormEditClass(classID);
                f.ShowDialog();
                LoadClassTable(); // load lại danh sách sau khi edit
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Kiểm tra có chọn dòng nào chưa
            if (dgvClasses.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a class to delete.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Lấy MemberID từ dòng được chọn
            int classId = Convert.ToInt32(dgvClasses.SelectedRows[0].Cells["ClassID"].Value);

            // Hiện hộp thoại xác nhận
            DialogResult result = MessageBox.Show(
                "Do you want to delete this class?",
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
                        string query = "DELETE FROM Class WHERE ClassID = @ClassID";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@ClassID", classId);

                        int rows = cmd.ExecuteNonQuery();

                        if (rows > 0)
                        {
                            MessageBox.Show("Class deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadClassTable(); // gọi lại hàm load danh sách
                        }
                        else
                        {
                            MessageBox.Show("Failed to delete class.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting class: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtTrainerName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
