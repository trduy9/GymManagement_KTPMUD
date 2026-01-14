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

namespace GymManagement_KTPMUD.DashboardAdminControls
{
    public partial class UserControlDays : UserControl
    {

        SqlConnection conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=GymManagementDB;Integrated Security=True");
        // create another static variable for day
        public static string static_day;

        public UserControlDays()
        {
            InitializeComponent();
        }

        private void UserControlDays_Load(object sender, EventArgs e)
        {

        }

        public void days(int numday)
        {
            //lbdays.Text = numday + "";
            lbdays.Text = numday.ToString();
        }

        private void UserControlDays_Click(object sender, EventArgs e)
        {
            static_day = lbdays.Text;
            // start timer if usercontroldats is click
            FormAddClasses addclassform = new FormAddClasses();
            addclassform.FormClosed += (s, args) => displayEvent(); // ★ refresh khi form đóng
            addclassform.ShowDialog();
        }

        private void displayEvent()
        {
            try
            {
                bool needClose = false;

                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    needClose = true;
                }

                string sql = "SELECT ClassName FROM Class WHERE Schedule = @Schedule";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Schedule",
                        static_day + "/" +
                        UCAdmin_Classes.static_month + "/" +
                        UCAdmin_Classes.static_year);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                        lbClass.Text = reader["ClassName"].ToString();
                    else
                        lbClass.Text = "";

                    reader.Close();
                }

                if (needClose)
                    conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // call the displayClass method
            //displayEvent();
        }

        private void lbClass_Click(object sender, EventArgs e)
        {

        }
    }
}
