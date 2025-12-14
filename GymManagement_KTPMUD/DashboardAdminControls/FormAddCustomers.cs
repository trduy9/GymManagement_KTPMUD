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
    public partial class FormAddCustomers : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=GymManagementDB;Integrated Security=True");
        public FormAddCustomers()
        {
            InitializeComponent();
        }

        // Khi form load
        private void FormAddCustomer_Load(object sender, EventArgs e)
        {
            LoadGender();
            LoadMembershipPlans();
            dateTimePicker_signupMember_joindate.Value = DateTime.Now;
        }

        private void LoadGender()
        {
            comboBox_signupMember_gender.Items.Clear();
            comboBox_signupMember_gender.Items.Add("Male");
            comboBox_signupMember_gender.Items.Add("Female");
            comboBox_signupMember_gender.Items.Add("Other");
            comboBox_signupMember_gender.SelectedIndex = -1;
        }

        private void LoadMembershipPlans()
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT PlanID, PlanName FROM MembershipPlan", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                comboBox_signupMember_membership.DataSource = dt;
                comboBox_signupMember_membership.DisplayMember = "PlanName";
                comboBox_signupMember_membership.ValueMember = "PlanID";
                comboBox_signupMember_membership.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erors: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }


        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button_SIGNUPMember_Click(object sender, EventArgs e)
        {
            string firstName = text_signupMember_firstname.Text.Trim();
            string lastName = text_signupMember_lastname.Text.Trim();
            string fullName = $"{firstName} {lastName}".Trim();
            string gender = comboBox_signupMember_gender.SelectedItem.ToString();
            DateTime birthDate = dateTimePicker_signupMember_dob.Value;
            string phone = text_signupMember_phone.Text.Trim();
            string email = text_signupMember_email.Text.Trim();
            string address = text_signupMember_address.Text.Trim();
            DateTime joinDate = dateTimePicker_signupMember_joindate.Value;
            int planID = Convert.ToInt32(comboBox_signupMember_membership.SelectedValue);

            if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(phone))
            {
                MessageBox.Show("Please fill all necessary information!");
                return;
            }

            try
            {
                conn.Open();
                string query = "INSERT INTO Member (FullName, Gender, BirthDate, Phone, Email, Address, JoinDate, PlanID) " +
                               "VALUES (@FullName, @Gender, @BirthDate, @Phone, @Email, @Address, @JoinDate, @PlanID)";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@FullName", fullName);
                cmd.Parameters.AddWithValue("@Gender", gender);
                cmd.Parameters.AddWithValue("@BirthDate", birthDate);
                cmd.Parameters.AddWithValue("@Phone", phone);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Address", address);
                cmd.Parameters.AddWithValue("@JoinDate", joinDate);
                cmd.Parameters.AddWithValue("@PlanID", planID);

                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("Add customers successfully!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Unable to add customers!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }

    }

        private void comboBox_signupMember_gender_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void text_signupMember_lastname_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
