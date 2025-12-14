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
    public partial class FormEditClass : Form
    {
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=GymManagementDB;Integrated Security=True";
        private int _classId;
        private bool isLoading = true;
        public FormEditClass(int classId)
        {
            InitializeComponent();
            _classId = classId;

            isLoading = true;        // Đặt trước khi load
            LoadTrainerList();
            LoadClassInfo();
            isLoading = false;       // Mở lại event
            cbTrainerID.SelectedIndexChanged += cbTrainerID_SelectedIndexChanged;
        }

        private void LoadTrainerList()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT TrainerID, FullName FROM Trainer";

                using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cbTrainerID.DataSource = dt;
                    cbTrainerID.ValueMember = "TrainerID";
                    cbTrainerID.DisplayMember = "TrainerID";
                }
            }

          
             
        }

        private void LoadClassInfo()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = @"
                    SELECT C.ClassName, C.Schedule, C.TrainerID, T.FullName AS TrainerName
                    FROM Class C
                    LEFT JOIN Trainer T ON C.TrainerID = T.TrainerID
                    WHERE C.ClassID = @ID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", _classId);
                    SqlDataReader rd = cmd.ExecuteReader();

                    if (rd.Read())
                    {
                        txtClassName.Text = rd["ClassName"].ToString();

                        if (rd["Schedule"] != DBNull.Value)
                            dtSchedule.Value = Convert.ToDateTime(rd["Schedule"]);

                        // SET TRAINERID đúng
                        if (rd["TrainerID"] != DBNull.Value)
                            cbTrainerID.SelectedValue = Convert.ToInt32(rd["TrainerID"]);

                        // HIỆN TÊN TRAINER
                        txtTrainerName.Text = rd["TrainerName"].ToString();
                    }

                    rd.Close();
                }
            }
        }

        private void cbTrainerID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoading) return;

            if (cbTrainerID.SelectedIndex >= 0)
            {
                DataRowView drv = cbTrainerID.SelectedItem as DataRowView;

                if (drv != null)
                {
                    txtTrainerName.Text = drv["FullName"].ToString();
                }
            }
        }

        private void UpdateClassInfo()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = @"
            UPDATE Class
            SET 
                ClassName = @ClassName,
                Schedule = @Schedule,
                TrainerID = @TrainerID
            WHERE ClassID = @ID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ClassName", txtClassName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Schedule", dtSchedule.Value);
                    cmd.Parameters.AddWithValue("@TrainerID", cbTrainerID.SelectedValue);
                    cmd.Parameters.AddWithValue("@ID", _classId);

                    int rows = cmd.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        MessageBox.Show("Class updated successfully!", "Success",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close(); // đóng form edit
                    }
                    else
                    {
                        MessageBox.Show("Update failed!", "Error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }




        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_SIGNUPMember_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
               "Do you want to save this information?",
               "Confirm Save",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question
        );

            if (result == DialogResult.Yes)
            {
                UpdateClassInfo();
            }
        }
    }
}
