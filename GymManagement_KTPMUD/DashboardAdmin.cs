using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GymManagement_KTPMUD
{
    public partial class DashboardAdmin : Form
    {
        public DashboardAdmin()
        {
            InitializeComponent();
        }

        private void LoadUserControl(UserControl uc)
        {
            uc.Dock = DockStyle.Fill;
            panelAdmin_UC.Controls.Clear();
            panelAdmin_UC.Controls.Add(uc);
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button_Dashboard_Click(object sender, EventArgs e)
        {

        }

        private void button_customers_Click(object sender, EventArgs e)
        {
            LoadUserControl(new DashboardAdminControls.UCAdmin_Customers());
        }

        private void button_employees_Click(object sender, EventArgs e)
        {

        }

        private void button_classes_Click(object sender, EventArgs e)
        {

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

        private void panelAdmin_UC_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
