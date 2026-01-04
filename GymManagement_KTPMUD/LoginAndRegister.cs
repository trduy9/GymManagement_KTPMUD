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

            // ========== LOGIN PLACEHOLDER ==========
            textbox_username_login.Text = "username";
            textbox_username_login.ForeColor = Color.Gray;

            textbox_password_login.Text = "password";
            textbox_password_login.ForeColor = Color.Gray;
            textbox_password_login.UseSystemPasswordChar = false;

            // ========== REGISTER PLACEHOLDER ==========
            textbox_username_register.Text = "username";
            textbox_username_register.ForeColor = Color.Gray;

            textbox_password_register.Text = "password";
            textbox_password_register.ForeColor = Color.Gray;
            textbox_password_register.UseSystemPasswordChar = false;

            textbox_email_register.Text = "email";
            textbox_email_register.ForeColor = Color.Gray;

            // Gắn sự kiện
            textbox_username_login.GotFocus += RemoveUsernameLoginPlaceholder;
            textbox_username_login.LostFocus += SetUsernameLoginPlaceholder;

            textbox_password_login.GotFocus += RemovePasswordLoginPlaceholder;
            textbox_password_login.LostFocus += SetPasswordLoginPlaceholder;

            textbox_username_register.GotFocus += RemoveUsernameRegisterPlaceholder;
            textbox_username_register.LostFocus += SetUsernameRegisterPlaceholder;

            textbox_password_register.GotFocus += RemovePasswordRegisterPlaceholder;
            textbox_password_register.LostFocus += SetPasswordRegisterPlaceholder;

            textbox_email_register.GotFocus += RemoveEmailRegisterPlaceholder;
            textbox_email_register.LostFocus += SetEmailRegisterPlaceholder;

            // Mặc định ẩn password
            textbox_password_login.UseSystemPasswordChar = true;
            textbox_password_register.UseSystemPasswordChar = true;

            // Gắn icon mặc định
            pictureBox_eyeLogin.Image = Properties.Resources.hide;
            pictureBox_eyeRegister.Image = Properties.Resources.hide;
        }

        public static class Session
        {
            public static int UserID;
            public static string Username;
            public static string Role;
            public static int? MemberID;   // NULL nếu chưa đăng ký membership
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            panel_register.Visible = false;

        }

        private void panelMenu_Paint(object sender, PaintEventArgs e)
        {

        }







        private void button2_Click(object sender, EventArgs e)
        {
            panel_register.Visible = true;
            panel_login.Visible = false;

        }


        private void button_login_Click(object sender, EventArgs e)
        {
            panel_login.Visible = true;
            panel_register.Visible = false;

        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel_register_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //string username = textbox_username_login.Text.Trim();
            //string password = textbox_password_login.Text.Trim();

            //// 🔍 Kiểm tra rỗng hoặc placeholder
            //if (string.IsNullOrEmpty(username) || username == "username" ||
            //    string.IsNullOrEmpty(password) || password == "password")
            //{
            //    MessageBox.Show("Please enter both username and password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            //try
            //{
            //    conn.Open();
            //    string query = "SELECT Role FROM UserAccount WHERE Username=@Username AND Password=@Password";


            //    SqlCommand cmd = new SqlCommand(query, conn);
            //    cmd.Parameters.AddWithValue("@Username", username);
            //    cmd.Parameters.AddWithValue("@Password", password);

            //    object roleObj = cmd.ExecuteScalar();

            //    if (roleObj != null)
            //    {
            //        string role = roleObj.ToString();
            //        MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //        // Ẩn form login
            //        this.Hide();

            //        // Phân nhánh form theo Role
            //        Form dashboardForm = null;
            //        switch (role.ToLower())
            //        {
            //            case "admin":
            //                dashboardForm = new DashboardAdmin();
            //                break;

            //            //case "trainer":
            //            //    dashboardForm = new DashboardTrainer();
            //            //    break;

            //            //case "staff":
            //            //    dashboardForm = new DashboardStaff();
            //            //    break;

            //            case "member":
            //                dashboardForm = new DashboardUser();
            //                break;

            //            default:
            //                MessageBox.Show("Unknown role: " + role, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //                this.Show();
            //                return;
            //        }

            //        // Gửi thông tin username & role sang dashboard
            //        dashboardForm.Tag = new Tuple<string, string>(username, role);

            //        // Khi dashboard đóng -> thoát chương trình
            //        dashboardForm.FormClosed += (s, args) => Application.Exit();

            //        // Hiển thị dashboard
            //        dashboardForm.Show();
            //    }
            //    else
            //    {
            //        MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //finally
            //{
            //    conn.Close();
            //}

   
            string username = textbox_username_login.Text.Trim();
            string password = textbox_password_login.Text.Trim();

            if (string.IsNullOrEmpty(username) || username == "username" ||
                string.IsNullOrEmpty(password) || password == "password")
            {
                MessageBox.Show("Please enter both username and password.");
                return;
            }

            try
            {
                conn.Open();

                string query = @"
                SELECT UserID, Role, MemberID
                FROM UserAccount
                WHERE Username = @Username AND Password = @Password";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);

                SqlDataReader rd = cmd.ExecuteReader();

                if (rd.Read())
                {
                    // Lưu session
                    Session.UserID = Convert.ToInt32(rd["UserID"]);
                    Session.Username = username;
                    Session.Role = rd["Role"].ToString();

                    if (rd["MemberID"] != DBNull.Value)
                        Session.MemberID = Convert.ToInt32(rd["MemberID"]);
                    else
                        Session.MemberID = null;

                    MessageBox.Show("Login successful!");

                    this.Hide();

                    Form dashboard = null;

                    switch (Session.Role.ToLower())
                    {
                        case "admin":
                            dashboard = new DashboardAdmin();
                            break;

                        case "member":
                            dashboard = new DashboardUser();
                            break;

                        default:
                            MessageBox.Show("Unknown role.");
                            this.Show();
                            return;
                    }

                    dashboard.FormClosed += (s, args) => Application.Exit();
                    dashboard.Show();
                }
                else
                {
                    MessageBox.Show("Invalid username or password.");
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




        private void button_SignUpAfter_Click(object sender, EventArgs e)
        {
            string username = textbox_username_register.Text.Trim();
            string password = textbox_password_register.Text.Trim();
            string email = textbox_email_register.Text.Trim();

            // Kiểm tra rỗng hoặc placeholder
            if (string.IsNullOrEmpty(username) || username == "username" ||
                string.IsNullOrEmpty(password) || password == "password" ||
                string.IsNullOrEmpty(email) || email == "email")
            {
                MessageBox.Show("Please fill all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                conn.Open();
                string query = "INSERT INTO UserAccount (Username, Password, Email, Role) VALUES (@Username, @Password, @Email, 'Member')";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);
                    cmd.Parameters.AddWithValue("@Email", email);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Registration successful! You can now log in.",
                                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Reset lại các ô nhập
                textbox_username_register.Text = "username";
                textbox_username_register.ForeColor = Color.Gray;

                textbox_password_register.UseSystemPasswordChar = false;
                textbox_password_register.Text = "password";
                textbox_password_register.ForeColor = Color.Gray;

                textbox_email_register.Text = "email";
                textbox_email_register.ForeColor = Color.Gray;
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

        private void SetPlaceholder(TextBox textBox, string placeholder, bool isPassword = false)
        {
            textBox.Text = placeholder;
            textBox.ForeColor = Color.Gray;

            textBox.GotFocus += (s, e) =>
            {
                if (textBox.Text == placeholder)
                {
                    textBox.Text = "";
                    textBox.ForeColor = Color.Black;
                    if (isPassword)
                        textBox.UseSystemPasswordChar = true;
                }
            };

            textBox.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.Text = placeholder;
                    textBox.ForeColor = Color.Black;
                    if (isPassword)
                        textBox.UseSystemPasswordChar = false;
                }
            };
        }



        private void picturebox1_login_Click(object sender, EventArgs e)
        {

        }


        private void textbox_username_login_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textbox_password_login_TextChanged(object sender, EventArgs e)
        {

        }

        private void panelMenu_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textbox_password_register_TextChanged(object sender, EventArgs e)
        {

        }

        private void textbox_username_register_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private bool isLoginPasswordVisible = false;
        private bool isRegisterPasswordVisible = false;



        private void RemoveUsernameRegisterPlaceholder(object sender, EventArgs e)
        {
            if (textbox_username_register.Text == "username")
            {
                textbox_username_register.Text = "";
                textbox_username_register.ForeColor = Color.Black;
            }
        }

        private void SetUsernameRegisterPlaceholder(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textbox_username_register.Text))
            {
                textbox_username_register.Text = "username";
                textbox_username_register.ForeColor = Color.Gray;
            }
        }

        private void RemovePasswordRegisterPlaceholder(object sender, EventArgs e)
        {
            if (textbox_password_register.Text == "password")
            {
                textbox_password_register.Text = "";
                textbox_password_register.ForeColor = Color.Black;
                textbox_password_register.UseSystemPasswordChar = !isRegisterPasswordVisible;
            }
        }

        private void SetPasswordRegisterPlaceholder(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textbox_password_register.Text))
            {
                textbox_password_register.UseSystemPasswordChar = false;
                textbox_password_register.Text = "password";
                textbox_password_register.ForeColor = Color.Gray;
            }
        }

        private void RemoveEmailRegisterPlaceholder(object sender, EventArgs e)
        {
            if (textbox_email_register.Text == "email")
            {
                textbox_email_register.Text = "";
                textbox_email_register.ForeColor = Color.Black;
            }
        }

        private void SetEmailRegisterPlaceholder(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textbox_email_register.Text))
            {
                textbox_email_register.Text = "email";
                textbox_email_register.ForeColor = Color.Gray;
            }
        }

        private void RemoveUsernameLoginPlaceholder(object sender, EventArgs e)
        {
            if (textbox_username_login.Text == "username")
            {
                textbox_username_login.Text = "";
                textbox_username_login.ForeColor = Color.Black;
            }
        }

        private void SetUsernameLoginPlaceholder(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textbox_username_login.Text))
            {
                textbox_username_login.Text = "username";
                textbox_username_login.ForeColor = Color.Gray;
            }
        }

        private void RemovePasswordLoginPlaceholder(object sender, EventArgs e)
        {
            if (textbox_password_login.Text == "password")
            {
                textbox_password_login.Text = "";
                textbox_password_login.ForeColor = Color.Black;
                textbox_password_login.UseSystemPasswordChar = !isLoginPasswordVisible;
            }
        }

        private void SetPasswordLoginPlaceholder(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textbox_password_login.Text))
            {
                textbox_password_login.UseSystemPasswordChar = false;
                textbox_password_login.Text = "password";
                textbox_password_login.ForeColor = Color.Gray;
            }
        }


        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            isLoginPasswordVisible = !isLoginPasswordVisible;
            textbox_password_login.UseSystemPasswordChar = !isLoginPasswordVisible;
            pictureBox_eyeLogin.Image = isLoginPasswordVisible
                ? Properties.Resources.show
                : Properties.Resources.hide;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            isRegisterPasswordVisible = !isRegisterPasswordVisible;
            textbox_password_register.UseSystemPasswordChar = !isRegisterPasswordVisible;
            pictureBox_eyeRegister.Image = isRegisterPasswordVisible
                ? Properties.Resources.show
                : Properties.Resources.hide;
        }
    }
}

