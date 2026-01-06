using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static GymManagement_KTPMUD.Form1;

namespace GymManagement_KTPMUD.DashboardUserControls
{
    
    public partial class UCUser_Profile : UserControl
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=GymManagementDB;Integrated Security=True";

        public UCUser_Profile()
        {
            InitializeComponent();
            LoadProfile();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void roundedPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LoadProfile()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = @"
                    SELECT 
                        m.FullName,
                        m.Email,
                        m.Phone,
                        m.BirthDate,
                        m.Address,
                        mp.PlanName,
                        mp.Price,
                        mp.DurationMonths,
                        m.JoinDate,
                        m.MemberStatus,
                        ISNULL(p.Amount,0) AS Amount
                    FROM UserAccount u
                    LEFT JOIN Member m ON u.MemberID = m.MemberID
                    LEFT JOIN MembershipPlan mp ON m.PlanID = mp.PlanID
                    LEFT JOIN Payment p ON p.MemberID = m.MemberID
                    WHERE u.UserID = @uid
                    ORDER BY p.PaymentDate DESC";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@uid", Session.UserID);

                conn.Open();
                SqlDataReader rd = cmd.ExecuteReader();

                if (rd.Read())
                {
                    // USER INFO
                    lbFullName.Text = rd["FullName"].ToString();
                    lbEmail.Text = rd["Email"].ToString();
                    lbPhone.Text = rd["Phone"].ToString();
                    lbDOB.Text = Convert.ToDateTime(rd["BirthDate"]).ToString("dd/MM/yyyy");
                    lbAddress.Text = rd["Address"].ToString();

                    // MEMBERSHIP
                    lbPlanName.Text = rd["PlanName"].ToString();
                    lbPlanPrice.Text = "$" + rd["Price"];
                    lbDuration.Text = rd["DurationMonths"] + " months";
                    lbJoinDate.Text = Convert.ToDateTime(rd["JoinDate"]).ToString("dd MMM yyyy");
                    lbTotalDue.Text = "$" + rd["Amount"];

                    string status = rd["MemberStatus"].ToString();
                    lbStatus.Text = status;

                    // đổi màu status
                    if (status == "Active")
                        lbStatus.ForeColor = Color.LimeGreen;
                    else
                        lbStatus.ForeColor = Color.Red;
                }
                conn.Close();
            }
        }
    }
}
