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
using static GymManagement_KTPMUD.Form1;

namespace GymManagement_KTPMUD.DashboardUserControls
{
    public partial class UCUser_Membership : UserControl
    {
        public UCUser_Membership()
        {
            InitializeComponent();
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            if (Session.MemberID != null)
            {
                MessageBox.Show("You already have a membership. Please go to Payment or Dashboard.");
                return;
            }
            string selectedPlan = "Basic";

            FormRegisterMembership frm = new FormRegisterMembership(selectedPlan);
            frm.ShowDialog();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (Session.MemberID != null)
            {
                MessageBox.Show("You already have a membership. Please go to Payment or Dashboard.");
                return;
            }
            FormRegisterMembership frm = new FormRegisterMembership("Standard");
            frm.ShowDialog();


        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            if (Session.MemberID != null)
            {
                MessageBox.Show("You already have a membership. Please go to Payment or Dashboard.");
                return;
            }
            FormRegisterMembership frm = new FormRegisterMembership("Elite");
            frm.ShowDialog();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (Session.MemberID != null)
            {
                MessageBox.Show("You already have a membership. Please go to Payment or Dashboard.");
                return;
            }
            FormRegisterMembership frm = new FormRegisterMembership("Premium");
            frm.ShowDialog();
        }
    }
}
