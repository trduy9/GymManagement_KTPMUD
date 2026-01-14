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
    public partial class FormAddEmployees : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=GymManagementDB;Integrated Security=True");
        public FormAddEmployees()
        {
            InitializeComponent();
        }

        // Khi form load
        private void FormAddEmployee_Load(object sender, EventArgs e)
        {
            LoadGender();
            dateTimePicker_employee_birth.Value = DateTime.Now.AddYears(-20);
            dateTimePicker_employee_join.Value = DateTime.Now;
        }

        // Load giới tính
        private void LoadGender()
        {
            comboBox_employee_gender.Items.Clear();
            comboBox_employee_gender.Items.Add("Male");
            comboBox_employee_gender.Items.Add("Female");
            comboBox_employee_gender.Items.Add("Other");
            comboBox_employee_gender.SelectedIndex = -1;
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button_SIGNUPMember_Click(object sender, EventArgs e)
        {
            string firstName = text_employee_firstname.Text.Trim();
            string lastName = text_employee_lastname.Text.Trim();
            string fullName = $"{firstName} {lastName}".Trim();
            string gender = comboBox_employee_gender.SelectedItem?.ToString();
            string specialty = text_employee_specialty.Text.Trim();
            string email = text_employee_email.Text.Trim();
            string phone = text_employee_phone.Text.Trim();
            DateTime birthDate = dateTimePicker_employee_birth.Value;
            DateTime joinDate = dateTimePicker_employee_join.Value;

            // Kiểm tra dữ liệu nhập vào
            if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(phone) ||
                string.IsNullOrEmpty(email) || string.IsNullOrEmpty(gender) ||
                string.IsNullOrEmpty(specialty))
            {
                MessageBox.Show("⚠️ Please fill all necessary information!",
                                "Missing Information",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra số năm kinh nghiệm
            if (!int.TryParse(text_employee_experience.Text.Trim(), out int expYears))
            {
                MessageBox.Show("⚠️ Experience years must be a valid number!",
                                "Invalid Input",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            try
            {
                {
                    conn.Open();

                    string query = @"INSERT INTO Trainer 
                             (FullName, Gender, BirthDate, Phone, Email, Specialty, ExperienceYears, JoinDate)
                             VALUES (@FullName, @Gender, @BirthDate, @Phone, @Email, @Specialty, @ExperienceYears, @JoinDate)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@FullName", fullName);
                        cmd.Parameters.AddWithValue("@Gender", gender);
                        cmd.Parameters.AddWithValue("@BirthDate", birthDate);
                        cmd.Parameters.AddWithValue("@Phone", phone);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Specialty", specialty);
                        cmd.Parameters.AddWithValue("@ExperienceYears", expYears);
                        cmd.Parameters.AddWithValue("@JoinDate", joinDate);

                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Trainer added successfully!",
                                            "Success",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("❌ Failed to add trainer!",
                                            "Error",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while adding trainer: " + ex.Message,
                                "System Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox_employee_gender_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
