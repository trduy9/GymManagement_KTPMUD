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

    public partial class FormAddClasses : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=GymManagementDB;Integrated Security=True");
        public FormAddClasses()
        {
            InitializeComponent();
        }

        private void FormAddClasses_Load(object sender, EventArgs e)
        {
            // Hiển thị ngày đã click
            txtDate.Text = $"{UserControlDays.static_day}/{UCAdmin_Classes.static_month}/{UCAdmin_Classes.static_year}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();

                string sql = "INSERT INTO Class (ClassName, Schedule) VALUES (@n, @d)";
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@n", txtClassname.Text.Trim());
                cmd.Parameters.AddWithValue("@d", txtDate.Text.Trim());

                cmd.ExecuteNonQuery();

                MessageBox.Show("Successfully saved");
                this.Close();
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
    }
}
