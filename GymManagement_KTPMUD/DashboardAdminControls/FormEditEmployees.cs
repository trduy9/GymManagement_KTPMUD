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
    public partial class FormEditEmployees : Form
    {

        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=GymManagementDB;Integrated Security=True";
        private int _trainerId;
        public FormEditEmployees(int id)
        {
            InitializeComponent();
            _trainerId = id;
            LoadCEmployeeInfo();
            LoadGenderOptions();

        }

        private void LoadGenderOptions()
        {
            cbGender.Items.Clear();
            cbGender.Items.Add("Male");
            cbGender.Items.Add("Female");
            cbGender.Items.Add("Other");
        }

        private void LoadCEmployeeInfo()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = @"SELECT FullName, Gender, BirthDate,
                        Phone, Email, Specialty, ExperienceYears, JoinDate
                        FROM Trainer
                        WHERE TrainerID = @ID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", _trainerId);
                    SqlDataReader rd = cmd.ExecuteReader();

                    if (rd.Read())
                    {
                        string fullName = rd["FullName"].ToString();

                        // ⭐ TÁCH HỌ + TÊN
                        string[] parts = fullName.Trim().Split(' ');
                        if (parts.Length > 1)
                        {
                            txtLastName.Text = parts[0];
                            txtFirstName.Text = string.Join(" ", parts.Skip(1));
                        }
                        else
                        {
                            txtLastName.Text = fullName;
                            txtFirstName.Text = "";
                        }

                        cbGender.Text = rd["Gender"].ToString();
                        txtPhone.Text = rd["Phone"].ToString();
                        txtEmail.Text = rd["Email"].ToString();
                        txtExperiencedyear.Text = rd["ExperienceYears"].ToString();
                        txtSpecialty.Text = rd["Specialty"].ToString();



                        dtBirth.Value = Convert.ToDateTime(rd["BirthDate"]);
                        dtJoin.Value = Convert.ToDateTime(rd["JoinDate"]);
                        
                        
                    }
                    rd.Close();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_SIGNUPMember_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Gộp họ + tên thành FullName
                string fullName = txtLastName.Text.Trim() + " " + txtFirstName.Text.Trim();

                string query = @"
                    UPDATE Trainer SET
                        FullName = @FullName,
                        Gender = @Gender,
                        BirthDate = @BirthDate,
                        Phone = @Phone,
                        Email = @Email,
                        Specialty = @Specialty,
                        ExperienceYears = @ExperienceYears,
                        JoinDate = @JoinDate
                    WHERE TrainerID = @ID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@FullName", fullName);
                    cmd.Parameters.AddWithValue("@Gender", cbGender.Text);
                    cmd.Parameters.AddWithValue("@BirthDate", dtBirth.Value);
                    cmd.Parameters.AddWithValue("@Phone", txtPhone.Text);
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@Specialty", txtSpecialty.Text);
                    cmd.Parameters.AddWithValue("@ExperienceYears", txtExperiencedyear.Text);
                    cmd.Parameters.AddWithValue("@JoinDate", dtJoin.Value);
                    cmd.Parameters.AddWithValue("@ID", _trainerId);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Succesfully Edit");
                this.Close();
            }
        }
    }
}
