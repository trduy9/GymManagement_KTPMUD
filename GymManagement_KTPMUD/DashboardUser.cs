using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GymManagement_KTPMUD.DashboardAdminControls;
using GymManagement_KTPMUD.DashboardUserControls;

namespace GymManagement_KTPMUD
{
    public partial class DashboardUser : Form
    {
        public DashboardUser()
        {
            InitializeComponent();


        }
        private void LoadUserControl(UserControl uc)
        {
            uc.Dock = DockStyle.Fill;
            panelUser_UC.Controls.Clear();
            panelUser_UC.Controls.Add(uc);

        }

        private void button_logout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Do you want to log out?",
                "Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                // Ẩn Dashboard
                this.Hide();

                // Mở lại form Login
                Form1 loginForm = new Form1();
                loginForm.Show();
            }
            else
            {
                // Không làm gì cả, ở lại Dashboard
                return;
            }
        }

        private void button_home_Click(object sender, EventArgs e)
        {
            LoadUserControl(new DashboardUserControls.UCUser_Home());
        }


        private void panelUser_UC_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DashboardUser_Load(object sender, EventArgs e)
        {
            UCUser_Home home = new UCUser_Home();
            LoadUserControl(home);
        }

        private void button_employees_Click(object sender, EventArgs e)
        {
            LoadUserControl(new DashboardUserControls.UCUser_Membership());
        }

        private void button_payments_Click(object sender, EventArgs e)
        {
            LoadUserControl(new DashboardUserControls.UCUser_Payment());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadUserControl(new DashboardUserControls.UCUser_Profile());
        }
    }
}
