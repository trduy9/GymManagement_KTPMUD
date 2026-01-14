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
using static GymManagement_KTPMUD.Form1;

namespace GymManagement_KTPMUD.DashboardUserControls
{
    public partial class FormRegisterMembership : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=GymManagementDB;Integrated Security=True");

        public string SelectedPlan { get; set; }   // nhận gói từ form trước
        public FormRegisterMembership(string planName)
        {
            InitializeComponent();
            SelectedPlan = planName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormRegisterMembership_Load(object sender, EventArgs e)
        {
            LoadMembershipCombo();

            // Gán gói đã chọn vào ComboBox
            comboBox_membership.Text = SelectedPlan;
        }

        private void LoadMembershipCombo()
        {
            try
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT PlanID, PlanName FROM MembershipPlan", conn);

                DataTable dt = new DataTable();
                da.Fill(dt);

                comboBox_membership.DisplayMember = "PlanName";   // hiển thị
                comboBox_membership.ValueMember = "PlanID";       // giá trị thật
                comboBox_membership.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }


        private void button_SIGNUPMember_Click(object sender, EventArgs e)
        {

            string firstName = text_signupMember_firstname.Text.Trim();
            string lastName = text_signupMember_lastname.Text.Trim();
            string fullName = $"{firstName} {lastName}".Trim();
            string gender = comboBox_signupMember_gender.Text;
            DateTime birthDate = dateTimePicker_signupMember_dob.Value;
            string phone = text_signupMember_phone.Text.Trim();
            string email = text_signupMember_email.Text.Trim();
            string address = text_signupMember_address.Text.Trim();
            DateTime joinDate = dateTimePicker_signupMember_joindate.Value;
            int planID = Convert.ToInt32(comboBox_membership.SelectedValue);

            if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(phone))
            {
                MessageBox.Show("Please fill all necessary information!");
                return;
            }

            try
            {
                conn.Open();

                // 1️⃣ Lấy giá gói
                string priceQuery = "SELECT Price FROM MembershipPlan WHERE PlanID=@pid";
                SqlCommand priceCmd = new SqlCommand(priceQuery, conn);
                priceCmd.Parameters.AddWithValue("@pid", planID);
                decimal price = Convert.ToDecimal(priceCmd.ExecuteScalar());

                // 2️⃣ Insert Member (Inactive)
                string insertMember = @"
                INSERT INTO Member 
                (FullName, Gender, BirthDate, Phone, Email, Address, JoinDate, PlanID, MemberStatus) 
                VALUES 
                (@FullName, @Gender, @BirthDate, @Phone, @Email, @Address, @JoinDate, @PlanID, 'Inactive');
                SELECT SCOPE_IDENTITY();";

                SqlCommand cmd = new SqlCommand(insertMember, conn);

                cmd.Parameters.AddWithValue("@FullName", fullName);
                cmd.Parameters.AddWithValue("@Gender", gender);
                cmd.Parameters.AddWithValue("@BirthDate", birthDate);
                cmd.Parameters.AddWithValue("@Phone", phone);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Address", address);
                cmd.Parameters.AddWithValue("@JoinDate", joinDate);
                cmd.Parameters.AddWithValue("@PlanID", planID);

                int memberID = Convert.ToInt32(cmd.ExecuteScalar());

                string updateUser = "UPDATE UserAccount SET MemberID=@mid WHERE UserID=@uid";

                SqlCommand updateCmd = new SqlCommand(updateUser, conn);
                updateCmd.Parameters.AddWithValue("@mid", memberID);
                updateCmd.Parameters.AddWithValue("@uid", Session.UserID);
                updateCmd.ExecuteNonQuery();
                Session.MemberID = memberID;



                // 3️⃣ Insert Payment (Pending)
                string insertPayment = @"
                INSERT INTO Payment(MemberID, PlanID, Amount, PaymentMethod, Status, PaymentDate)
                VALUES(@mid, @pid, @amount, 'Transfer', 'Pending', GETDATE())";

                SqlCommand payCmd = new SqlCommand(insertPayment, conn);
                payCmd.Parameters.AddWithValue("@mid", memberID);
                payCmd.Parameters.AddWithValue("@pid", planID);
                payCmd.Parameters.AddWithValue("@amount", price);
                payCmd.ExecuteNonQuery();


                MessageBox.Show("Membership registered! Please proceed to payment.");

                this.Close();
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

        private void FormRegisterMembership_Load_1(object sender, EventArgs e)
        {
            LoadMembershipCombo();
            LoadGender();

            comboBox_membership.SelectedIndex =
                comboBox_membership.FindStringExact(SelectedPlan);
        }

        private void comboBox_signupMember_gender_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void LoadGender()
        {
            comboBox_signupMember_gender.Items.Clear();
            comboBox_signupMember_gender.Items.Add("Male");
            comboBox_signupMember_gender.Items.Add("Female");
            comboBox_signupMember_gender.Items.Add("Other");
            comboBox_signupMember_gender.SelectedIndex = -1;
        }
    }
}
