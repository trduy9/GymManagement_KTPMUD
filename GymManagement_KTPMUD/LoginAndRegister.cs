using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

using System.Security.Cryptography;



namespace GymManagement_KTPMUD
{
    public partial class Form1 : Form
    {
        SqlConnection conn = new SqlConnection(
            @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=GymManagementDB;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panelMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }


 

        private void button2_Click(object sender, EventArgs e)
        {
            panel_register.Visible = true;
            panel_login.Visible = false;
            
        }

        private void textbox_email_register_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_login_Click(object sender, EventArgs e)
        {
            panel_login.Visible = true;
            panel_register.Visible = false;

        }

        private void textbox_username_register_TextChanged(object sender, EventArgs e)
        {

        }

        private void textbox_username_login_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel_register_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string username = textbox_username_login.Text.Trim();
            string password = textbox_password_login.Text.Trim();

            if (username == "" || password == "")
            {
                MessageBox.Show("Please enter both username and password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                conn.Open();
                string query = "SELECT Role FROM UserAccount WHERE Username=@Username AND Password=@Password";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);

                object roleObj = cmd.ExecuteScalar();

                if (roleObj != null)
                {
                    string role = roleObj.ToString();
                    MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Ẩn form login
                    this.Hide();

                    // Phân nhánh form theo Role
                    Form dashboardForm = null;
                    switch (role.ToLower())
                    {
                        case "admin":
                            dashboardForm = new DashboardAdmin();
                            break;

                        //case "trainer":
                        //    dashboardForm = new DashboardTrainer();
                        //    break;

                        //case "staff":
                        //    dashboardForm = new DashboardStaff();
                        //    break;

                        //case "member":
                        //    dashboardForm = new DashboardMember();
                        //    break;

                        default:
                            MessageBox.Show("Unknown role: " + role, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.Show();
                            return;
                    }

                    // Gửi thông tin username & role sang dashboard
                    dashboardForm.Tag = new Tuple<string, string>(username, role);

                    // Khi dashboard đóng -> thoát chương trình
                    dashboardForm.FormClosed += (s, args) => Application.Exit();

                    // Hiển thị dashboard
                    dashboardForm.Show();
                }
                else
                {
                    MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }




        private void button_SignUpAfter_Click(object sender, EventArgs e)
        {
            string username = textbox_username_register.Text.Trim();
            string password = textbox_password_register.Text.Trim();

            if (username == "" || password == "")
            {
                MessageBox.Show("Please fill all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                conn.Open();
                string query = "INSERT INTO UserAccount (Username, Password, Role) VALUES (@Username, @Password, 'Member')";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Registration successful! You can now log in.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        private void picturebox1_login_Click(object sender, EventArgs e)
        {

        }

        private void panel_login_register_Paint(object sender, PaintEventArgs e)
        {
 
        }

        private void txtUsername(object sender, EventArgs e)
        {

        }

        private void txtPassword(object sender, EventArgs e)
        {

        }
    }
}

