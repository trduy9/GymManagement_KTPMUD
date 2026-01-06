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
using GymManagement_KTPMUD.DashboardAdminControls;
using static GymManagement_KTPMUD.Form1;

namespace GymManagement_KTPMUD.DashboardUserControls
{
    public partial class UCUser_Payment : UserControl
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=GymManagementDB;Integrated Security=True"; 
        int currentPaymentID;
        public UCUser_Payment()
        {
            InitializeComponent();
            LoadPaymentInfo(Session.MemberID ?? -1);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        //void LoadPaymentInfo(int memberId)
        //{
        //    SqlConnection conn = new SqlConnection(connectionString);

        //    string sql = @"
        //    SELECT 
        //        mp.PlanName,
        //        mp.Price,
        //        mp.DurationMonths,
        //        m.JoinDate,
        //        p.Amount,
        //        p.PaymentID
        //    FROM Payment p
        //    JOIN Member m ON p.MemberID = m.MemberID
        //    JOIN MembershipPlan mp ON p.PlanID = mp.PlanID
        //    WHERE p.MemberID = @mid AND p.Status = 'Pending'";

        //    SqlCommand cmd = new SqlCommand(sql, conn);
        //    cmd.Parameters.AddWithValue("@mid", memberId);

        //    conn.Open();
        //    SqlDataReader rd = cmd.ExecuteReader();

        //    if (rd.Read())
        //    {
        //        currentPaymentID = Convert.ToInt32(rd["PaymentID"]);

        //        lbPlanName.Text = rd["PlanName"].ToString();
        //        lbPlanPrice.Text = "$" + rd["Price"];
        //        lbJoinDate.Text = Convert.ToDateTime(rd["JoinDate"]).ToString("dd MMM yyyy");
        //        lbDuration.Text = rd["DurationMonths"] + " months";
        //        lbTotalDue.Text = "$" + rd["Amount"];
        //    }
        //    else
        //    {
        //        MessageBox.Show("No pending payment.");
        //    }

        //    conn.Close();
        //}

        void LoadPaymentInfo(int memberId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = @"
                SELECT TOP 1
                    mp.PlanName,
                    mp.Price,
                    mp.DurationMonths,
                    m.JoinDate,
                    m.MemberStatus,
                    p.Amount,
                    p.PaymentID,
                    p.Status AS PaymentStatus
                FROM Payment p
                JOIN Member m ON p.MemberID = m.MemberID
                JOIN MembershipPlan mp ON p.PlanID = mp.PlanID
                WHERE p.MemberID = @mid
                ORDER BY p.PaymentID DESC";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@mid", memberId);

                conn.Open();
                SqlDataReader rd = cmd.ExecuteReader();

                if (rd.Read())
                {
                    currentPaymentID = Convert.ToInt32(rd["PaymentID"]);

                    lbPlanName.Text = rd["PlanName"].ToString();
                    lbPlanPrice.Text = "$" + rd["Price"];
                    lbJoinDate.Text = Convert.ToDateTime(rd["JoinDate"]).ToString("dd MMM yyyy");
                    lbDuration.Text = rd["DurationMonths"] + " months";
                    lbTotalDue.Text = "$" + rd["Amount"];

                    string memberStatus = rd["MemberStatus"].ToString();

                    if (memberStatus == "Active")
                    {
                        lbStatus.Text = "Activate";
                        lbStatus.ForeColor = Color.Green;
                        btPayNow.Enabled = false;   // đã thanh toán thì khóa nút
                    }
                    else
                    {
                        lbStatus.Text = "Inactivate";
                        lbStatus.ForeColor = Color.Red;
                        btPayNow.Enabled = true;
                    }
                }
                else
                {
                    MessageBox.Show("No payment found.");
                }
            }
        }


        private void UCUser_Payment_Load(object sender, EventArgs e)
        {
            if (Session.MemberID == null)
            {
                MessageBox.Show("You have not registered any membership.");
                return;
            }

            LoadPaymentInfo(Session.MemberID.Value);
        }

        private void btPayNow_Click(object sender, EventArgs e)
        {
            FormQRCode form = new FormQRCode(currentPaymentID);
            form.ShowDialog();

            LoadPaymentInfo(Session.MemberID.Value);   // reload sau khi thanh toán
        }
    }
}
