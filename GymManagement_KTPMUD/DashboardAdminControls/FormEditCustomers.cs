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
    public partial class FormEditCustomers : Form
    {
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=GymManagementDB;Integrated Security=True";
        private int _customerId;
        public FormEditCustomers(int id)
        {
            InitializeComponent();
            _customerId = id;

            LoadMembershipPlans();
            LoadGenderOptions();
            LoadCustomerInfo();
        }

        private void LoadCustomerInfo()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = @"SELECT FullName, Gender, BirthDate,
                        Phone, Email, Address, JoinDate, PlanID
                        FROM Member
                        WHERE MemberID = @ID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", _customerId);
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
                        txtAddress.Text = rd["Address"].ToString();

                        dtBirth.Value = Convert.ToDateTime(rd["BirthDate"]);
                        dtJoin.Value = Convert.ToDateTime(rd["JoinDate"]);

                        cbMembership.SelectedValue = Convert.ToInt32(rd["PlanID"]);
                    }
                    rd.Close();
                }
            }
        }

        private void LoadGenderOptions()
        {
            cbGender.Items.Clear();
            cbGender.Items.Add("Male");
            cbGender.Items.Add("Female");
            cbGender.Items.Add("Other");
        }


        private void LoadMembershipPlans()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT PlanID, PlanName FROM MembershipPlan";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cbMembership.DataSource = dt;
                cbMembership.DisplayMember = "PlanName"; // Hiện tên (Basic, Standard…)
                cbMembership.ValueMember = "PlanID";     // Lưu PlanID
            }
        }


        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button_SIGNUPMember_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Gộp họ + tên thành FullName
                string fullName = txtLastName.Text.Trim() + " " + txtFirstName.Text.Trim();

                string query = @"
                    UPDATE Member SET
                        FullName = @FullName,
                        Gender = @Gender,
                        BirthDate = @BirthDate,
                        Phone = @Phone,
                        Email = @Email,
                        Address = @Address,
                        JoinDate = @JoinDate,
                        PlanID = @PlanID
                    WHERE MemberID = @ID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@FullName", fullName);
                    cmd.Parameters.AddWithValue("@Gender", cbGender.Text);
                    cmd.Parameters.AddWithValue("@BirthDate", dtBirth.Value);
                    cmd.Parameters.AddWithValue("@Phone", txtPhone.Text);
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@JoinDate", dtJoin.Value);
                    cmd.Parameters.AddWithValue("@PlanID", cbMembership.SelectedValue);
                    cmd.Parameters.AddWithValue("@ID", _customerId);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Succesfully Edit");
                this.Close();
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
