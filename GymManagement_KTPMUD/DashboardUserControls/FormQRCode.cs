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
    public partial class FormQRCode : Form
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=GymManagementDB;Integrated Security=True";
        int currentPaymentID;
        public FormQRCode(int paymentID)
        {
            InitializeComponent();
            currentPaymentID = paymentID;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            // Update Payment
            SqlCommand payCmd = new SqlCommand(
                "UPDATE Payment SET Status='Paid', PaymentDate=GETDATE() WHERE PaymentID=@pid",
                conn);
            payCmd.Parameters.AddWithValue("@pid", currentPaymentID);
            payCmd.ExecuteNonQuery();

            // Activate Member
            SqlCommand memCmd = new SqlCommand(
                "UPDATE Member SET MemberStatus='Active' WHERE MemberID=@mid",
                conn);
            memCmd.Parameters.AddWithValue("@mid", Session.MemberID);
            memCmd.ExecuteNonQuery();

            conn.Close();

            MessageBox.Show("Payment successful. Membership activated!");
            this.Close();
        }
    }
}
